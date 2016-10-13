using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MyCommunity.DataLayer.Infrastructure;
using MyCommunity.DataLayer.Repositories;
using MyCommunity.Service;
using MyCommunity.Webbapp.Mappers;
using MyCommunity.Webbapp.Controllers;

namespace MyCommunity.Webbapp.App_Start
{
    public static class Bootstrapper
    {


        public static void Run()
        {
            SetAutofacContainer();
            AutoMapperConfiguration.Configuration();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DatabaseManager>().As<IDatabaseManager>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(MessageRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            // Services
            builder.RegisterAssemblyTypes(typeof(MessageService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}