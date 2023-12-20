using Jastech.Framework.Util.Helper;
using System.IO;

namespace Jastech.Framework.Config
{
    public class Config
    {
        public delegate void ConfigCreatedEventHandler<T>(T config);

        public void Save(string configDir)
        {
            string fileName = $"{GetType().Name}.cfg";
            string fullPath = Path.Combine(configDir, fileName);
            string dirPath = Path.GetDirectoryName(fullPath);

            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            JsonConvertHelper.Save(fullPath, this);
        }

        internal void Load<T>(string configDir, ConfigCreatedEventHandler<T> ConfigCreated) where T : Config
        {
            var path = Path.Combine(configDir, $"{typeof(T).Name}.cfg");
            if (!File.Exists(path))
            {
                ConfigCreated?.Invoke((T)this);
                Save(configDir);
                return;
            }

            JsonConvertHelper.LoadToExistingTarget(path, this);
        }

        internal bool Load<T>(string configDir) where T : Config
        {
            var path = Path.Combine(configDir, $"{typeof(T).Name}.cfg");
            if (!File.Exists(path))
                return false;
            
            JsonConvertHelper.LoadToExistingTarget(path, this);
            return true;
        }
    }
}
