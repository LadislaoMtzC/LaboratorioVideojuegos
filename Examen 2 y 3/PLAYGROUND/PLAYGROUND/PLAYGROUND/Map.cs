using PLAYGROUND.Properties;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
namespace PLAYGROUND
{
    public class Map
    {

        int yOfPlatforms = 12;
        int divs = 3;
        public int nTileWidth = 40;
        public int nTileHeight = 40;
        int nLevelWidth, nLevelHeight;
        private string sLevel;
        //public Bitmap bmp;
        //public Graphics g;

        float l0_X1, l0_X2, l1_X1, l1_X2;
        Bitmap layer0, layer1, parallaxBackground;
        int motion0 = 2;
        int motion1 = 3;
        byte[] bits;






        public Map(Size size)
        {


            sLevel = "";
            
            sLevel += "............................................................";
            sLevel += "............................................................";

            sLevel += "............................................................";
            sLevel += "............................................................";
            sLevel += "............................................................";
            sLevel += "............................................................";
            sLevel += "............................................................";

            sLevel += "............................................................";
            sLevel += "............................................................";
            sLevel += "............................................................";
            sLevel += "............................................................";

            sLevel += "...pppppppppp......pppppppppppppppppppppp......pppppppppp...";
            sLevel += "...pppppppppp......pppppppppppppppppppppp......pppppppppp...";

            sLevel += "............................................................";
            sLevel += "............................................................";
            sLevel += "............................................................";
            sLevel += "............................................................";
           



            nLevelWidth = 60;
            nLevelHeight = 17;

            /*bmp = new Bitmap(size.Width / divs, size.Height / divs);


            g = Graphics.FromImage(bmp);
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            g.SmoothingMode = SmoothingMode.HighSpeed;*/
        }


