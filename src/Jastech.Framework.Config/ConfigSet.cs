using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Jastech.Framework.Config.Config;

namespace Jastech.Framework.Config
{
    public class ConfigSet
    {
        #region 속성
        public PathConfig Path { get; private set; } = new PathConfig();
        #endregion

        #region 이벤트
        public event ConfigCreatedEventHandler<PathConfig> PathConfigCreated;
        #endregion

        #region 메서드
        public void Initialize()
        {
            string curDir = Environment.CurrentDirectory;
            string configPath = $"{curDir}\\..\\Config";

            Path.Load(configPath, PathConfigCreated);
        }

        public void Save()
        {
            string curDir = Environment.CurrentDirectory;
            string configPath = $"{curDir}\\..\\Config";

            Path.Save(configPath);
        }
            
        public bool Load()
        {
            string curDir = Environment.CurrentDirectory;
            string configPath = $"{curDir}\\..\\Config";

            bool success = Path.Load<PathConfig>(configPath);

            return success;
        }
        #endregion

    }
}
