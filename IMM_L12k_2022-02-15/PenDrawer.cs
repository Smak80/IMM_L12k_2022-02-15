using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMM_L12k_2022_02_15
{
    public class PenDrawer : Instrument
    {
        private Point? startPos = null;
        public void StartDrawing(Point eLocation)
        {
            startPos = eLocation;
        }

        public void StopDrawing()
        {
            startPos = null;
        }
        public bool Draw(Graphics g, Point eLocation)
        {
            if (startPos is not null)
            {
                Pen p = new Pen(Color.Blue, 3);
                g.DrawLine(p, (Point)startPos, eLocation);
                startPos = eLocation;
                return true;
            }

            return false;
        }
    }
}
