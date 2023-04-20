using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Macron.Akkon.Parameters
{
    public class MacronAkkonGroup
    {
        #region 속성
        [JsonProperty]
        public int Index { get; set; }

        [JsonProperty]
        public int Count { get; set; } = 273;

        [JsonProperty]
        public double Threshold { get; set; } = 100;

        [JsonProperty]
        public double Pitch { get; set; } = 70.0;  //um

        [JsonProperty]
        public double Width { get; set; } = 50.0;// um

        [JsonProperty]
        public double Height { get; set; } = 100.0;// um

        [JsonProperty]
        public MacronAkkonParam MacronAkkonParam { get; set; } = new MacronAkkonParam();

        [JsonProperty]
        public List<AkkonROI> AkkonROIList { get; private set; } = new List<AkkonROI>();
        #endregion

        #region 메서드
        public MacronAkkonGroup DeepCopy()
        {
            return JsonConvertHelper.DeepCopy(this) as MacronAkkonGroup;
        }

        public void AddROI(AkkonROI roi)
        {
            AkkonROIList.Add(roi);
        }

        public void DeleteROI(int index)
        {
            AkkonROIList.RemoveAt(index);
        }
        #endregion
    }
}
