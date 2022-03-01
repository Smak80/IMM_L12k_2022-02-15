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
            RectDrawer,
            RectFiller
        }
        //private int figureCount = 5;
        private Image? _img;
        private readonly List<Instrument> _ins = new ();
        public InstrumentType InsType
        {
            get;
            set;
        }
        /*public int FigureCount
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
        }*/
        
        private Size _containerSize;
        public Size ContainerSize
        {
            get => _containerSize;
            set
            {
                _containerSize = value;
                var img = new Bitmap(_containerSize.Width, _containerSize.Height, PixelFormat.Format24bppRgb);
                Graphics.FromImage(img).Clear(Color.White);
                var ig = Graphics.FromImage(img);
                if (_img is not null)
                    ig.DrawImage(this._img, 0, 0);
                _img = img;
            }
        }
        public Painter(int figureCount, Size containerSize)
        {
            //FigureCount = figureCount;
            ContainerSize = containerSize;
            //CreateFigures();
            _ins.Add(new PenDrawer());
            _ins.Add(new RectDrawer());
            _ins.Add(new RectDrawer(true));
        }

        /*public void CreateFigures()
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
        }*/

        public void Paint(Graphics g)
        {
            if (_img is not null)
            {
                g.DrawImage(_img, 0, 0);
            }
        }

        public void StartDrawing(Point location)
        {
            if (_img is not null)
            {
                _ins[(int)InsType].Start(location, (Image)_img);
            }
        }

        public void StopDrawing(Point location)
        {
            if (_img is not null)
            {
                var ig = Graphics.FromImage(_img);
                _ins[(int)InsType].Draw(ig, location);
            }
            _ins[(int)InsType].Stop();
        }

        public void Draw(Point location, Graphics tempG)
        {
            var bg =
                BufferedGraphicsManager.Current.Allocate(
                    tempG, 
                    Rectangle.Ceiling(tempG.VisibleClipBounds)
                );
            if (_img is not null)
                bg.Graphics.DrawImage(_img, 0, 0);
            else bg.Graphics.Clear(Color.White);
            _ins[(int)InsType].Draw(bg.Graphics, location);
            bg.Render(tempG);
            bg.Dispose();
        }
    }
}