        public int[,] Draw(PointF cameraPos, Size size, Bitmap bmp, Graphics g)
        {

            g = Graphics.FromImage(bmp);
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            g.SmoothingMode = SmoothingMode.HighSpeed;

            /*
            layer0 = Resource1.Clouds;
            layer1 = Resource1.Temples;
            l0_X1 = l1_X1 = 0;
            l0_X2 = l1_X2 = size.Width;




            BackgroundMove(size);
            g.DrawImage(layer0, l0_X1, 0, size.Width + 5, size.Height);
            g.DrawImage(layer0, l0_X2, 0, size.Width + 5, size.Height);

            g.DrawImage(layer1, l1_X1, size.Height - layer1.Height + 5, layer1.Width, layer1.Height);
            g.DrawImage(layer1, l1_X2, size.Height - layer1.Height + 5, layer1.Width, layer1.Height);*/





            /*parallaxBackground = Resource1.Temples;
            float parallaxX = cameraPos.X * 0.5f;  // Ajusta la velocidad de paralaje según necesites
            float parallaxY = cameraPos.Y * 0.5f;
            g.DrawImage(parallaxBackground, -parallaxX, -parallaxY, bmp.Width, bmp.Height);*/



            int nVisibleTilesX = bmp.Width / nTileWidth;
            int nVisibleTilesY = bmp.Height / nTileHeight;

            // Calculate Top-Leftmost visible tile
            float fOffsetX = cameraPos.X - (float)nVisibleTilesX / 2.0f;
            float fOffsetY = cameraPos.Y - (float)nVisibleTilesY / 2.0f;

            // Clamp camera to game boundaries
            if (fOffsetX < 0) fOffsetX = 0;
            if (fOffsetY < 0) fOffsetY = 0;
            if (fOffsetX > nLevelWidth - nVisibleTilesX) fOffsetX = nLevelWidth - nVisibleTilesX;
            if (fOffsetY > nLevelHeight - nVisibleTilesY) fOffsetY = nLevelHeight - nVisibleTilesY;

            float fTileOffsetX = (fOffsetX - (int)fOffsetX) * nTileWidth;
            float fTileOffsetY = (fOffsetY - (int)fOffsetY) * nTileHeight;




            //Draw visible tile map//*--------------------DRAW------------------------------
            char c;
            float stepX, stepY;
            bool previousOnePlatform = false;
            bool previousOneEmpty = true;
            int indexLeftLimits = 0;
            int indexRightLimits = 0;
            int yAppearance = -1;
            int[,] horizontalLimits = {
             {-1, -1, -1},
             {-1, -1, -1},

             };

            for (int y = -1; y < nVisibleTilesY + 2; y++)
            {
                for (int x = -1; x < nVisibleTilesX + 2; x++)
                {
                    c = GetTile(x + (int)fOffsetX, y + (int)fOffsetY);
                    stepX = x * nTileWidth - fTileOffsetX;
                    stepY = y * nTileHeight - fTileOffsetY;



                    switch (c)
                    {
                        case '.':
                            //g.FillRectangle(Brushes.Black, stepX, stepY, nTileWidth, nTileHeight);
                            if (previousOnePlatform && indexRightLimits < 3 && indexLeftLimits < 3)
                            {
                                horizontalLimits[1, indexRightLimits] = (int)stepX;
                                indexRightLimits++;
                                //means the previous x is a right border of a platform
                            }
                            previousOnePlatform = false;
                            previousOneEmpty = true;
                            break;
                        case 'p':
                            g.FillRectangle(Brushes.Red, stepX, stepY, nTileWidth, nTileHeight);
                            g.DrawRectangle(Pens.DarkRed, stepX, stepY, nTileWidth, nTileHeight - 1);

                            /*g.FillRectangle(Brushes.Black, stepX, stepY, nTileWidth, nTileHeight);
                            g.FillRectangle(Brushes.DarkRed, stepX + 1, stepY + 1, nTileWidth - 2, nTileHeight - 2);
                            g.FillEllipse(Brushes.DarkRed, stepX, stepY, nTileWidth, nTileHeight);
                            g.FillEllipse(Brushes.DarkSlateGray, stepX, stepY, nTileWidth / 2, nTileHeight / 2);
                            g.DrawLine(Pens.Black, stepX + nTileHeight / 2, stepY + nTileHeight / 2, stepX + nTileHeight, stepY + nTileHeight - 3);
                            g.DrawLine(Pens.Maroon, stepX + nTileHeight / 2, 2 + stepY + nTileHeight / 2, 1 + stepX + nTileHeight, stepY + nTileHeight - 2);
                            g.DrawLine(Pens.Black, stepX + nTileHeight / 2, stepY, stepX + nTileHeight / 2, stepY + nTileHeight * 2 / 3);
                            g.DrawLine(Pens.Black, 1 + stepX + nTileHeight / 2, stepY + 1, 2 + stepX + nTileHeight / 2, 3 + stepY + nTileHeight * 2 / 3);
                            g.DrawLine(Pens.Maroon, 2 + stepX + nTileHeight / 2, stepY, 1 + stepX + nTileHeight / 2, stepY + nTileHeight * 2 / 3);
                            g.DrawLine(Pens.Black, stepX + nTileHeight / 2, stepY + nTileHeight * 2 / 3, stepX, stepY + nTileHeight / 3);
                            g.DrawRectangle(Pens.Black, stepX + nTileHeight / 2, stepY, nTileWidth, nTileHeight - 1);
                            g.DrawRectangle(Pens.Gray, stepX, stepY, nTileWidth, nTileHeight - 1);*/

                            if ((previousOneEmpty || x == -1) && indexLeftLimits < 3 && indexRightLimits < 3)
                            {
                                //means that it encountered a left limit
                                horizontalLimits[0, indexLeftLimits] = (int)stepX;
                                indexLeftLimits++;
                            }
                            if (x == nVisibleTilesX + 1 && indexRightLimits < 3 && indexLeftLimits < 3)
                            {
                                horizontalLimits[1, indexRightLimits] = (int)stepX;
                                indexRightLimits++;
                                //last right
                            }

                            previousOnePlatform = true;
                            previousOneEmpty = false;

                            break;

                        default:
                            /*
                            g.FillRectangle(Brushes.Black, stepX, stepY, nTileWidth, nTileHeight);
                            g.FillRectangle(Brushes.DarkRed, stepX + 1, stepY + 1, nTileWidth - 2, nTileHeight - 2);
                            g.DrawLine(Pens.Black, stepX + nTileHeight / 2, stepY + nTileHeight / 2, stepX + nTileHeight, stepY + nTileHeight - 3);
                            g.DrawLine(Pens.Maroon, stepX + nTileHeight / 2, 2 + stepY + nTileHeight / 2, 1 + stepX + nTileHeight, stepY + nTileHeight - 2);
                            g.DrawLine(Pens.Black, stepX + nTileHeight / 2, stepY, stepX + nTileHeight / 2, stepY + nTileHeight * 2 / 3);
                            g.DrawLine(Pens.Black, 1 + stepX + nTileHeight / 2, stepY + 1, 2 + stepX + nTileHeight / 2, 3 + stepY + nTileHeight * 2 / 3);
                            g.DrawLine(Pens.Maroon, 2 + stepX + nTileHeight / 2, stepY, 1 + stepX + nTileHeight / 2, stepY + nTileHeight * 2 / 3);
                            g.DrawLine(Pens.Black, stepX + nTileHeight / 2, stepY + nTileHeight * 2 / 3, stepX, stepY + nTileHeight / 3);
                            g.DrawRectangle(Pens.Black, stepX + nTileHeight / 2, stepY, nTileWidth, nTileHeight - 1);
                            g.DrawRectangle(Pens.Gray, stepX, stepY, nTileWidth, nTileHeight - 1);*/
                            break;
                    }
                }

            }

            //regresar plataformas actuales
            return horizontalLimits;

            //player.MainSprite.posX = (player.fPlayerPosX - fOffsetX) * nTileWidth;
            //player.MainSprite.posY = (player.fPlayerPosY - fOffsetY) * nTileHeight;
        }

