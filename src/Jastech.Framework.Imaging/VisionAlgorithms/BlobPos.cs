using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionAlgorithms
{
    public class BlobPos
    {
        [JsonProperty]
        public Rectangle BoundingRect;

        [JsonProperty]
        public List<Point> Points = new List<Point>();

        [JsonProperty]
        public double Area { get; set; } = 0.0;

        [JsonProperty]
        public double CenterX { get; set; } = 0.0;

        [JsonProperty]
        public double CenterY { get; set; } = 0.0;

        [JsonProperty]
        public bool IsPass { get; set; } = false;

        public virtual void Dispose()
        {

        }

        public virtual BlobPos DeepCopy()
        {
            BlobPos blob = new BlobPos();
            blob.BoundingRect = new Rectangle(BoundingRect.X, BoundingRect.Y, BoundingRect.Width, BoundingRect.Height);
            blob.Area = Area;
            blob.CenterX = CenterX;
            blob.CenterY = CenterY;

            List<Point> tempList = new List<Point>();
            foreach (var p in Points)
                tempList.Add(new Point(p.X, p.Y));

            blob.Points = tempList;

            return blob;
        }
    }
}
