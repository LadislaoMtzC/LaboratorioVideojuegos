using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colision2
{
    internal class Ball
    {


        static Size space;
        public float Radius, diameter, vx, vy;
        public float X, Y;
        public int index;
        public Color c;
        public bool changed;

        public Ball(Random rand, Size size, int index)
        {
            X = rand.Next(0, size.Width);
            Y = rand.Next(0, size.Height);
            vx = rand.Next(-30, 30);
            vy = rand.Next(-30, 30);
            diameter = rand.Next(40, 55);
            space = size;
            this.index = index;
            changed = false;
            Radius = diameter / 2;
            c = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
        }

    
        public void Resolve (Ball other)
        {

            {
                //Calcular la separacion
                float dx = other.X - X;
                float dy = other.Y - Y;
                float distance = (float)Math.Sqrt(dx * dx + dy * dy);
                float overlap = (this.Radius + other.Radius) - distance;

                if (overlap > 0)
                {
                    // Separar las pelotas
                    float moveX = overlap * (dx / distance) * 0.5f;
                    float moveY = overlap * (dy / distance) * 0.5f;
                    this.X -= moveX;
                    this.Y -= moveY;
                    other.X += moveX;
                    other.Y += moveY;

                    //Colision
                    this.vx *= -1;
                    this.vy *= -1;
                    other.vx *= -1;
                    other.vy *= -1;
                }
            }
        }


        private float Distance(Ball ball)
        {

            float deltaX = ball.X - this.X;
            float deltaY = ball.Y - this.Y;
            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

        }







        public Boolean Collision(Ball ball)
        {

            float distance = Distance(ball);
            if (distance<(ball.Radius+this.Radius)+5)
            {
                return true;
            }


            return false;

        }




        private void ResolveWalls()
        {
            if ((X
            - Radius) < 0)
            {
                changed = true
                ;
                vx *=
                -1;
                X = Radius
                ;
            }
            if ((X + Radius) > space.Width
           )
            {
                changed = true
                ;
                vx *=
                -1;
                X = space.Width
                - Radius
                ;
            }
            if ((Y
            - Radius) < 0)
            {
                vy *=
                -1;
                changed = true
                ;
                Y = Radius
                ;
            }
            if ((Y + Radius) > space.Height
           )
            {
                vy *=
                -1;
                changed = true
                ;
                Y = space.Height
                - Radius
                ;
            }
        }

        public void Update(List<Ball> balls, float deltaTime)
        {
            float val = .95f;
            X += (vx * deltaTime);
            Y += (vy * deltaTime);
            for (int b = index + 1; b < balls.Count; b++)
            {
                if (Collision(balls[b]))
                {
                    Resolve(balls[b]);
                }
            }
            ResolveWalls();
            vx *= val;
            vy *= val;
        }






    }
}
