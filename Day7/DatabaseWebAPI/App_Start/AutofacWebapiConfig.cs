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
    public class AutofacWebapiConfig
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
            //Register your Web API controllers.  
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

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }

    }
}