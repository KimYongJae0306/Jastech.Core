using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jastech.Framework.Winform.Properties;

namespace Jastech.Framework.Winform.Controls
{
    public partial class TaskProgressControl : UserControl
    {
        private FrameDimension _dimension;
        private int _gifFrame;
        private List<int> frames = new List<int>();
        private Image checkImage = Resources.Check_Ani_64;

        public TaskProgressControl()
        {
            InitializeComponent();

            _dimension = new FrameDimension(checkImage.FrameDimensionsList.FirstOrDefault());
            _gifFrame = checkImage.GetFrameCount(_dimension);

            frames.Add(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = checkImage;
            pictureBox1.Paint += PictureBox1_Paint;
            ImageAnimator.Animate(checkImage, OnFrameChanged);
            timer1.Enabled = false;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(checkImage, Point.Empty);
        }

        private void OnFrameChanged(object sender, EventArgs e)
        {
        }
    }
}
