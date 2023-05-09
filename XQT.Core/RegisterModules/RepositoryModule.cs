using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace XQT.Core.RegisterModules
{
    public class RepositoryModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var repositoryAssembly = Assembly.Load("XQT.Core.Repository");
            builder.RegisterAssemblyTypes(repositoryAssembly)
                   .Where(a => a.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope(); // Scoped
                   

            // 泛型注入
          //  builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerLifetimeScope();
        }
    }
}
