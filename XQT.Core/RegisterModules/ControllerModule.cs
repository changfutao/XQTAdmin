using Autofac;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Module = Autofac.Module;

namespace XQT.Core.RegisterModules
{
    public class ControllerModule: Module
    {
        /// <summary>
        /// 控制器注入
        /// </summary>
        public ControllerModule()
        { }

        protected override void Load(ContainerBuilder builder)
        {
            var controllerTypes = Assembly.Load("XQT.Core")
                                                .GetExportedTypes()
                                                .Where(type => typeof(ControllerBase).IsAssignableFrom(type))
                                                .ToArray();

            builder.RegisterTypes(controllerTypes).PropertiesAutowired();
        }
    }
}
