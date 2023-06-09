﻿using Newtonsoft.Json;

namespace Jastech.Framework.Device.Cameras
{
    public interface ICameraTDIavailable
    {
        [JsonProperty]
        TDIOperationMode TDIOperationMode { get; }

        [JsonProperty]
        TDIDirectionType TDIDirection { get; }

        int TDIStages { get; set; }

        void SetTDIOperationMode(TDIOperationMode mode);

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
