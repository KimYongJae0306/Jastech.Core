using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Plcs.Melsec.Parsers
{
    public enum ParserType
    {
        Binary,
        Ascii
    }

    public interface IMelsecParser
    {
        #region 속성
        MessageType MessageType { get; set; }

        ParserType ParserType { get; set; }

        string AddressName { get; set; }

        short Command { get; set; }

        short SubCommand { get; set; }

        int DataLength { get; set; }

        byte NetworkNo { get; }

        byte PlcNo { get; }

        short ModuleIoNo { get; }

        byte ModuleDeviceNo { get; }

        short CpuInspectorData { get; }

        int HeaderSize { get; }
        #endregion

        #region 메서드
        void Parse(byte[] unformattedPacket, out byte[] data);

        void Serialize(byte[] data, out byte[] unformattedPacket);
        #endregion
    }
}
