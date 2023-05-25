using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionAlgorithms.Parameters
{
    public class BlobParam
    {
        [JsonProperty]
        public List<Point> Points { get; set; } = new List<Point>();

        [JsonProperty]
        public double CenterX { get; set; }

        [JsonProperty]
        public double CenterY { get; set; }

        [JsonProperty]
        public double Area { get; set; }

        [JsonProperty]
        public RectangleF BoundingRect { get; set; }
    }
}
