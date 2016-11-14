using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.WebApi;


namespace Bigly.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterTypes(AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled);

            Debug.WriteLine("Container has {0} Registrations:", container.Registrations.Count());
            foreach (ContainerRegistration item in container.Registrations)
            { Debug.WriteLine($"{item.RegisteredType.Name}->{item.MappedToType.Name}"); }
            GlobalConfiguration.Configuration.DependencyResolver = new  UnityDependencyResolver(container);
        }
    }
}