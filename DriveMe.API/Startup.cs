using System.IO;
using System.Reflection;
using System.Web.Hosting;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;

using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;

//[assembly: OwinStartup(typeof(DriveMe.API.Startup))]

namespace DriveMe.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var pluginFolder = new DirectoryInfo(HostingEnvironment.MapPath("~/bin"));
            var pluginAssemblyFiles = pluginFolder.GetFiles("*.dll", SearchOption.AllDirectories);
            foreach (var pluginAssemblyFile in pluginAssemblyFiles)
            {
                var asm = Assembly.LoadFrom(pluginAssemblyFile.FullName);
                builder.RegisterAssemblyTypes(asm).Where(a=>a.Assembly.FullName.StartsWith("DriveMe")) .AsImplementedInterfaces();
            }
            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            /**/
            ConfigureAuth(app);
        }
    }
}
