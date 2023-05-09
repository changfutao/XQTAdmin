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
// Ӧ�ó����·��
var basePath = AppContext.BaseDirectory;

#region �û���Ϣ
builder.Services.AddHttpContextAccessor();
// builder.Services.TryAddSingleton<I>
#endregion

#region Jwt������Ϣ
// Jwt������Ϣ
var jwtConfig = configHelper.Get<JwtConfig>("jwtconfig", builder.Environment.EnvironmentName);
builder.Services.TryAddSingleton(jwtConfig);
#endregion

#region ѩ���㷨
// ѩ���㷨��������
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
// ����ʹ��/profiler/results���ʷ�������
builder.Services.AddMiniProfiler(options => options.RouteBasePath = "/profiler");
#endregion

#region ������
builder.Services.AddControllers();
#endregion

#region �����֤��Ȩ
// JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    // ��Կ
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecurityKey));
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // �Ƿ���֤��Կ
        ValidateIssuerSigningKey = true,
        // ��Կ
        IssuerSigningKey = key,
        // �Ƿ���֤�䷢��
        ValidateIssuer = true,
        // �䷢��
        ValidIssuer = jwtConfig.Issuer,
        // �Ƿ���֤����
        ValidateAudience = true,
        // ������
        ValidAudience = jwtConfig.Audience,
        ValidateLifetime = true,
        //����ǻ������ʱ�䣬Ҳ����˵����ʹ���������˹���ʱ�䣬����ҲҪ���ǽ�ȥ������ʱ��+���壬Ĭ�Ϻ�����7���ӣ������ֱ������Ϊ0
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
        Description = "���˵���ĵ�",
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

    // ����С��
    options.OperationFilter<AddResponseHeadersFilter>();
    options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

    // ��header�����token,���ݵ���̨
    options.OperationFilter<SecurityRequirementsOperationFilter>();
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�\"",
        Name = "Authorization",//jwtĬ�ϵĲ�������
        In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
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
// �滻Ĭ������ע������
host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        // ��Autofac����ע��  
        try
        {
            // ������ע��
            builder.RegisterModule(new ControllerModule());

            // ����ע��
            builder.RegisterModule<ServiceModule>();

            // �ִ�ע��
            // builder.RegisterModule<RepositoryModule>();

            // ����ע��
            builder.RegisterModule<SingleInstanceModule>();
        }
        catch (Exception)
        {

            throw;
        }
    });

#endregion

var app = builder.Build();

#region Swagger�м��
// ֻ�в��Ի�������Swagger
if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        // ·�����ã�����Ϊ�գ���ʾֱ���ڸ�������localhost:8001�����ʸ��ļ�,ע��localhost:8001/swagger�Ƿ��ʲ����ģ�ȥlaunchSettings.json��launchUrlȥ��(����һ�򿪸�·��ֱ����ת��swaggerҳ��)
        options.RoutePrefix = "";
    });
}
#endregion

app.UseMiniProfiler();
app.UseRouting();
app.UseCors("Default");
// �ȿ�����֤
app.UseAuthentication();
// ����Ȩ
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run(Appsettings.app("urls"));