        public void SetTile(float x, float y, char c)//changes the tile
        {
            if (x >= 0 && x < nLevelWidth && y >= 0 && y < nLevelHeight)
            {
                int index = (int)y * nLevelWidth + (int)x;
                sLevel = sLevel.Remove(index, 1).Insert(index, c.ToString());

            }
        }

        public char GetTile(float x, float y)
        {
            if (x >= 0 && x < nLevelWidth && y >= 0 && y < nLevelHeight)
                return sLevel[(int)y * nLevelWidth + (int)x];
            else
                return ' ';
        }

        private void BackgroundMove(Size size)
        {

            if (l0_X1 < -size.Width)
            {
                l0_X1 = size.Width - motion1;
            }
            if (l0_X2 < -size.Width)
            {
                l0_X2 = size.Width - motion1;
            }
            l0_X1 -= motion0; l0_X2 -= motion0;

            if (l1_X1 < -size.Width)
            {
                l1_X1 = size.Width - motion1;
            }
            if (l1_X2 < -size.Width)
            {
                l1_X2 = size.Width - motion1;
            }
            l1_X1 -= motion1; l1_X2 -= motion1;


        }




    }



    /*
            sLevel = "";
            sLevel += "................................................................................................................................................................................................................................................................";
            sLevel += "................................................................................................................................................................................................................................................................";
            sLevel += "................................................................................................................................................................................................................................................................";
            sLevel += "................................................................................................................................................................................................................................................................";
            sLevel += "................................................................................................................................................................................................................................................................";
            
            
            sLevel += "................................................................................................................................................................................................................................................................";
            sLevel += "................................................................................................................................................................................................................................................................";
            sLevel += "................................................................................................................................................................................................................................................................";
            sLevel += "................................................................................................................................................................................................................................................................";
            sLevel += "................................................................................................................................................................................................................................................................";
           
            
            sLevel += "................................................................................................................................................................................................................................................................";
            sLevel += ".........................................................................................................................................................................PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP...............................................";
            sLevel += ".........................................................................................................................................................................PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP...............................................";
            sLevel += "........................................................................................................PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP................................................................................................................";
            sLevel += "................................................PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP................PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP................................................................................................................";
    
            sLevel += "................................................PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP........................................................................................................................................................................";
            sLevel += "................................................................................................................................................................................................................................................................";
            sLevel += "................................................................................................................................................................................................................................................................";
            sLevel += "................................................................................................................................................................................................................................................................";
            sLevel += "................................................................................................................................................................................................................................................................";
            */
}
