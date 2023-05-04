using Cognex.VisionPro;
using Jastech.Framework.Imaging.Result;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results
{
    public class CogPatternMatchingResult : VisionResult
    {
        #region 속성
        [JsonProperty]
        public long TactTime { get; set; }

        [JsonProperty]
        public List<PatternMatchPos> MatchPosList { get; set; } = new List<PatternMatchPos>();

        [JsonProperty]
        public bool Found
        {
            get => MatchPosList.Count() > 0;
        }

        [JsonProperty]
        public float MaxScore
        {
            get => MatchPosList.Max(x => x.Score);
        }

        [JsonProperty]
        public PatternMatchPos MaxMatchPos
        {
            get
            {
                PatternMatchPos maxMatchPos = new PatternMatchPos();
                foreach (PatternMatchPos matchPos in MatchPosList)
                {
                    if (matchPos.Score > maxMatchPos.Score)
                        maxMatchPos = matchPos;
                }
                return maxMatchPos;
            }
        }
        #endregion
    }

    public class PatternMatchPos
    {
        #region 속성
        [JsonProperty]
        public PointF ReferencePos { get; set; }

        [JsonProperty]
        public float ReferenceWidth { get; set; }

        [JsonProperty]
        public float ReferenceHeight { get; set; }

        [JsonProperty]
        public PointF FoundPos { get; set; }

        [JsonProperty]
        public float Score { get; set; }

        [JsonProperty]
        public float Scale { get; set; }

        [JsonProperty]
        public double Angle { get; set; }

        [JsonIgnore]
        public CogCompositeShape ResultGraphics { get; set; }
        #endregion

        #region 메서드
        public PointF TranslateOffset()
        {
            return new PointF(ReferencePos.X - FoundPos.X, ReferencePos.Y - FoundPos.Y);
        }
        #endregion
    }
}
