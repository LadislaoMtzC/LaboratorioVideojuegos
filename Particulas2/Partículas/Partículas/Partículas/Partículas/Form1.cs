using Particles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Partículas
{
    public partial class Form1 : Form
    {

        static Emitter emitter;
        Scene scene;
        Canvas canvas;
        float deltaTime;
        static GravityInfuencer gravityInfluencer;
        static WindInfluencer windInfluencer1;
        static WindInfluencer windInfluencer2;
        public Form1()
        {
            InitializeComponent();
            Init();
        }//end form1


        private void Init() 
        { 
            if (PCT_CANVAS.Width == 0) 
                return; 
            deltaTime = 0; 
            scene = new Scene();
            canvas = new Canvas(PCT_CANVAS.Size);
            PCT_CANVAS.Image = canvas.bitmap;
            
        }//end Init

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            canvas.Render(scene, deltaTime);
            PCT_CANVAS.Invalidate(); 
            deltaTime = 0.001f;

        }//end timer1_Tick

        private void AddEmitter_Click(object sender, EventArgs e)
        {

            //emitter = new Emitter(new PointF(Util.Instance.Rand.Next(80, 267), Util.Instance.Rand.Next(80, 552)),PCT_CANVAS.Size);
            emitter = new Emitter(new PointF(200, 500), PCT_CANVAS.Size);
            windInfluencer1 = new WindInfluencer(10, PCT_CANVAS.Size, 150, 450); // se declara una fuerza
            gravityInfluencer = new GravityInfuencer(150, PCT_CANVAS.Height); // se declara una fuerza
            windInfluencer2 = new WindInfluencer(140, PCT_CANVAS.Size, 500, 200);

            emitter.Influencers.Add(windInfluencer1);
            emitter.Influencers.Add(windInfluencer2);
            emitter.Influencers.Add(gravityInfluencer);
       
            scene.Emitter.Add(emitter);


        }//end AddEmitter_Click

        private void Update_Click(object sender, EventArgs e)
        {

            /*
            windInfluencer1.angle = float.Parse(FanAngle1.Text);
            windInfluencer2.angle = float.Parse(FanAngle2.Text);
            gravityInfluencer.GravitationalConstant = float.Parse(Gravedad.Text);
            windInfluencer1.WindConstant = float.Parse(Gravedad.Text)/3;
            windInfluencer2.WindConstant = float.Parse(Gravedad.Text)/3;
            */
        }//Update_Click
    }//end class

}//end namespace
