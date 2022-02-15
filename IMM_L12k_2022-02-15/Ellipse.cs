using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMM_L12k_2022_02_15
{
    public class Ellipse : Figure
    {
        public Ellipse(int x, int y, Size containerSize) : base(containerSize)
        {
            (X, Y) = (x, y);
        }
        public override void Paint(Graphics g)
        {
            Pen p = new Pen(BorderColor, 4);
            Brush b = new SolidBrush(FigColor);
            g.FillEllipse(b, X, Y, FigureSize.Width, FigureSize.Height);
            g.DrawEllipse(p, X, Y, FigureSize.Width, FigureSize.Height);
        }
    }
}
