using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMM_L12k_2022_02_15
{
    public abstract class Figure
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private Color figColor;
        private Color borderColor;
        private Size containerSize;
        private Random random = new Random();

        public int X
        {
            get => x;
            set => x = Math.Max(0, value) % (containerSize.Width - width);
        }

        public int Y
        {
            get => y;
            set => y = Math.Max(0, value) % (containerSize.Height - height);
        }

        public Color FigColor
        {
            get => figColor;
        }

        public Color BorderColor
        {
            get => borderColor;
        }

        public Figure(Size containerSize)
        {
            this.containerSize = containerSize;
            width = random.Next(30, 200);
            height = random.Next(30, 200);
            figColor = Color.FromArgb(
                random.Next(20, 200),
                random.Next(255),
                random.Next(255),
                random.Next(255)
            );
            borderColor = Color.FromArgb(
                random.Next(20, 200),
                random.Next(255),
                random.Next(255),
                random.Next(255)
            );
        }

        public Size FigureSize
        {
            get => new Size(width, height);
        }

        public abstract void Paint(Graphics g);
    }
}
