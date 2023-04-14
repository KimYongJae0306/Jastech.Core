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
        public int Count { get; set; }

        [JsonProperty]
        public double Pitch { get; set; }   //um

        [JsonProperty]
        public double Width { get; set; } // um

        [JsonProperty]
        public double Height { get; set; } // um

        [JsonProperty]
        public MacronAkkonParam MacronAkkonParam { get; set; } = new MacronAkkonParam();

        public MacronAkkonGroup DeepCopy()
        {
            MacronAkkonGroup param = new MacronAkkonGroup();

            param.Index = Index;
            param.Count = Count;
            param.Pitch = Pitch;
            param.Width = Width;
            param.Height = Height;
            param.MacronAkkonParam = new MacronAkkonParam();

            return param;
        }
    }
}
