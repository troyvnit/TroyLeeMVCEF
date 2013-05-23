namespace TroyLeeMVCEF
{
    using System.Reflection;
    using System.Web.Mvc;
    using Autofac;
    using Autofac.Integration.Mvc;

    using TroyLeeMVCEF.Data.Infrastructure.DatabaseFactory;
    using TroyLeeMVCEF.Data.Infrastructure.UnitOfWork;
    using TroyLeeMVCEF.Data.Repositories.User;
    using TroyLeeMVCEF.Mappers;

    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            AutoMapperConfiguration.Configure();
        }
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerHttpRequest();
            var services = Assembly.Load("TroyLeMVCEF.Domain");
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}