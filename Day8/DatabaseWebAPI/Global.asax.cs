using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using DatabaseWebAPI.App_Start;
/*
using Autofac;
using Autofac.Integration.WebApi;
using DatabaseWebAPI.Repository;
using DatabaseWebAPI.Repository.Common;
using DatabaseWebAPI.Service;
using DatabaseWebAPI.Service.Common;
using DatabaseWebAPI.Model;
using DatabaseWebAPI.Model.Common;
*/

namespace DatabaseWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AutofacWebApiConfig.Initialize(GlobalConfiguration.Configuration);
            /*
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<StudentRepository>()
                   .As<IStudentRepository>()
                   .InstancePerRequest();

            builder.RegisterType<CourseRepository>()
                   .As<ICourseRepository>()
                   .InstancePerRequest();

            builder.RegisterType<StudentService>()
                   .As<IStudentService>()
                   .InstancePerRequest();

            builder.RegisterType<CourseService>()
                   .As<ICourseService>()
                   .InstancePerRequest();

            builder.RegisterType<Student>()
                   .As<IStudent>()
                   .InstancePerRequest();

            builder.RegisterType<Course>()
                   .As<ICourse>()
                   .InstancePerRequest();

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            */

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
