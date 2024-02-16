namespace Colision2
{
    public partial class Form1 : Form
    {


        List<Ball> balls;
        Bitmap bmp;
        Graphics g;
        static Random rand = new Random();
        static float deltaTime;




        public Form1()
        {
            InitializeComponent();
            AmountText.Text = "1";
            if (PCT_CANVAS.Width == 0)
                return;
            balls = new List<Ball>();
            bmp = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            g = Graphics.FromImage(bmp);
            deltaTime = 0;
            PCT_CANVAS.Image = bmp;
            for (int i = 0; i < int.Parse(AmountText.Text); i++)
                balls.Add(new Ball(rand, PCT_CANVAS.Size, i));

        }


        private void Init()
        {
            if (PCT_CANVAS.Width == 0)
                return;
            balls = new List<Ball>();
            bmp = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            g = Graphics.FromImage(bmp);
            deltaTime = 0;
            PCT_CANVAS.Image = bmp;
            for (int i = 0; i < int.Parse(AmountText.Text); i++)
                balls.Add(new Ball(rand, PCT_CANVAS.Size, i));
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.Black);
            Ball b;
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Update(balls, deltaTime);
                b = balls[i];
                g.FillEllipse(new SolidBrush(balls[i].c), b.X - b.diameter / 2, b.Y - b.diameter / 2, b.diameter, b.diameter);
                balls[i].changed = false;
            }
            PCT_CANVAS.Invalidate();
            deltaTime += .1f;

        }

        private void Amount_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
