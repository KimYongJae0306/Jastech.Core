using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Jastech.Framework.Device
{
    public class DeviceHandler<T> : IEnumerable<T> where T : class, IDevice
    {
        #region 속성
        [JsonProperty]
        protected List<T> Devices { get; private set; } = new List<T>();

        public int Count { get => Devices.Count; }
        #endregion

        #region 메서드
        public IEnumerator<T> GetEnumerator()
        {
            return Devices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Devices.GetEnumerator();
        }

        public T First()
        {
            if (Count == 0)
                return null;

            return Devices.First();
        }

        public T Get(int index)
        {
            if (index < 0 || index >= Count)
                return null;

            return Devices[index];
        }

        public T Get(string name)
        {
            var candidate = Devices.Where((c) => c.Name == name).ToList();
            if (candidate.Count == 0)
                return null;

            return candidate.First();
        }

        public void Add(T device)
        {
            if (Devices.Contains(device))
                return;

            Devices.Add(device);
        }

        public bool Initialize()
        {
            bool success = true;
            foreach (var device in Devices)
            {
                success &= device.Initialize();
            }
            return success;
        }

        public bool Release()
        {
            bool success = true;
            foreach (var device in Devices)
            {
                success &= device.Release();
            }
            return success;
        }
        #endregion
    }
}
