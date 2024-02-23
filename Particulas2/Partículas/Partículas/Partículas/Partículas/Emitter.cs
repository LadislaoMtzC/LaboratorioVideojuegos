using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Partículas
{
    public class Emitter
    {

        public PointF Position { get; set; }
        public List<Particle> Particles { get; set; }
        public List<Influencer> Influencers = new List<Influencer>();

        private Size space; 
        public int MIN_X { get; set; }
        public int MAX_X { get; set; }
        public int MIN_Y { get; set; }
        public int MAX_Y { get; set; }

        public Emitter(PointF position, Size space)
        {

            Position = position;
            Particles = new List<Particle>();
            this.space = space;
            MIN_X = -5;
            MAX_X = 15;
            MIN_Y = -5;
            MAX_Y = 15;
            velocidades();
            

        }//end Emitter

        private void velocidades()
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                float vx = random.Next(MIN_X, MAX_X);
                float vy = random.Next(MIN_Y, MAX_Y);
                EmitParticle(new PointF(vx, vy));
            }

        }//end velocidades

        public void EmitParticle(PointF velocity)
        {

            Particles.Add(new Particle(Position,velocity));

        }//end EmitParticle

        public void ChangeVelocity(int minX, int maxX, int minY, int maxY)
        {

            MIN_X = minX;
            MAX_X = maxX;
            MIN_Y = minY;
            MAX_Y = maxY;

        }//end ChangeVelocity

        public void ChangeAlpha(float alpha)
        {



        }//end changeAlpha

        public void Render(Graphics g, float deltaTime)
        {

            int div = 8; int index = 0; 
            for (int p = 0; p < Particles.Count / div; p++) 
            { 
                index = p * div; 
                Update(g, index + 0, deltaTime); 
                Update(g, index + 1, deltaTime); 
                Update(g, index + 2, deltaTime); 
                Update(g, index + 3, deltaTime); 
                Update(g, index + 4, deltaTime); 
                Update(g, index + 5, deltaTime); 
                Update(g, index + 6, deltaTime); 
                Update(g, index + 7, deltaTime); 
            }

 
        }//end Render

        private void Update(Graphics g, int p, float deltaTime)
        {

            Particles[p].Update(Influencers, deltaTime, space, Position); 
            Particles[p].Render(g);


            
           
        }//end Update

    }//end class

}//end namespace
