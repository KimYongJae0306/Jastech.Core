using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.FrameWork.Util.Helper
{
    public static class JsonConvertHelper
    {
        public static void Save(string path, object obj)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.TypeNameHandling = TypeNameHandling.All;

            string content = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, jss);
            File.WriteAllText(path, content);
        }

        public static void LoadToExistingTarget<T>(string path, T target) where T : class
        {
            if (!File.Exists(path))
                return;

            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.TypeNameHandling = TypeNameHandling.Auto;

            string content = File.ReadAllText(path);
            JsonConvert.PopulateObject(content, target, jss);
        }
    }
}
