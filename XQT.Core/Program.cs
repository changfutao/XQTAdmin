using Autofac;
using Autofac.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
var host = builder.Host;
// �滻Ĭ������ע������
host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        // ��Autofac����ע��
    });


var app = builder.Build();


app.Run();
