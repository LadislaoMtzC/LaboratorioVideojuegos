using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLAYGROUND
{

    
    public class Game
    {

        int lifesSumo1;
        int lifesSumo2;
        int round;
        Bitmap heart, jumpA, jumpD;

        public Game(int lifes)
        {
            heart = Resource1.heart;
            jumpA = Resource1.jumpActivated;
            jumpD = Resource1.jumpDesactivated;
            lifesSumo1 = lifes;
            lifesSumo2 = lifes;
            round = 1;
        }

        public void Render(Graphics g, int Canvasw, int Canvash, DateTime lastWKeyPressTime, DateTime lastIKeyPressTime, TimeSpan delayTime)
        {
            int heartPosSumo1, heartPosSumo2;
            heartPosSumo1 = 10;
            heartPosSumo2 = Canvasw - heart.Width - 10;
            //por vidas jugador 1 dibuja x corazones
            for (int i = 0; i < lifesSumo1; i++)
            {
                g.DrawImage(heart, heartPosSumo1, 50, heart.Width, heart.Height);
                heartPosSumo1 += 10 + heart.Width;
            }
            //le llega los segundos y revisa si puede saltar o no y dependiendo de eso dibuja x boton
            if ((DateTime.Now - lastWKeyPressTime) > delayTime)
            {
                g.DrawImage(jumpA, 10, 60 + heart.Height, jumpA.Width, jumpA.Height);
            }
            else 
            {
                g.DrawImage(jumpD, 10, 60 + heart.Height, jumpD.Width, jumpD.Height);
            }
            //por vidas jugador 2 dibuja x corazones
            for (int i = 0; i < lifesSumo2; i++)
            {
                g.DrawImage(heart, heartPosSumo2, 50, heart.Width, heart.Height);
                heartPosSumo2 -= 10 + heart.Width;
            }
            //le llega los segundos y revisa si puede saltar o no y dependiendo de eso dibuja x boton
            if ((DateTime.Now - lastIKeyPressTime) > delayTime)
            {
                g.DrawImage(jumpA, Canvasw - jumpA.Width - 10, 60 + heart.Height, jumpA.Width, jumpA.Height);
            }
            else
            {
                g.DrawImage(jumpD, Canvasw - jumpD.Width - 10, 60 + heart.Height, jumpD.Width, jumpD.Height);
            }
        }

        public int getLifesSumo1()
        { 
            return lifesSumo1;
        }
        public int getLifesSumo2()
        {
            return lifesSumo2;
        }

        public void decreaseLifesSumo1()
        {
            lifesSumo1--;
        }

        public void decreaseLifesSumo2()
        {
            lifesSumo2--;
        }

        public void nextRound()
        {
            round++;
        }

        public int getRound() { return round; }

    }
}
