using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SMTPRORAM
{
    class ResourceManager
    {
        public static bool resourceExists { get; set; } = false;
        private static Stream resourceStream { get; set; }
        public static void GetResourceInfo(string fileNameWithExtension, string pathToResource)
        {
            //Substitut this with your Project Name
            //Class Library Name AssistantLib >  Resources > AssistantLib.dll 
            //const string pathToResource = "SMTPRORAM";

            //The Dll that you want to Load
            var assembly = Assembly.GetExecutingAssembly();
            //var names = assembly.GetManifestResourceNames();
            Stream stream = assembly.GetManifestResourceStream($"{pathToResource}.{fileNameWithExtension}");
            if (stream == null)
                return;
            resourceExists = true;
            resourceStream = stream;
        }

        public static void LoadResource(string newFileNameWithExtension)
        {
            if (File.Exists(newFileNameWithExtension))
            {
                //Console.WriteLine("File already exists");
                return;
            }
            using (Stream s = File.Create(newFileNameWithExtension))
            {
                //Console.WriteLine("Loading file");
                resourceStream.CopyTo(s);
            }
        }
    }
}
