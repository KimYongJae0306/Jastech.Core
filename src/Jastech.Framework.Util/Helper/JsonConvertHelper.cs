using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Util.Helper
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

        public static object DeepCopy(object obj)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.TypeNameHandling = TypeNameHandling.All;

            string content = JsonConvert.SerializeObject(obj, jss);
            return JsonConvert.DeserializeObject(content, obj.GetType(), jss);
        }

        public static void DeepCopyToExistingTarget<T>(T source, T target) where T : class
        {
            if (source == null)
                return;
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.TypeNameHandling = TypeNameHandling.All;

            string content = JsonConvert.SerializeObject(source, Newtonsoft.Json.Formatting.Indented, jss);
            JsonConvert.PopulateObject(content, target, jss);
        }

    }
}
