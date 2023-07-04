using Jastech.Framework.Device;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Jastech.Framework.Config
{
    public class MachineConfig : Config
    {
        #region 속성
        [JsonProperty]
        public List<IDevice> Devices { get; private set; } = new List<IDevice>();
        #endregion

        #region 메서드
        public void Add(IDevice device)
        {
            if (Devices.Contains(device))
                return;

            Devices.Add(device);
        }

        public ReadOnlyCollection<T> GetDevices<T>() where T : IDevice
        {
            return Devices.Where((d) => d is T).Cast<T>().ToList().AsReadOnly();
        }
        #endregion
    }
}
