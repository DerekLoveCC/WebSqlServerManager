using Microsoft.Practices.Unity;
using System.Web.Http;

namespace SqlServer.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            RegisterUnityContainer(config);
        }

        private static void RegisterUnityContainer(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterTypes(AllClasses.FromLoadedAssemblies(), WithMappings.FromAllInterfaces, WithName.TypeName, WithLifetime.Transient);
            config.DependencyResolver = new UnityResolver(container);

            //config.Filters.Add(new UnhandledExceptionFilter());
        }
    }
}