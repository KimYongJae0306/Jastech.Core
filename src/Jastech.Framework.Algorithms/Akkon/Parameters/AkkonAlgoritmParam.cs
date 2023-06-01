using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Jastech.Framework.Algorithms.Akkon.AkkonAlgorithm;

namespace Jastech.Framework.Algorithms.Akkon.Parameters
{
    public class AkkonAlgoritmParam
    {
        #region 속성
        [JsonProperty]
        public AkkonAlgoritmType AkkonAlgoritmType { get; set; } = AkkonAlgoritmType.OpenCV;

        [JsonProperty]
        public AkkonImagingParam ImageFilterParam { get; set; } = new AkkonImagingParam();

        [JsonProperty]
        public AkkonResultFilterParam ResultFilterParam { get; set; } = new AkkonResultFilterParam();

        [JsonProperty]
        public AkkonJudgementParam JudgementParam { get; set; } = new AkkonJudgementParam();

        [JsonProperty]
        public DrawParam DrawOption { get; set; } = new DrawParam();
        #endregion

        #region 메서드
      
        public void Initalize()
        {
            ImageFilterParam.Initalize();
        }

        public void Dispose()
        {
            ImageFilterParam.ClearFilter();
        }

        //public int GetImageFilterCount()
        //{
        //    return ImageFilterParam.Filters.Count();
        //}

        //public void AddMacronFilter()
        //{
        //    ImageFilterParam.AddMacronFilter();
        //}

        //public AkkonImageFilterParam GetCurrentFilter()
        //{
        //    return ImageFilterParam.GetCurrentFilter();
        //}
        #endregion
    }

    public class AkkonResultFilterParam
    {
        [JsonProperty]
        public int Grouping { get; set; } = 3;

        [JsonProperty]
        public double MinArea { get; set; } = 3;

        [JsonProperty]
        public double MaxArea { get; set; } = 100.0;

        [JsonProperty]
        public double MaxWidth { get; set; } = 100.0;

        [JsonProperty]
        public double MaxHeight { get; set; } = 100.0;

        [JsonProperty]
        public double AkkonStrength { get; set; } = 5.0;

        [JsonProperty]
        public double AkkonStrengthScaleFactor { get; set; } = 1.0;
    }

    public class AkkonJudgementParam
    {
        [JsonProperty]
        public int AkkonCount { get; set; } = 30;

        [JsonProperty]
        public double LengthX { get; set; } = 10.0;

        [JsonProperty]
        public double LengthY { get; set; } = 10.0;

        [JsonProperty]
        public double LeadStdDev { get; set; } = 1.0;
    }

    public class DrawParam
    {
        [JsonProperty]
        public bool ContainLeadROI { get; set; } = false;

        [JsonProperty]
        public bool ContainLeadCount { get; set; } = false;

        [JsonProperty]
        public bool ContainNG { get; set; } = false;

        [JsonProperty]
        public bool ContainArea { get; set; } = false;

        [JsonProperty]
        public bool ContainStrength { get; set; } = false;
    }

    public class AkkonImagingParam
    {
        [JsonProperty]
        public double ResizeRatio { get; set; } = 1.0;

        [JsonProperty]
        public int SliceCount { get; set; } = 50;

        [JsonProperty]
        public AkkonFilterDir FilterDir { get; set; } = AkkonFilterDir.Vertical;

        [JsonProperty]
        public double Weight { get; set; } = 1.0;

        [JsonProperty]
        public AkkonThMode Mode { get; set; } = AkkonThMode.White;

        [JsonProperty]
        public List<AkkonImageFilterParam> Filters { get; set; } = new List<AkkonImageFilterParam>();

        [JsonProperty]
        public string CurrentFilterName { get; set; } = "";

        public void Initalize()
        {
            if (GetImageFilter("User Filter") == null)
            {
                AkkonImageFilterParam filter = new AkkonImageFilterParam
                {
                    Name = "User Filter",
                    Sigma = 2,
                    GusWidth = 8,
                    LogWidth = 16,
                    ScaleFactor = 1.3,
                };
                Filters.Add(filter);
            }
            CurrentFilterName = "User Filter";
        }

        public AkkonImageFilterParam GetImageFilter(string name)
        {
            foreach (var filter in Filters)
            {
                if (filter.Name == name)
                    return filter;
            }
            return null;
        }

        public void DeleteFilter(string name)
        {
            List<AkkonImageFilterParam> removeFilters = new List<AkkonImageFilterParam>();
            foreach (var filter in Filters)
            {
                if (filter.Name == name)
                    removeFilters.Add(filter);
            }
            Filters.RemoveAll(removeFilters.Contains);
        }

        public AkkonImageFilterParam GetCurrentFilter()
        {
            return GetImageFilter(CurrentFilterName);
        }

        public void AddMacronFilter()
        {
            // ImageFilter가 없을 경우만 호출
            // 기존 메크론 Filter 추가하는 부분

            if (GetImageFilter("Filter2_M") == null)
            {
                AkkonImageFilterParam filter2 = new AkkonImageFilterParam
                {
                    Name = "Filter2_M",
                    Sigma = 2,
                    GusWidth = 8,
                    LogWidth = 16,
                    ScaleFactor = 1.3,
                };
                Filters.Add(filter2);
            }

            if (GetImageFilter("Filter4_M") == null)
            {
                AkkonImageFilterParam filter4 = new AkkonImageFilterParam
                {
                    Name = "Filter4_M",
                    Sigma = 1.5,
                    GusWidth = 6,
                    LogWidth = 12,
                    ScaleFactor = 2,
                };
                Filters.Add(filter4);
            }
        }

        public void ClearFilter()
        {
            Filters.Clear();
        }
    }

    public enum AkkonFilterDir
    {
        Vertical,
        Horizontal,
    }
}
