using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.LightCtrls.Lvs.Parser
{
    public class LvsSerialParser : ILvsParser
    {
        public byte OpMode { get; set; }

        public byte DataLength { get; set; }

        public byte Address { get; set; }

        public byte Value { get; set; }

        public void Serialize(out byte[] data)
        {
            data = null;
            data = new byte[4];
            data[0] = OpMode;
            data[1] = DataLength;
            data[2] = Address;
            data[3] = Value;
        }
    }
}
