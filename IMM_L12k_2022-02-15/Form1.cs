namespace IMM_L12k_2022_02_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            p = new Painter(10, panel1.Size);
        }

        private Painter p;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            p.Paint(e.Graphics);
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            p.ContainerSize = panel1.Size;
            panel1.Refresh();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            p.InsType = e.Button == MouseButtons.Left
                ? Painter.InstrumentType.PenDrawer
                : Painter.InstrumentType.RectFiller;
            p.StartDrawing(e.Location);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            p.StopDrawing(e.Location);
            panel1.Update();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            p.Draw(e.Location, panel1.CreateGraphics());
        }
    }
}