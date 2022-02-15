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
            p = new Painter(10, panel1.Size);
            panel1.Invalidate();
        }
    }
}