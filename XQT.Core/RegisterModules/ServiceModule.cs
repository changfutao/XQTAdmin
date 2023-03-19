using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace XQT.Core.RegisterModules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblyService = Assembly.Load("XQT.Core.Service");
            builder.RegisterAssemblyTypes(assemblyService)
                   .Where(a => a.Name.EndsWith("Service"))
                    .InstancePerLifetimeScope()
                   .AsImplementedInterfaces();
        }
    }
}
