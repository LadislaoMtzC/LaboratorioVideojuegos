using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partículas
{
    public abstract class Influencer
    {

        public abstract PointF GetForce(Particle particle);

    }//end class

}//end namespace
