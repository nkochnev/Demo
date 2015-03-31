using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Demo.DependencyInjection.Service;
using Demo.DependencyInjection.Service.Interfaces;
using Demo.Infrastructure;

namespace Demo.DependencyInjection
{
    public class RegisterConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            builder.RegisterFilterProvider();
            builder.RegisterModule(new AutofacWebTypesModule());
            
            builder.RegisterType<DataContext>().As<IDbContext>().InstancePerRequest();
            builder.RegisterType<TeamService>().As<ITeamService>().InstancePerRequest();
            builder.RegisterType<CustomLogger>().As<ILogger>().InstancePerRequest();
            builder.RegisterType<Sender>().As<ISender>().InstancePerRequest();

            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}