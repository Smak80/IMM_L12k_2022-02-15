using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMM_L12k_2022_02_15;
public class RectDrawer : Instrument
{
    private bool fill;

    public RectDrawer(bool fill = false)
    {
        this.fill = fill;
    }

    public override void Draw(Graphics g, Point currentPoint)
    {
        if (StartPoint is not null)
        {
            g.DrawImage(CurrentImage, 0, 0);
            if (fill)
            {
                g.FillRectangle(Brush, GetRectangle((Point)StartPoint, currentPoint));
            }
            g.DrawRectangle(Pen, GetRectangle((Point)StartPoint, currentPoint));
        }
    }
}