﻿using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Jastech.Framework.Algorithms.Akkon.Parameters
{
    public class AkkonGroup
    {
        #region 속성
        [JsonProperty]
        public int Index { get; set; }

        [JsonProperty]
        public int UnitIndex { get; set; }

        [JsonProperty]
        public int TabIndex { get; set; }

        [JsonProperty]
        public int Count { get; set; } = 273;

        [JsonProperty]
        public double Threshold { get; set; } = 100;

        [JsonProperty]
        public double Pitch { get; set; } = 46.0;  //um

        [JsonProperty]
        public double Width { get; set; } = 28.0;// um

        [JsonProperty]
        public double Height { get; set; } = 100.0;// um

        [JsonProperty]
        public List<AkkonROI> AkkonROIList { get; private set; } = new List<AkkonROI>();
        #endregion

        #region 메서드
        public AkkonGroup DeepCopy()
        {
            return JsonConvertHelper.DeepCopy(this) as AkkonGroup;
        }

        public void AddROI(AkkonROI roi)
        {
            AkkonROIList.Add(roi);
        }

        public void DeleteROI(int index)
        {
            if (AkkonROIList.Count > 0)
                AkkonROIList.RemoveAt(index);
        }

        public void Dispose()
        {
            AkkonROIList.Clear();
        }
        #endregion
    }
}
