﻿using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms
{
    public class CogPatternMatching : CogVision
    {
        #region 필드
        public CogPMAlignTool MatchingTool { get; set; }
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
        public CogPMAlignTool SetTrainRegion(CogRectangle roi)
        {
            if(MatchingTool.Pattern.Trained == false)
            {
                CogRectangle rect = new CogRectangle(roi);

                MatchingTool.Pattern.Origin.TranslationX = rect.CenterX;
                MatchingTool.Pattern.Origin.TranslationY = rect.CenterY;
                MatchingTool.Pattern.TrainRegion = rect;
                MatchingTool.CurrentRecordEnable = CogPMAlignCurrentRecordConstants.TrainImage |
                                                        CogPMAlignCurrentRecordConstants.TrainRegion |
                                                        CogPMAlignCurrentRecordConstants.PatternOrigin;
            }
            
            return MatchingTool;
        }

        public CogPMAlignTool SetSearchRegion(CogRectangle roi)
        {
            CogRectangle rect = new CogRectangle(roi);
            rect.Color = CogColorConstants.Green;
            rect.LineStyle = CogGraphicLineStyleConstants.Dot;
            MatchingTool.SearchRegion = new CogRectangle(rect);
            MatchingTool.CurrentRecordEnable = CogPMAlignCurrentRecordConstants.InputImage |
                                                  CogPMAlignCurrentRecordConstants.SearchRegion;
            return MatchingTool;
        }

        public ICogRegion GetTrainRegion()
        {
            return MatchingTool.Pattern.TrainRegion;
        }

        public ICogRegion GetSearchRegion()
        {
            return MatchingTool.SearchRegion;
        }

        public bool Train(ICogImage image)
        {
            if (image == null)
                return false;

            MatchingTool.Pattern.TrainImage = image;
            MatchingTool.Pattern.Train();

            return true;
        }

        public bool IsTrained()
        {
            return MatchingTool.Pattern.Trained;
        }

        public void Find()
        {

        }
        #endregion
    }
}