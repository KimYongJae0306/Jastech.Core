using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.LightCtrls.Lvs.Parser
{
    public interface ILvsParser
    {
        byte OpMode { get; set; }

        byte DataLength { get; set; }

        byte Address { get; set; }

        byte Value { get; set; }

        void Serialize(out byte[] data);
    }
}
