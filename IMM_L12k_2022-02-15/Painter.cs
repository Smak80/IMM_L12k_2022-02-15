using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMM_L12k_2022_02_15
{
    public class Painter
    {
        private int figureCount = 5;

        public int FigureCount
        {
            get => figureCount;
            set
            {
                figureCount = value switch
                {
                    <= 5 => 5,
                    > 5 and <= 20 => value,
                    > 20 => 20
                };
            }
        }

        private Random random = new Random();
        private List<Figure> fgs = new List<Figure>();
        public Painter(int figureCount, Size containerSize)
        {
            FigureCount = figureCount;
            CreateFigures(containerSize);
        }

        private void CreateFigures(Size containerSize)
        {
            for (int i = 0; i < FigureCount; i++)
            {
                var x = random.Next();
                var y = random.Next();
                fgs.Add((random.Next()%2==0)?
                    new Ellipse(x, y, containerSize):
                    new Rect(x, y, containerSize));
            }
        }

        public void Paint(Graphics g)
        {
            foreach (var figure in fgs)
            {
                figure.Paint(g);
            }
        }
    }
}
