using Autofac;
using CustomerTracking.Caching;
using CustomerTracking.Core.Repositories;
using CustomerTracking.Core.Services;
using CustomerTracking.Core.UnitOfWorks;
using CustomerTracking.Repository;
using CustomerTracking.Repository.Repositories;
using CustomerTracking.Repository.UnitOfWorks;
using CustomerTracking.Service.Mapping;
using CustomerTracking.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace CustomerTracking.API.Modules
{
    public class RepoServiceModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();


            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(a => a.Name.EndsWith
            ("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly,repoAssembly,serviceAssembly).Where(a=>a.Name.EndsWith
            ("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();
        }

    }
}
