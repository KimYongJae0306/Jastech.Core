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
        [JsonProperty]
        public int Index { get; set; }

        [JsonProperty]
        public int Count { get; set; } = 273;

        [JsonProperty]
        public double Pitch { get; set; } = 70.0;  //um

        [JsonProperty]
        public double Width { get; set; } = 50.0;// um

        [JsonProperty]
        public double Height { get; set; } = 100.0;// um

        [JsonProperty]
        public MacronAkkonParam MacronAkkonParam { get; set; } = new MacronAkkonParam();

        public MacronAkkonGroup DeepCopy()
        {
            //MacronAkkonGroup param = new MacronAkkonGroup();

            //param.Index = Index;
            //param.Count = Count;
            //param.Pitch = Pitch;
            //param.Width = Width;
            //param.Height = Height;
            //param.MacronAkkonParam = new MacronAkkonParam();

            //return param;
            return JsonConvertHelper.DeepCopy(this) as MacronAkkonGroup;
        }
    }
}
