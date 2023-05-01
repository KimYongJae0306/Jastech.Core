using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Data
{
    public class FigureManager
    {
        private List<Figure> FigureList { get; set; } = new List<Figure>();

        public void AddFigure(Figure figure)
        {
            FigureList.Add(figure);
        }

        public Figure GetSelectedFigure()
        {
            foreach (var figure in FigureList)
            {
                if (figure.IsSelected)
                    return figure;
            }
            return null;
        }

        public bool IsSelected()
        {
            bool isSelected = false;
            foreach (Figure figure in FigureList)
            {
                if (figure.IsSelected)
                    isSelected = true;
            }
            return isSelected;
        }

        public void CheckPointInFigure(PointF point)
        {
            foreach (var figure in FigureList)
            {
                figure.CheckPointInFigure(point);
            }
        }

        public void ClearFigureSelected()
        {
            FigureList.ForEach(x => x.IsSelected = false);
        }

        public void Draw(Graphics g)
        {
            FigureList.ForEach(x => x.Draw(g));
        }

        public Cursor GetCursors(PointF point)
        {
            foreach (var figure in FigureList)
            {
               if(figure.GetCursors(point) is Cursor cursor)
                {
                    if (cursor != Cursors.Default)
                        return cursor;
                }
            }
            return Cursors.Default;
        }
    }
}
