using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Comm
{
    public class SerialPortInfo
    {
        #region 속성
        [JsonProperty]
        public string PortName { get; set; } = "COM1";

        [JsonProperty]
        public string Description { get; set; } = "";

        [JsonProperty]
        public int BaudRate { get; set; } = 9600;

        [JsonProperty]
        public StopBits StopBits { get; set; } = StopBits.One;

        [JsonProperty]
        public Parity Parity { get; set; } = Parity.None;

        [JsonProperty]
        public int DataBits { get; set; } = 8;

        [JsonProperty]
        public Handshake Handshake { get; set; } = Handshake.None;

        [JsonProperty]
        public bool RtsEnable { get; set; }

        [JsonProperty]
        public bool DtrEnable { get; set; }

        public int PortNo
        {
            get
            {
                if (!string.IsNullOrEmpty(PortName))
                    return int.Parse(string.Join("", PortName.Where(char.IsDigit)));
                else
                    return 0;
            }
        }
        #endregion
    }
}
