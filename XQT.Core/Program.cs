using Autofac;
using Autofac.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
var host = builder.Host;
// Ìæ»»Ä¬ÈÏÒÀÀµ×¢ÈëÈİÆ÷
host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        // ÏòAutofacÈİÆ÷×¢Èë
    });


var app = builder.Build();


app.Run();
