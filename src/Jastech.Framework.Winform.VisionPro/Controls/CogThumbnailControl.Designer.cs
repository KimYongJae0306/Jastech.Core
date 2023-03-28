namespace Jastech.Framework.Winform.VisionPro.Controls
{
    partial class CogThumbnailControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CogThumbnailControl));
            this.cogThumbnailDisplay = new Cognex.VisionPro.CogRecordDisplay();
            ((System.ComponentModel.ISupportInitialize)(this.cogThumbnailDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // cogThumbnailDisplay
            // 
            this.cogThumbnailDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogThumbnailDisplay.ColorMapLowerRoiLimit = 0D;
            this.cogThumbnailDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogThumbnailDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogThumbnailDisplay.ColorMapUpperRoiLimit = 1D;
            this.cogThumbnailDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogThumbnailDisplay.DoubleTapZoomCycleLength = 2;
            this.cogThumbnailDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cogThumbnailDisplay.Location = new System.Drawing.Point(0, 0);
            this.cogThumbnailDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.None;
            this.cogThumbnailDisplay.MouseWheelSensitivity = 1D;
            this.cogThumbnailDisplay.Name = "cogThumbnailDisplay";
            this.cogThumbnailDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogThumbnailDisplay.OcxState")));
            this.cogThumbnailDisplay.Size = new System.Drawing.Size(230, 209);
            this.cogThumbnailDisplay.TabIndex = 0;
            // 
            // CogThumbnailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cogThumbnailDisplay);
            this.Name = "CogThumbnailControl";
            this.Size = new System.Drawing.Size(230, 209);
            ((System.ComponentModel.ISupportInitialize)(this.cogThumbnailDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.CogRecordDisplay cogThumbnailDisplay;
    }
}
