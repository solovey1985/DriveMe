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
        }
    }
}
