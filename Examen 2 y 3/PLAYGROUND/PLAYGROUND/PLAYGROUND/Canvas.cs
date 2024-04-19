using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading.Tasks;
using PLAYGROUND.Properties;
using System.Drawing.Drawing2D;

namespace PLAYGROUND
{
    public class Canvas
    {
        static PictureBox pctCanvas;
        static BitmapData bitmapData;

        Size size;
        Bitmap bmp;
        float Width, Height;
        byte[] bits;
        Graphics g;
        int pixelFormatSize, stride;
        int bytesPerPixel, heightInPixels, widthInBytes;
        Rectangle rect;

        float motion0 = 1f;
        float motion1 = 2f;
        int motion2 = 4;
        int motion3 = 8;
        int motion4 = 16;
        float l0_X0, l0_X1, l0_X2, l1_X0, l1_X1, l1_X2;
        Bitmap layer0, layer1, layer2, layer3, layer4;

        public Camera camera;
        Map map;

        public Canvas(PictureBox pctCanvas)
        {
            Canvas.pctCanvas = pctCanvas;
            this.size = pctCanvas.Size;
            Init(size.Width, size.Height);
            pctCanvas.Image = bmp;
            layer0 = Resource1.Clouds;
            layer1 = Resource1.Temples;
            layer2 = Resource1.CherryBlossoms;
            l0_X0 = l1_X0 = -size.Width;
            l0_X1 = l1_X1 = 0;
            l0_X2 = l1_X2 = size.Width;
            camera = new Camera(1000, 0);
            map = new Map(size);
        }




        private void Init(int width, int height)
        {
            PixelFormat format;
            GCHandle handle;
            IntPtr bitPtr;
            int padding;

            format              = PixelFormat.Format32bppArgb;
            Width               = width;
            Height              = height;
            pixelFormatSize     = Image.GetPixelFormatSize(format) / 8; // 8 bits = 1 byte
            stride              = width * pixelFormatSize; // total pixels (width) times ARGB (4)
            padding             = (stride % 4); // PADD = move every pixel in bytes
            stride             += padding == 0 ? 0 : 4 - padding; // 4 byte multiple Alpha, Red, Green, Blue
            bits                = new byte[stride * height]; // total pixels (width) times ARGB (4) times Height
            handle              = GCHandle.Alloc(bits, GCHandleType.Pinned); // TO LOCK THE MEMORY
            bitPtr              = Marshal.UnsafeAddrOfPinnedArrayElement(bits, 0);
            bmp                 = new Bitmap(width, height, stride, format, bitPtr);
            g                   = Graphics.FromImage(bmp); // Para hacer pruebas regulares}
            rect                = new Rectangle(0, 0, bmp.Width, bmp.Height);
        }

        public void FastClear()
        {
            int div = 16;

            Parallel.For(0, bits.Length / div, i => // unrolling 
            {
                bits[(i * div) + 0] = 0;
                bits[(i * div) + 1] = 0;
                bits[(i * div) + 2] = 0;
                bits[(i * div) + 3] = 0;

                bits[(i * div) + 4] = 0;
                bits[(i * div) + 5] = 0;
                bits[(i * div) + 6] = 0;
                bits[(i * div) + 7] = 0;

                bits[(i * div) + 8] = 0;
                bits[(i * div) + 9] = 0;
                bits[(i * div) + 10] = 0;
                bits[(i * div) + 11] = 0;

                bits[(i * div) + 12] = 0;
                bits[(i * div) + 13] = 0;
                bits[(i * div) + 14] = 0;
                bits[(i * div) + 15] = 0;
            });
        }


