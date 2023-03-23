using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro
{
    public static class CogFileHelper
    {

        public static void SaveTool<T>(string path, T tool)
        {
            CogSerializer.SaveObjectToFile(tool, path,
                                        typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter),
                                         CogSerializationOptionsConstants.ExcludeDataBindings);
        }

        public static object LoadTool(string path)
        {
            return CogSerializer.LoadObjectFromFile(path);
        }
    }
}
