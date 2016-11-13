using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace Bigly.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterTypes(
                AllClasses.FromAssembliesInBasePath(), 
                WithMappings.FromMatchingInterface,
                WithName.TypeName, 
                WithLifetime.ContainerControlled);
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}