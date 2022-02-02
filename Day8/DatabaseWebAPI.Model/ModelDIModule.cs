using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using System.Text;
using System.Threading.Tasks;
using DatabaseWebAPI.Model.Common;

namespace DatabaseWebAPI.Model
{
    public class ModelDIModule : Module
    {
        protected override void Load(ContainerBuilder builder) 
        {
            builder.RegisterType<Student>()
                       .As<IStudent>()
                       .InstancePerRequest();

            builder.RegisterType<Course>()
                       .As<ICourse>()
                       .InstancePerRequest();
        }
        
    }
}
