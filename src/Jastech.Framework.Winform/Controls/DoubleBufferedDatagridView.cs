using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class DoubleBufferedDatagridView : DataGridView
    {
        public DoubleBufferedDatagridView()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
    }
}
