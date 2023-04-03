using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Structure
{
    public class InspModel
    {
        [JsonProperty]
        public string Name { get; set; } = "New Model";

        [JsonProperty]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [JsonProperty]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        [JsonProperty]
        public string Description { get; set; } = "";

        public static string FileName { get; } = "InspModel.json";

        [JsonProperty]
        public List<TeachingPosition> PositionList { get; set; } = new List<TeachingPosition>();

        public void AddTeachingPosition(TeachingPosition position)
        {
            PositionList.Add(position);
        }
    }
}
