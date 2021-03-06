using Autofac;
using Autofac.Integration.WebApi;
using DatabaseWebAPI.Repository;
using DatabaseWebAPI.Repository.Common;
using DatabaseWebAPI.Service;
using DatabaseWebAPI.Service.Common;
using DatabaseWebAPI.Model;
using DatabaseWebAPI.Model.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace DatabaseWebAPI.App_Start
{
    public class AutofacWebApiConfig
    {

        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterModule(new ServiceDIModule());
            builder.RegisterModule(new RepositoryDIModule());
            builder.RegisterModule(new ModelDIModule());           

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            Container = builder.Build();

            return Container;
        }

    }
}