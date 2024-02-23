using Particles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partículas
{
    public class Particle
    {

        //original position velocity
        public PointF OP,OV;

        //position, velocity, force
        public float pX, pY, vX,vY, tFX,tFY;
        public float Alfa { get; set; }
        public float Mass { get; set; }
        public Image Image { get; set; }
        public float Size { get; set; }
        private float Lifetime; // Duración de vida de la partícula
        private float elapsedTime; // Tiempo transcurrido desde que se creó la partícula
        public Particle(PointF position, PointF velocity)
        {

            OP = position;
            OV = velocity;
            Alfa = .5f;
            Init();
            Lifetime = 100;

        }//end Particle

        private void Init()
        {

            pX = OP.X + +(float)Util.Instance.Rand.NextDouble();
            pY = OP.Y + +(float)Util.Instance.Rand.NextDouble();

            vX = OV.X;
            vY = OV.Y;
            elapsedTime = 0;

            Image = Util.Instance.FIRE_IMGS[Util.Instance.Rand.Next(Util.Instance.FIRE_IMGS.Length)];

            Lifetime = (float)Util.Instance.Rand.NextDouble() - .59f;
            Size = Util.Instance.Rand.Next(3, 15);
            Mass = Size;

            float VAL = (float)Util.Instance.Rand.NextDouble();

            VAL = Math.Min(VAL, Alfa);

            Image = Util.ApplyAlpha(Image, VAL);

        }//end Init

        public void Update(List<Influencer> influencers, float deltaTime, Size space, PointF pos)
        {
            tFX = 0; 
            tFY = 0; 
            OP = pos; 
            elapsedTime += deltaTime; // Incrementar el tiempo transcurrido
            
            for (int i = 0; i < influencers.Count; i++)
            {

                PointF force = influencers[i].GetForce(this);
                tFX += force.X;tFY += force.Y;

            }
            // Actualizar la velocidad de la partícula de acuerdo con la fuerza total de influencia
            vX += tFX;
            vY += tFY;
            
            // Actualizar la posición de la partícula según su velocidad
            pX += vX;
            pY += vY;
            // Actualizar de acuerdo con el tiempo de vida y el espacio del canvas

            
            if (elapsedTime >= Lifetime || pX < 0 || pY < 0 || pX > space.Width || pY > space.Height)
            {
                Init();
            }
            
            

        }//end Update

        public void Render(Graphics g) 
        {

            g.DrawImage(Image, pX, pY, Size, Size); 

        }//end Render

    }//end class

}//end namespace
