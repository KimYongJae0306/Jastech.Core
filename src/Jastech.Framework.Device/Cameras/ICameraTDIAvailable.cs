using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Cameras
{
    public interface ICameraTDIavailable
    {
        [JsonProperty]
        TDIOperationMode TDIOperationMode { get; }

        [JsonProperty]
        TDIDirectionType TDIDirection { get; }

        void SetTDISensorMode(TDIOperationMode mode);

        void SetTDIScanDriection(TDIDirectionType direction);
    }

    public enum TDIOperationMode
    {
        TDI = 0,
        Area = 1,
    }

    //TDI 모드에서만 적용 됨
    public enum TDIDirectionType
    {
        Forward = 0,
        Reverse = 1,
        Line1 = 2,
    }

}
