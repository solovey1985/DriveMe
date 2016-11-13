using System.IO;
using System.Reflection;
using System.Web.Hosting;
using System.Web.Http;
using Bigly.API;
using Microsoft.Owin;
using Owin;

//[assembly: OwinStartup(typeof(Startup))]

namespace Bigly.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
