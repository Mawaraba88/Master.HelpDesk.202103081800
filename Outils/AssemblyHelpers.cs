using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Outils
{
   public static class AssemblyHelpers
    {
        public static string GetDirectoryForAssembyl(Assembly assembly)
        {
            var assemblyLocation = assembly.CodeBase;
            var location = new UriBuilder(assemblyLocation);
            var path = Uri.UnescapeDataString(location.Path);
            var directory = Path.GetDirectoryName(path);
            return directory;
        }
    }
}
