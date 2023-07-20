using Cognex.VisionPro;
using Cognex.VisionPro.Implementation;
using Cognex.VisionPro.PMAlign;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters;
using Jastech.Framework.Winform.Forms;
using Jastech.Framework.Winform.VisionPro.Forms;
using Jastech.Framework.Winform.VisionPro.Helper;
using System;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogPatternMatchingParamControl : UserControl
    {
        #region 필드
        private VisionProPatternMatchingParam CurrentParam;
        #endregion

        #region 이벤트
        public GetOriginImageDelegate GetOriginImageHandler;

        public TestActionDelegate TestActionEvent;
        #endregion

        #region 델리게이트
        public delegate ICogImage GetOriginImageDelegate();

        public delegate void TestActionDelegate();
        #endregion

        #region 생성자
        public CogPatternMatchingParamControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void lblAddPattern_Click(object sender, EventArgs e)
        {
            if (GetOriginImage() != null)
            {
                if (CurrentParam.GetSearchRegion() == null)
                    return;

                CogDisplayHelper.DisposeDisplay(cogPatternDisplay);

                ICogImage originImage = GetOriginImageHandler();
                if (CurrentParam.Train(originImage))
                {
                    DisposePatternDisplay();
                    cogPatternDisplay.Image = CurrentParam.GetTrainedPatternImage();
                }
                else
                {
                    MessageConfirmForm form = new MessageConfirmForm();
                    form.Message = "Could not train pattern due to lack of features";
                    form.ShowDialog();
                }
            }
        }

        public void UpdateData(VisionProPatternMatchingParam matchingParam)
        {
            if(CurrentParam != null)
            {
                CurrentParam.Score = Convert.ToDouble(nupdnMatchScore.Value);
                CurrentParam.MaxAngle = Convert.ToDouble(nupdnMaxAngle.Value);
            }

            nupdnMatchScore.Value = (decimal)matchingParam.Score;
            nupdnMaxAngle.Value = (decimal)matchingParam.MaxAngle;
            CurrentParam = matchingParam;
            if(CurrentParam.ChangedTrained == null)
            {
                CurrentParam.ChangedTrained += Tool_ChangedTrained;
            }
            cogPatternDisplay.InteractiveGraphics.Clear();
            cogPatternDisplay.StaticGraphics.Clear();

            CogDisplayHelper.DisposeDisplay(cogPatternDisplay);

            if (CurrentParam.IsTrained())
            {
                cogPatternDisplay.Image = null;
                cogPatternDisplay.Image = CurrentParam.GetTrainedPatternImage();
                CogPMAlignCurrentRecordConstants constants = CogPMAlignCurrentRecordConstants.TrainImage |
                                                        CogPMAlignCurrentRecordConstants.TrainImageMask;

                SetStaticGraphics("Masking", CurrentParam.CreateCurrentRecord(constants));
            }
            else
            {
                DisposePatternDisplay();
            }
               
        }

        private void DisposePatternDisplay()
        {
            CogDisplayHelper.DisposeDisplay(cogPatternDisplay);
            cogPatternDisplay.Image = null;
        }

        private void Tool_ChangedTrained(bool isTrained)
        {
            if(isTrained == false)
            {
                DisposePatternDisplay();
            }
        }

        private void SetStaticGraphics(string groupName, ICogRecord record)
        {
            foreach (CogRecord subRecord in record.SubRecords)
            {
                if (typeof(ICogGraphic).IsAssignableFrom(subRecord.ContentType))
                {
                    if (subRecord.Content != null)
                        cogPatternDisplay.StaticGraphics.Add(subRecord.Content as ICogGraphicInteractive, groupName);
                }
                else if (typeof(CogGraphicCollection).IsAssignableFrom(subRecord.ContentType))
                {
                    if (subRecord.Content != null)
                    {
                        CogGraphicCollection graphics = subRecord.Content as CogGraphicCollection;
                        foreach (ICogGraphic graphic in graphics)
                        {
                            cogPatternDisplay.StaticGraphics.Add(graphic as ICogGraphicInteractive, groupName);
                        }
                    }
                }
                else if (typeof(CogGraphicInteractiveCollection).IsAssignableFrom(subRecord.ContentType))
                {
                    if (subRecord.Content != null)
                    {
                        cogPatternDisplay.StaticGraphics.AddList(subRecord.Content as CogGraphicCollection, groupName);
                    }
                }
                SetStaticGraphics(groupName, subRecord);
            }
        }

        public VisionProPatternMatchingParam GetCurrentParam()
        {
            if (CurrentParam == null)
                return null;

            CurrentParam.Score = Convert.ToDouble(nupdnMatchScore.Value);
            CurrentParam.MaxAngle = Convert.ToDouble(nupdnMaxAngle.Value);
            return CurrentParam;
        }

        private ICogImage GetOriginImage()
        {
            if (GetOriginImageHandler != null)
            {
                ICogImage originImage = GetOriginImageHandler();
                return originImage;
            }
            return null;
        }

        public void SetTrainImage(ICogImage image)
        {
            CogDisplayHelper.DisposeDisplay(cogPatternDisplay);
            DisposePatternDisplay();
            cogPatternDisplay.Image = image;
        }

        private void lblMasking_Click(object sender, EventArgs e)
        {
            if (CurrentParam.IsTrained())
            {
                if (GetOriginImage() is ICogImage orginImage)
                {
                    CogAlignMaskingForm form = new CogAlignMaskingForm();
                    form.Initialize(CurrentParam);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        CurrentParam.TrainImageMask(form.GetCurrentParam().GetTrainImageMask());

                        UpdateData(CurrentParam);
                    }
                }
            }
            else
            {
                MessageConfirmForm form = new MessageConfirmForm();
                form.Message = "Not Trained.";
                form.ShowDialog();

            }
        }

        private void nupdnMatchScore_Leave(object sender, EventArgs e)
        {
            if (CurrentParam != null)
                CurrentParam.Score = Convert.ToDouble(nupdnMatchScore.Value);
        }

        private void nupdnMaxAngle_Leave(object sender, EventArgs e)
        {
            if (CurrentParam != null)
                CurrentParam.MaxAngle = Convert.ToDouble(nupdnMaxAngle.Value);
        }

        public void DisposeImage()
        {
            CogDisplayHelper.DisposeDisplay(cogPatternDisplay);
        }


        private void lblTest_Click(object sender, EventArgs e)
        {
            TestActionEvent?.Invoke();
        }
        #endregion
    }
}
