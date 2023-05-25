using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using SampleMVC.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace SampleMVC.Web
{
    public class ContainerConfig
    {
        public static void RegisterContainer(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            /*builder.RegisterType<InMemoryRestaurantData>()
                .As<IRestaurantData>()
                .SingleInstance();
            */
            builder.RegisterType<SqlRestaurantData>()
                .As<IRestaurantData>()
                .InstancePerRequest();
            builder.RegisterType<OdeToFoodDbContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}