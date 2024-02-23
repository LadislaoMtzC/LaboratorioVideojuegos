using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partículas
{
    public class WindInfluencer : Influencer
    {

        public float WindConstant { get; set; }
        public float angle;
        private Size size;
        private float height;
        private float width;
        private float wx;
        private float wy;
        private float radio;

        PointF WindForce;
        float forceMagnitudeX, forceMagnitudeY, distanceX, distanceY;
        public WindInfluencer(float windConstant, Size size, float x, float y)
        {
            
            WindConstant = windConstant;
            this.size.Height = size.Height;
            this.size.Width = size.Width;
            wy = y;
            wx = x;
            radio = 50;
            
        }//end GravityInfluencer
        public override PointF GetForce(Particle particle)
        {

            // double radians = (double)(angle * Math.PI/180);

            // Calcular la distancia vertical entre la partícula y el punto de referencia (por ejemplo, el suelo)

            // Calcular la fuerza de la gravedad
            if (particle.pY < wy + radio && particle.pY > wy - radio)
            {
                distanceX = wx - particle.pX;
                forceMagnitudeX = ((WindConstant) * particle.Mass * 1000) / (distanceX * distanceX); // F = G * (m1 * m2) / r^2
                
                
                
                // La fuerza de la gravedad siempre apunta hacia abajo, en dirección negativa en el eje Y
                
                if(wx > particle.pX)
                {
                    WindForce = new PointF(-forceMagnitudeX, 0);

                }
                else
                {
                    WindForce = new PointF(forceMagnitudeX, 0);
                }
                return WindForce;

            }
            else { return new PointF(0, 0); }
           
            
            

        }//end GetForce
         

    }//end class

}//end namespace
