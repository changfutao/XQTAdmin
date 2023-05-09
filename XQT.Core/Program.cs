using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using XQT.Core.Common;
using XQT.Core.EntityFramework;
using XQT.Core.RegisterModules;
using Yitter.IdGenerator;

var builder = WebApplication.CreateBuilder(args);
var host = builder.Host;
builder.Services.AddSingleton(new Appsettings(builder.Configuration));
var configHelper = new ConfigHelper();
// 应用程序根路径
var basePath = AppContext.BaseDirectory;

#region 用户信息
builder.Services.AddHttpContextAccessor();
// builder.Services.TryAddSingleton<I>
#endregion

#region Jwt配置信息
// Jwt配置信息
var jwtConfig = configHelper.Get<JwtConfig>("jwtconfig", builder.Environment.EnvironmentName);
builder.Services.TryAddSingleton(jwtConfig);
#endregion

#region 雪花算法
// 雪花算法生成主键
var options = new IdGeneratorOptions(1) { WorkerIdBitLength = 6 };
YitIdHelper.SetIdGenerator(options);
#endregion

#region EFCore
builder.Services.AddDbContextPool<XQTContext>(options =>
{
    options.UseSqlServer("name=ConnectionStrings:DefaultConnection", o => o.MigrationsAssembly("XQT.Core.EntityFramework"));
});

#endregion

#region MiniProfiler
// 可以使用/profiler/results访问分析报告
builder.Services.AddMiniProfiler(options => options.RouteBasePath = "/profiler");
#endregion

#region 控制器
builder.Services.AddControllers();
#endregion

#region 身份认证授权
// JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    // 密钥
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecurityKey));
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // 是否验证密钥
        ValidateIssuerSigningKey = true,
        // 密钥
        IssuerSigningKey = key,
        // 是否验证颁发人
        ValidateIssuer = true,
        // 颁发人
        ValidIssuer = jwtConfig.Issuer,
        // 是否验证订阅
        ValidateAudience = true,
        // 订阅人
        ValidAudience = jwtConfig.Audience,
        ValidateLifetime = true,
        //这个是缓冲过期时间，也就是说，即使我们配置了过期时间，这里也要考虑进去，过期时间+缓冲，默认好像是7分钟，你可以直接设置为0
        ClockSkew = TimeSpan.Zero,
        RequireExpirationTime = true
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
});
#endregion

#region Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v0.1.0",
        Title = "XQT.Core.API",
        Description = "框架说明文档",
        Contact = new OpenApiContact
        {
            Email = "changfutao1989@126.com",
            Name = "ross",
        }
    });
    // Controller XML
    var controllerXmlPath = Path.Combine(basePath, "XQT.Core.xml");
    options.IncludeXmlComments(controllerXmlPath, true);
    // Service XML
    var serviceXmlPath = Path.Combine(basePath, "XQT.Core.Service.xml");
    options.IncludeXmlComments(serviceXmlPath);

    // 开启小锁
    options.OperationFilter<AddResponseHeadersFilter>();
    options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

    // 在header中添加token,传递到后台
    options.OperationFilter<SecurityRequirementsOperationFilter>();
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
        Name = "Authorization",//jwt默认的参数名称
        In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
        Type = SecuritySchemeType.ApiKey
    });
});
#endregion

#region Cors
var corUrls = Appsettings.app<string>("corUrls");
builder.Services.AddCors(options =>
{
    options.AddPolicy("Default", policy =>
    {
        if (corUrls.Any())
        {
            policy.WithOrigins(corUrls.ToArray());
        }
        else
        {
            policy.AllowAnyOrigin();
        }
        policy.AllowAnyHeader()
              .AllowAnyMethod();
        if (corUrls.Any())
        {
            policy.AllowCredentials();
        }
    });
});
#endregion

#region Autofac
// 替换默认依赖注入容器
host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        // 向Autofac容器注入  
        try
        {
            // 控制器注入
            builder.RegisterModule(new ControllerModule());

            // 服务注入
            builder.RegisterModule<ServiceModule>();

            // 仓储注入
            // builder.RegisterModule<RepositoryModule>();

            // 单例注入
            builder.RegisterModule<SingleInstanceModule>();
        }
        catch (Exception)
        {

            throw;
        }
    });

#endregion

var app = builder.Build();

#region Swagger中间件
// 只有测试环境开启Swagger
if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        // 路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉(这样一打开根路径直接跳转到swagger页面)
        options.RoutePrefix = "";
    });
}
#endregion

app.UseMiniProfiler();
app.UseRouting();
app.UseCors("Default");
// 先开启认证
app.UseAuthentication();
// 再授权
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run(Appsettings.app("urls"));
