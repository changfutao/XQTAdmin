using Autofac;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;
using XQT.Core.Common.Attributes;
using Module = Autofac.Module;

namespace XQT.Core.RegisterModules
{
    public class SingleInstanceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var singleAssembly = Assembly.Load("XQT.Core.Common");

            // 无接口注入单例
            builder.RegisterAssemblyTypes(singleAssembly)
                   .Where(a => a.GetCustomAttribute<SingleInstanceAttribute>() != null)
                   .SingleInstance();

            // 有接口注入单例
            builder.RegisterAssemblyTypes(singleAssembly)
                .Where(a => a.GetCustomAttribute<SingleInstanceAttribute>() != null)
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
