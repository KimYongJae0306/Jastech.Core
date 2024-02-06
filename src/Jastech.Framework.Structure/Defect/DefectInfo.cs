using System;
using System.Collections.Generic;
using System.Drawing;
using static Jastech.Framework.Structure.Defect.DefectDefine;

namespace Jastech.Framework.Structure.Defect
{
    public abstract class DefectInfo
    {

        #region 필드
        private readonly Dictionary<FeatureTypes, object> _defectFeatures = new Dictionary<FeatureTypes, object>();

        private readonly Dictionary<FeatureTypes, Type> _defectFeatureDatatypes = new Dictionary<FeatureTypes, Type>();
        #endregion

        #region 속성
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        #endregion

        public int Index { get; set; }

        public DateTime InspectionTime { get; set; }

        public string CameraName { get; set; }

        public int DefectLevel { get; set; }

        public string Judgement { get; set; }

        public DefectTypes DefectType { get; set; }

        public abstract PointF GetCoord();

        public abstract SizeF GetSize();

        public virtual dynamic GetFeatureValue(FeatureTypes featureType)
        {
            var result = ConvertFeature(_defectFeatures[featureType], _defectFeatureDatatypes[featureType]);
            if (result is bool && result == false)
                return null;
            return result;
        }

        public virtual void SetFeatureValue(FeatureTypes featureType, object value)
        {
            _defectFeatures[featureType] = value;
        }

        public virtual void SetFeatureDataType(FeatureTypes featureType, Type value)
        {
            _defectFeatureDatatypes[featureType] = value;
        }
    }

    public static class DefectDefine
    {
        public static dynamic ConvertFeature(object value, Type type)
        {
            dynamic result = null;
            try
            {
                result = Convert.ChangeType(value, type);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine($"GetFeatureValue({value}, {type}) => Trying Invalid Cast, Check the datatype");
                return false;
            }

            return result;
        }

        public static Dictionary<DefectTypes, Color> Colors = new Dictionary<DefectTypes, Color>
        {
            { DefectTypes.Undefined, Color.Red },
            // 표면 형상계 (극판)
            { DefectTypes.PinHole, Color.DodgerBlue},
            { DefectTypes.Crater, Color.DodgerBlue},
            { DefectTypes.Dent, Color.White},
            { DefectTypes.Island, Color.Orange},
            { DefectTypes.Drag, Color.Lime},
            { DefectTypes.Mismatch, Color.Red},
        };

        public enum FeatureTypes
        {
            X,                      // X좌표
            Y,                      // Y좌표
            Width,                  // 너비
            Height,                 // 높이
            Area,                   // 면적
            Circularity,            // 원형도
            Eccentricity,           // 편심도
            Brightness,             // 밝기
            AspectRatio,            // 종횡비
            Elongation,             // 연장도
            Solidity,               // 결속도
            NeighborPixels,         // 인접 픽셀
            Kurtosis,               // 분포 첨도
            EdgeDensity,            // 가장자리 밀도
            Compactness,            // 조밀도
            Skewness,               // 비대칭도
            Gabor,                  // Gabor 기반 질감
            Fourier,                // 푸리에 변환
            Wavelet,                // 웨이블릿 변환
            IntensityHistogram,     // GrayLevel 히스토그램
            ColorHistogram,         // Channel별 히스토그램(Color 이미지일 때)

            LocalImagePath,
        }
        public enum DefectTypes
        {
            Undefined,
            PinHole,
            Crater,
            Dent,
            Island,
            Drag,
            Mismatch,

            //// 흑,백계 (Pixel)
            //DarkLine,           // 흑선
            //DarkPoint,          // 흑점
            //BrightLine,         // 백선
            //BrightPoint,        // 백점
            //DimLine,            // 점멸선
            //Crack,              // 균열

            //// 이물계
            //Dust,               // 먼지
            //Labeling,           // 라벨링
            //Fingerprint,        // 지문
            //Tape,               // 테이프

            //// 색감계
            //WhiteStain,         // 백얼룩
            //WhiteSpot,          // 백점
            //DarkStain,         // 백얼룩
            //DarkSpot,           // 흑점
            //RedLine,            // 적선
            //RedSpot,            // 적점
            //GreenLine,          // 녹선
            //GreenSpot,          // 녹점
            //BlueLine,           // 청선
            //BlueSpot,           // 청점
            //Bruise,             // 멍
            //ColorDifference,    // 색감차

            //// 표면 형상계
            //Scratch,            // 긁힘
            //Infiltration,       // 침투 (습기 등)
            //Blister,            // 물집
            //Bubble,             // 기포
            //Coating,            // 코팅 이상
            //Tear,               // 찢김
            //Pattern,            // 무늬
            //Press,              // 압착 이상
            //Wrinkle,            // 주름
        }
    }
}