        public void drawParalax()
        {
            g.DrawImage(layer0, l0_X0, 0, this.Width + 5, this.Height);
            g.DrawImage(layer0, l0_X1, 0, this.Width + 5, this.Height);
            g.DrawImage(layer0, l0_X2, 0, this.Width + 5, this.Height);

            g.DrawImage(layer1, l1_X0, this.Height - layer1.Height + 5, layer1.Width, layer1.Height);
            g.DrawImage(layer1, l1_X1, this.Height - layer1.Height + 5, layer1.Width, layer1.Height);
            g.DrawImage(layer1, l1_X2, this.Height - layer1.Height + 5, layer1.Width, layer1.Height);
        }
        public void Render(Scene scene, float deltaTime, Game game, DateTime lastWKeyPressTime, DateTime lastIKeyPressTime, TimeSpan delayTime)
        {
            FastClear();

            //renderizado de parallax
            BackgroundMove();
            g.DrawImage(layer0, l0_X0, 0, this.Width + 5, this.Height);
            g.DrawImage(layer0, l0_X1, 0, this.Width+5, this.Height);
            g.DrawImage(layer0, l0_X2, 0, this.Width+5, this.Height);

            g.DrawImage(layer1, l1_X0, this.Height - layer1.Height + 5, layer1.Width, layer1.Height);
            g.DrawImage(layer1, l1_X1, this.Height -layer1.Height +5, layer1.Width, layer1.Height);
            g.DrawImage(layer1, l1_X2, this.Height - layer1.Height+5, layer1.Width, layer1.Height);

            /*
            g.DrawImage(layer2, l2_X1, this.Height - (float)(layer2.Height * 1.2), (float)(layer2.Width * 1.2)+5,(float)(layer2.Height*1.2));
            g.DrawImage(layer2, l2_X2, this.Height - (float)(layer2.Height * 1.2), (float)(layer2.Width * 1.2)+5, (float)(layer2.Height * 1.2));
            g.DrawImage(layer2, l2_X3, this.Height - (float)(layer2.Height * 1.2), (float)(layer2.Width * 1.2)+5, (float)(layer2.Height * 1.2));*/

            scene.Render(g, size, bmp);

            camera.previousPoint.X = camera.point.X;
            camera.point.X = scene.getMiddlePoint(0, 1);
            int[,] matriz = map.Draw(camera.point, size, bmp, g);
            scene.extractLimits(matriz);
            game.Render(g, size.Width, size.Height, lastWKeyPressTime, lastIKeyPressTime, delayTime);

            //los bloques


            pctCanvas.Invalidate();
        }

        private void BackgroundMove()
        {
            if (l0_X0 < -this.Width)
            {
                l0_X0 = this.Width - motion0;
            }
            if (l0_X1 < -this.Width)
            {
                l0_X1 = this.Width - motion0;
            }
            if (l0_X2 < -this.Width)
            {
                l0_X2 = this.Width - motion0;
            }
            

            if (camera.previousPoint.X>camera.point.X)
            {
                motion0 = 0.5f;
            }
            else 
            {
                motion0 = 1;
            }
            l0_X0 -= motion0; l0_X1 -= motion0; l0_X2 -= motion0;


            if (l1_X0 < -this.Width)
            {
                l1_X0 = this.Width - motion1;
            }
            if (l1_X1 < -this.Width) 
            { 
                l1_X1 = this.Width - motion1; 
            }
            if (l1_X2 < -this.Width) 
            { 
                l1_X2 = this.Width - motion1; 
            }


            if (camera.previousPoint.X > camera.point.X)
            {
                motion1 = 1;
            }
            else
            {
                motion1 = 2;
            }

            l1_X0 -= motion1; l1_X1 -= motion1; l1_X2 -= motion1;

            /*
            if (l2_X1 < -layer2.Width)
            {
                l2_X1 = this.Width;
            }
            if (l2_X2 < -layer2.Width)
            {
                l2_X2 = this.Width;
            }
            if (l2_X3 < -layer2.Width)
            {
                l2_X3 = this.Width;
            }

            l2_X1 -= motion2;
            l2_X2 -= motion2;
            l2_X3 -= motion2;*/

        }
    }
}
