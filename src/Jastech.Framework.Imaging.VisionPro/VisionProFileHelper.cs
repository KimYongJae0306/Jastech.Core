using Cognex.VisionPro;
using Jastech.Framework.Util.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro
{
    public static class VisionProFileHelper
    {

        public static void SaveTool<T>(string path, T tool)
        {
            CogSerializer.SaveObjectToFile(tool, path,
                                        typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter),
                                         CogSerializationOptionsConstants.ExcludeDataBindings);
        }

        public static object LoadTool(string path)
        {
            try
            {
                return CogSerializer.LoadObjectFromFile(path);
            }
            catch (Exception)
            {
                Logger.Error(ErrorType.Etc, "Cognex Liscense not found.");
                return null;
            }
            
        }
    }
}
