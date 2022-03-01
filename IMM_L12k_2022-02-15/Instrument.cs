using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMM_L12k_2022_02_15
{
    public abstract class Instrument
    {
        private Pen _pen = new Pen(Color.Black, 1);
        private Brush _brush = new SolidBrush(Color.Black);
        protected Point? StartPoint { get; set; }
        public Pen Pen
        {
            get => _pen;
            set => _pen = value;
        }

        public Brush Brush
        {
            get => _brush;
            set => _brush = value;
        }
        
        protected Image? CurrentImage;

        public void Start(Point location, Image currentImage)
        {
            CurrentImage = currentImage;
            StartPoint = location;
        }

        public void Stop()
        {
            StartPoint = null;
        }
        public abstract void Draw(Graphics g, Point currentPoint);
        protected Rectangle GetRectangle(Point p1, Point p2)
        {
            var xMin = Math.Min(p1.X, p2.X);
            var xMax = Math.Max(p1.X, p2.X);
            var yMin = Math.Min(p1.Y, p2.Y);
            var yMax = Math.Max(p1.Y, p2.Y);
            return new Rectangle(xMin, yMin, xMax-xMin, yMax-yMin);
        }
    }
}
