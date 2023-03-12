using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.FrameWork.Config
{
    public class PathConfig : Config
    {
        #region 속성
        [JsonProperty]
        public string Model { get; private set; }

        [JsonProperty]
        public string Image { get; private set; }

        [JsonProperty]
        public string Result { get; private set; }

        [JsonProperty]
        public string Log { get; private set; }

        [JsonProperty]
        public string Config { get; private set; }
        #endregion

        #region 생성자
        public PathConfig()
        {
            string curDir = Environment.CurrentDirectory;

            Model = Path.GetFullPath("..\\Model");
            Image = Path.GetFullPath("..\\Image");
            Result = Path.GetFullPath("..\\Result");
            Log = Path.GetFullPath("..\\Log");
            Config = Path.GetFullPath("..\\Config");
        }
        #endregion

        #region 메서드
        public void CreateDirectory()
        {
            if (!Directory.Exists(Model))
            {
                Directory.CreateDirectory(Model);
            }
            if (!Directory.Exists(Image))
            {
                Directory.CreateDirectory(Image);
            }
            if (!Directory.Exists(Result))
            {
                Directory.CreateDirectory(Result);
            }
            if (!Directory.Exists(Log))
            {
                Directory.CreateDirectory(Log);
            }
            if (!Directory.Exists(Config))
            {
                Directory.CreateDirectory(Config);
            }
        }
        #endregion

    }
}
