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
        public double ResizeRatio { get; set; } = 1.0;

        [JsonProperty]
        public int SliceCount { get; set; } = 50;

        [JsonProperty]
        public AkkonFilterDir FilterDir { get; set; } = AkkonFilterDir.Vertical;

        [JsonProperty]
        public AkkonThresholdParam ThresParam { get; set; } = new AkkonThresholdParam();

        [JsonProperty]
        public ResultFilter ResultFilter { get; set; } = new ResultFilter();

        [JsonProperty]
        public DrawParam DrawOption { get; set; } = new DrawParam();

        [JsonProperty]
        public string CurrentFilterName { get; set; } = "";

        [JsonProperty]
        private List<AkkonImageFilterParam> ImageFilters { get; set; } = new List<AkkonImageFilterParam>();
        #endregion

        #region 메서드
        public void AddImageFilter(AkkonImageFilterParam filter)
        {
            ImageFilters.Add(filter);
        }

        public int GetImageFilterCount()
        {
            return ImageFilters.Count();
        }

        public AkkonImageFilterParam GetImageFilter(string name)
        {
            foreach (var filter in ImageFilters)
            {
                if (filter.Name == name)
                    return filter;
            }
            return null;
        }

        public List<AkkonImageFilterParam> GetImageFilter()
        {
            return ImageFilters;
        }

        public void DeleteFilter(string name)
        {
            List<AkkonImageFilterParam> removeFilters = new List<AkkonImageFilterParam>();
            foreach (var filter in ImageFilters)
            {
                if (filter.Name == name)
                    removeFilters.Add(filter);
            }
            ImageFilters.RemoveAll(removeFilters.Contains);
        }

        public AkkonImageFilterParam GetCurrentFilter()
        {
            return GetImageFilter(CurrentFilterName);
        }

        public void AddMacronFilter()
        {
            // ImageFilter가 없을 경우만 호출
            // 기존 메크론 Filter 추가하는 부분

            if(GetImageFilter("Filter2_M") == null)
            {
                AkkonImageFilterParam filter2 = new AkkonImageFilterParam
                {
                    Name = "Filter2_M",
                    Sigma = 2,
                    GusWidth = 8,
                    LogWidth = 16,
                    ScaleFactor = 1.3,
                };
                ImageFilters.Add(filter2);
            }
           
            if(GetImageFilter("Filter4_M") == null)
            {
                AkkonImageFilterParam filter4 = new AkkonImageFilterParam
                {
                    Name = "Filter4_M",
                    Sigma = 1.5,
                    GusWidth = 6,
                    LogWidth = 12,
                    ScaleFactor = 2,
                };
                ImageFilters.Add(filter4);
            }
        }

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
                ImageFilters.Add(filter);
            }
            CurrentFilterName = "User Filter";
        }
        #endregion
    }

    public class ResultFilter
    {
        [JsonProperty]
        public double MinSize { get; set; } = 0;

        [JsonProperty]
        public double MaxSize { get; set; } = 100.0;
    }

    public class DrawParam
    {
        [JsonProperty]
        public bool ContainLeadROI { get; set; } = false;

        [JsonProperty]
        public bool ContainLeadCount { get; set; } = false;

        [JsonProperty]
        public bool ContainNG { get; set; } = false;
    }

    public class AkkonThresholdParam
    {
        [JsonProperty]
        public double Weight { get; set; } = 1.0;

        [JsonProperty]
        public AkkonThMode Mode { get; set; } = AkkonThMode.White;
    }

    public enum AkkonFilterDir
    {
        Vertical,
        Horizontal,
    }
}
