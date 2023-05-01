using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Jastech.Framework.Winform.Data;

namespace Jastech.Framework.Winform.Controls
{
    public partial class DrawBoxControl : UserControl
    {
        private Matrix _transform = new Matrix();

        private double ZoomScale { get; set; } = 1.0;

        private double OffsetX { get; set; } = 0.0;

        private double OffsetY { get; set; } = 0.0;

        public DisplayMode DisplayMode { get; private set; } = DisplayMode.None;

        public Bitmap OrgImage { get; set; } = null;

        private FigureManager FigureManager { get; set; } = new FigureManager();
      
        private Figure TempFigure { get; set; }

        private Figure SelectedFigure { get; set; } = null;

        private PointF PanningStartPoint { get; set; }

        public DrawBoxControl()
        {
            InitializeComponent();
        }

        private void DrawBoxControl_Load(object sender, EventArgs e)
        {
            DisplayMode = DisplayMode.Drawing;
            pbxDisplay.MouseWheel += PbxDisplay_MouseWheel;
        }

        public void SetImage(Bitmap bmp)
        {
            if (pbxDisplay.Image != null)
            {
                pbxDisplay.Image.Dispose();
                pbxDisplay.Image = null;
            }
            pbxDisplay.Image = bmp;
        }

        private void PbxDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            double imageX = e.X / ZoomScale - OffsetX;
            double imageY = e.Y / ZoomScale - OffsetY;

            ZoomScale += (e.Delta / 1000.0);

            if (ZoomScale > 10)
                ZoomScale = 10;
            if (ZoomScale < 0.1)
                ZoomScale = 0.1;

            OffsetX = (e.X / ZoomScale) - imageX;
            OffsetY = (e.Y / ZoomScale) - imageY;

            pbxDisplay.Invalidate();
        }

        private void pbxDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (pbxDisplay.Image == null)
                return;

            if (e.Button != MouseButtons.Left)
                return;

            double calcX = (e.X / ZoomScale) - OffsetX;
            double calcY = (e.Y / ZoomScale) - OffsetY;
            PointF calcPoint = new PointF((float)calcX, (float)calcY);
            PanningStartPoint = calcPoint;

            if (DisplayMode == DisplayMode.None)
            {
                FigureManager.CheckPointInFigure(calcPoint);

                if(FigureManager.IsSelected())
                {
                    SelectedFigure = FigureManager.GetSelectedFigure();
                    SelectedFigure.MouseDown(calcPoint);
                }
                else
                    SelectedFigure = null;

                pbxDisplay.Invalidate();
            }
            else if(DisplayMode == DisplayMode.Drawing)
            {
                if (TempFigure == null)
                    TempFigure = new RectangleFigure();

                TempFigure.MouseDown(calcPoint);
            }
        }

        private void pbxDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            double calcX = (e.X / ZoomScale) - OffsetX;
            double calcY = (e.Y / ZoomScale) - OffsetY;
            PointF calcPoint = new PointF((float)calcX, (float)calcY);

            if (e.Button == MouseButtons.Left)
            {
                if (DisplayMode == DisplayMode.Drawing)
                {
                    if (TempFigure != null)
                        TempFigure.MouseMove(calcPoint);
                }
                else if(DisplayMode == DisplayMode.None)
                {
                    if(FigureManager.GetSelectedFigure() is Figure figure)
                    {
                        figure.MouseMove(calcPoint);
                    }
                }
                else if(DisplayMode == DisplayMode.Panning)
                {
                    OffsetX = (e.X / ZoomScale) - PanningStartPoint.X;
                    OffsetY = (e.Y / ZoomScale) - PanningStartPoint.Y;
                }
                pbxDisplay.Invalidate();
            }
            else
            {
                this.Cursor = FigureManager.GetCursors(calcPoint);
            }
        }

        private void pbxDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            double calcX = (e.X / ZoomScale) - OffsetX;
            double calcY = (e.Y / ZoomScale) - OffsetY;

            if (DisplayMode == DisplayMode.Drawing)
            {
                if (TempFigure != null)
                {
                    double absX = Math.Abs(TempFigure.MouseDownPoint.X - calcX);
                    double absY = Math.Abs(TempFigure.MouseDownPoint.Y - calcY);
                    if (absX < 10 || absY < 10)
                        return;

                    TempFigure.IsSelected = true;
                    TempFigure.MouseUp(new PointF((float)calcX, (float)calcY));
                    FigureManager.AddFigure(TempFigure);
                    TempFigure = null;
                }
            }
        }

        private void pbxDisplay_Paint(object sender, PaintEventArgs e)
        {
            if (OrgImage == null)
                return;

            Graphics g = e.Graphics;
            g.Clear(Color.White);

            Matrix matrix = new Matrix();
            matrix.Translate((float)OffsetX, (float)OffsetY);
            Console.WriteLine(OffsetX.ToString() + "    " +OffsetY.ToString() + "   " + DisplayMode.ToString());
            matrix.Scale((float)ZoomScale, (float)ZoomScale, MatrixOrder.Append);
            g.Transform = matrix;

            g.DrawImage(pbxDisplay.Image, new Rectangle(0,0, OrgImage.Width, OrgImage.Height));

            FigureManager.Draw(g);

            if (TempFigure != null)
                TempFigure.Draw(g);
        }

        private void btnDrawNone_Click(object sender, EventArgs e)
        {
            DisplayMode = DisplayMode.None;
        }

        private void btnDrawROI_Click(object sender, EventArgs e)
        {
            DisplayMode = DisplayMode.Drawing;
        }

        private void pbxDisplay_DoubleClick(object sender, EventArgs e)
        {
            DisplayMode = DisplayMode.None;
            TempFigure = null;
            FigureManager.ClearFigureSelected();
        }

        private void btnPanning_Click(object sender, EventArgs e)
        {
            DisplayMode = DisplayMode.Panning;
        }
    }

    public enum DisplayMode
    {
        None,
        Drawing,
        Panning,
    }
}
