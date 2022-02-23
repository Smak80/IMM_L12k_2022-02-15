using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMM_L12k_2022_02_15
{
    public class Painter
    {
        public enum InstrumentType
        {
            PenDrawer,
        }
        private int figureCount = 5;
        private Image img;
        private List<Instrument> ins = new List<Instrument>();

        public InstrumentType it
        {
            get;
            set;
        }
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
        private Size containerSize;
        public Size ContainerSize
        {
            get => containerSize;
            set
            {
                containerSize = value;
                var img = new Bitmap(containerSize.Width, containerSize.Height, PixelFormat.Format24bppRgb);
                Graphics.FromImage(img).Clear(Color.White);
                var ig = Graphics.FromImage(img);
                if (this.img is not null)
                    ig.DrawImage(this.img, 0, 0);
                this.img = img;

            }
        }
        public Painter(int figureCount, Size containerSize)
        {
            FigureCount = figureCount;
            ContainerSize = containerSize;
            //CreateFigures();
            ins.Add(new PenDrawer());
        }

        public void CreateFigures()
        {
            fgs.Clear();
            for (int i = 0; i < FigureCount; i++)
            {
                var x = random.Next();
                var y = random.Next();
                fgs.Add((random.Next()%2==0)?
                    new Ellipse(x, y, ContainerSize):
                    new Rect(x, y, ContainerSize));
            }
        }

        public void Paint(Graphics g)
        {
            //var ig = Graphics.FromImage(img);
            //ig.Clear(Color.White);
            /*foreach (var figure in fgs)
            {
                figure.Paint(ig);
            }*/
            g.DrawImage(img, 0, 0);
        }

        public void StartDrawing(Point eLocation)
        {
            ins[(int)it].StartDrawing(eLocation);   
        }

        public void StopDrawing()
        {
            ins[(int)it].StopDrawing();
        }

        public bool Draw(Point eLocation)
        {
            var ig = Graphics.FromImage(img);
            return ins[(int)it].Draw(ig, eLocation);
        }
    }
}
