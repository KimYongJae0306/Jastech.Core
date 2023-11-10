using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.LightCtrls.Darea.Parser
{
    public interface IDareaParser
    {
        int Channel { get; set; }

        int Value { get; set; }

        void Serialize(out byte[] data);
    }
}
