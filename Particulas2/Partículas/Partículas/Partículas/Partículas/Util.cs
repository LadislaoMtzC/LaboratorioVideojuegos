using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Partículas;

namespace Particles
{
    public class Util
    {
        public Random Rand;
        public Image[] FIRE_IMGS, WAT_IMGS;
        List<Image> imgs;

        private static Util instance;

        public static Util Instance
        {
            get
            {
                if (Util.instance == null)
                    Util.instance = new Util();

                return Util.instance;
            }
        }

        public Util()
        {
            Rand = new Random();

            imgs = new List<Image>();
            imgs.Add(Resources.sfirei);
            imgs.Add(Resources.sFIREII);
            imgs.Add(Resources.sFIREIII);

            FIRE_IMGS = imgs.ToArray();

            imgs = new List<Image>();
            imgs.Add(Resources.WAT_I);
            imgs.Add(Resources.WAT_II);
            imgs.Add(Resources.WAT_iii);

            WAT_IMGS = imgs.ToArray();
        }

        public static Image ApplyAlpha(Image baseImage, float alpha)
        {
            // Asegúrate de que el valor de alpha esté en el rango [0, 1]
            alpha = Math.Max(0, Math.Min(1, alpha));

            // Crea un objeto ImageAttributes y establece el valor de la matriz de ajuste de color
            ImageAttributes imageAttributes = new ImageAttributes();
            float[][] colorMatrixElements = {
                new float[] {1, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 1, 0, 0},
                new float[] {0, 0, 0, alpha, 0},
                new float[] {0, 0, 0, 0, 1}
            };
            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            // Crea una nueva imagen con el mismo tamaño que la imagen base
            Image blendedImage = new Bitmap(baseImage.Width, baseImage.Height);

            // Dibuja la imagen base con el valor de transparencia aplicado
            using (Graphics g = Graphics.FromImage(blendedImage))
            {
                g.DrawImage(baseImage, new Rectangle(0, 0, baseImage.Width, baseImage.Height),
                            0, 0, baseImage.Width, baseImage.Height, GraphicsUnit.Pixel, imageAttributes);
            }

            return blendedImage;
        }

        public static Bitmap RotateImage(Image image, float angle)
        {
            // Crea una matriz de transformación de rotación
            Matrix matrix = new Matrix();
            matrix.RotateAt(angle, new PointF(image.Width / 2, image.Height / 2));

            // Crea un nuevo bitmap con el mismo tamaño que la imagen original
            Bitmap rotatedImage = new Bitmap(image.Width, image.Height);

            // Dibuja la imagen rotada en el nuevo bitmap
            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                // Aplica la matriz de transformación a la imagen
                g.Transform = matrix;

                // Dibuja la imagen rotada
                g.DrawImage(image, new PointF(0, 0));
            }

            return rotatedImage;
        }
    }
}