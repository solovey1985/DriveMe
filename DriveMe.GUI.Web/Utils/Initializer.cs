using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;

namespace DriveMe.GUI.Web.Utils
{
 
        public static class Initializer
        {
            public static void Initialize()
            {
                var pluginFolder = new DirectoryInfo(HostingEnvironment.MapPath("~/bin"));
                var pluginAssemblyFiles = pluginFolder.GetFiles("*.dll", SearchOption.AllDirectories);
                foreach (var pluginAssemblyFile in pluginAssemblyFiles)
                {
                    var asm = Assembly.LoadFrom(pluginAssemblyFile.FullName);
                    BuildManager.AddReferencedAssembly(asm);
                }
            }
        }
    }
