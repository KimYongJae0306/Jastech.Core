using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.LightCtrls.Darea.Parser
{
    public class DareaSerialParser : IDareaParser
    {
        public int Channel { get; set; }

        public int Value { get; set; }

        public void Serialize(out byte[] data)
        {
            // 형식 -> [CCVVV
            // CC : Chanel, VVV : Value
            data = null;

            string value = "";

            value += "[";
            value += Channel.ToString("D2");
            value += CheckValue().ToString("D3");

            data = Encoding.UTF8.GetBytes(value);
        }

        private int CheckValue()
        {
            if (Value < 0)
                return 0;
            else if (Value > 255)
                return 255;

            return Value;
        }
    }
}
