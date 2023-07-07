using System;
using static Jastech.Framework.Config.Config;

namespace Jastech.Framework.Config
{
    public class ConfigSet
    {
        #region 필드
        private static ConfigSet _instance = null;
        #endregion

        #region 속성
        public PathConfig Path { get; private set; } = new PathConfig();

        public OperationConfig Operation { get; private set; } = new OperationConfig();

        public MachineConfig Machine { get; private set; } = new MachineConfig();


        #endregion

        #region 이벤트
        public event ConfigCreatedEventHandler<PathConfig> PathConfigCreated;

        public event ConfigCreatedEventHandler<OperationConfig> OperationConfigCreated;

        public event ConfigCreatedEventHandler<MachineConfig> MachineConfigCreated;
        #endregion

        #region 메서드
        public static ConfigSet Instance()
        {
            if (_instance == null)
            {
                _instance = new ConfigSet();
            }

            return _instance;
        }

        public void Initialize()
        {
            string curDir = Environment.CurrentDirectory;
            string configPath = $"{curDir}\\..\\Config";

            Path.Load(configPath, PathConfigCreated);
            Operation.Load(configPath, OperationConfigCreated);
            Machine.Load(configPath, MachineConfigCreated);
        }

        public void Save()
        {
            string curDir = Environment.CurrentDirectory;
            string configPath = $"{curDir}\\..\\Config";

            Path.Save(configPath);
            Operation.Save(configPath);
            Machine.Save(configPath);
        }
            
        public void Load()
        {
            string curDir = Environment.CurrentDirectory;
            string configPath = $"{curDir}\\..\\Config";

            Path.Load<PathConfig>(configPath);
            Path.Load<OperationConfig>(configPath);
            Path.Load<MachineConfig>(configPath);
        }
        #endregion
    }
}
