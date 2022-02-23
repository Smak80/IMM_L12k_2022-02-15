using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMM_L12k_2022_02_15
{
    interface Instrument
    {
        public void StartDrawing(Point eLocation);
        public void StopDrawing();
        public bool Draw(Graphics g, Point eLocation);
    }
}
