using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Forms
{
    public partial class LogForm : Form
    {
        private Color _selectedColor;

        private Color _nonSelectedColor;

        private string _logPath { get; set; } = string.Empty;

        private string _imagePath { get; set; } = string.Empty;

        private string _resultPath { get; set; } = string.Empty;

        private PageType _selectedPageType { get; set; } = PageType.Log;

        private string _selectedPagePath { get; set; } = string.Empty;

        private UPHControl_old UPHControl { get; set; } = new UPHControl_old() { Dock = DockStyle.Fill };

        public LogForm()
        {
            InitializeComponent();
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            _selectedColor = Color.FromArgb(104, 104, 104);
            _nonSelectedColor = Color.FromArgb(52, 52, 52);

            SetPageType(PageType.Log);
            cdrMonthCalendar.SelectionStart = DateTime.Now;
        }

        private void SetPageType(PageType pageType)
        {
            _selectedPageType = pageType;

            ClearSelectedLabel();
            pnlContents.Controls.Clear();

            switch (pageType) 
            {
                case PageType.Log:
                    _selectedPagePath = _logPath;
                    lblLog.BackColor = _selectedColor;
                    break;

                case PageType.Image:
                    _selectedPagePath = _imagePath;
                    lblImage.BackColor = _selectedColor;
                    break;

                case PageType.AlignTrend:
                    _selectedPagePath = _resultPath;
                    lblAlignTrend.BackColor = _selectedColor;
                    break;

                case PageType.AkkonTrend:
                    _selectedPagePath = _resultPath;
                    lblAkkonTrend.BackColor = _selectedColor;
                    break;

                case PageType.UPH:
                    _selectedPagePath = _resultPath;
                    lblUPH.BackColor = _selectedColor;

                    pnlContents.Controls.Add(UPHControl);
                    break;
            }
        }

        private void ClearSelectedLabel()
        {
            foreach (Control control in pnlLogType.Controls)
            {
                if (control is Label)
                    control.BackColor = _nonSelectedColor;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblLog_Click(object sender, EventArgs e)
        {
            SetPageType(PageType.Log);
        }

        private void lblImage_Click(object sender, EventArgs e)
        {
            SetPageType(PageType.Image);
        }

        private void lblAlignTrend_Click(object sender, EventArgs e)
        {
            SetPageType(PageType.AlignTrend);
        }

        private void lblAkkonTrend_Click(object sender, EventArgs e)
        {
            SetPageType(PageType.AkkonTrend);
        }

        private void lblUPH_Click(object sender, EventArgs e)
        {
            SetPageType(PageType.UPH);
        }

        public void SetLogViewPath(string logPath = "", string imagePath = "", string resultPath = "")
        {
            _logPath = logPath;
            _imagePath = imagePath;
            _resultPath = resultPath;
        }

        private void cdrMonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (_selectedPagePath == string.Empty)
                return;

            tvwLogPath.Nodes.Clear();

            for (int index = tvwLogPath.Nodes.Count; index < 0; index--)
                tvwLogPath.Nodes.RemoveAt(index - 1);

            DirectoryInfo directoryInfo = new DirectoryInfo(_selectedPagePath);

            if (Directory.Exists(directoryInfo.FullName))
            {
                TreeNode treeNode = new TreeNode(directoryInfo.Name);
                tvwLogPath.Nodes.Add(treeNode);
                RecursiveDirectory(directoryInfo, treeNode);
            }
        }

        private void RecursiveDirectory(DirectoryInfo directoryInfo, TreeNode treeNode)
        {
            try
            {
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (FileInfo files2 in files)
                {
                    TreeNode node = new TreeNode(files2.Name);
                    treeNode.Nodes.Add(node);
                }

                DirectoryInfo[] dirs = directoryInfo.GetDirectories();
                foreach (DirectoryInfo dirInfo in dirs)
                {
                    TreeNode upperNode = new TreeNode(dirInfo.Name);
                    treeNode.Nodes.Add(upperNode);

                    files = dirInfo.GetFiles();
                    foreach (FileInfo fileInfo in files)
                    {
                        TreeNode underNode = new TreeNode(fileInfo.Name);
                        upperNode.Nodes.Add(underNode);
                    }

                    try
                    {
                        if (dirInfo.GetDirectories().Length > 0)
                            RecursiveDirectory(dirInfo, upperNode);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            catch
            {

            }
        }

        
    }

    public enum PageType
    {
        Log,
        Image,
        AlignTrend,
        AkkonTrend,
        UPH,
    }
}
