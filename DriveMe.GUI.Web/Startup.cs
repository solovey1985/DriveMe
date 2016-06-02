using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.Owin;
using DriveMe.GUI.Web.Utils;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DriveMe.GUI.Web.Startup))]
namespace DriveMe.GUI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly, Assembly.GetExecutingAssembly());
            var pluginFolder = new DirectoryInfo(HostingEnvironment.MapPath("~/bin"));
            var pluginAssemblyFiles = pluginFolder.GetFiles("*.dll", SearchOption.AllDirectories);
            foreach (var pluginAssemblyFile in pluginAssemblyFiles)
            {
                var asm = Assembly.LoadFrom(pluginAssemblyFile.FullName);
                builder.RegisterAssemblyTypes(asm).Where(a=>a.Assembly.FullName.StartsWith("DriveMe")) .AsImplementedInterfaces();
            }
            
            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
 
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
        }
    }
}
