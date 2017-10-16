using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class KanniAlgorithm
    {
        static readonly int[,] Dx = new int[3, 3]
        {
            { -1, -2, -1},
            { 0, 0, 0},
            { 1, 2, 1}
        };

        static readonly int[,] Dy = new int[3, 3]
        {
            { -1, 0, 1},
            { -2, 0, 2},
            { -1, 0, 1}
        };

        static Bitmap image;
        static Bitmap newImage;

        public static void Filtr(string path)
        {
            image = new Bitmap(path);
            newImage = new Bitmap(image);

            for (int y = 0; y < image.Width; y++)
                for (int x = 0; x < image.Height; x++)
                {
                    int color = (int)Math.Sqrt(Math.Pow(G(y, x, true),2) + Math.Pow(G(y, x, false), 2));

                    if (color < 0) color = 0;
                    else if (color > 255) color = 255;

                    newImage.SetPixel(y, x, Color.FromArgb(color, color, color));
                }

            newImage.Save("New_image.jpg");

        }

        static int G(int i, int j, bool dx)
        {
            if (i <= 0 || j <= 0 || i >= image.Width - 1 || j >= image.Height - 1)
                return 0;
            else
            {
                float sum = 0;

                for (int y = 0; y < 3; y++)
                    for (int x = 0; x < 3; x++)
                    {
                        sum += (dx ? Dx[y, x] : Dy[y, x]) * image.GetPixel(i - 1 + 1 * x, j - 1 + 1 * y).R;
                    }
                

                return (int) sum;
            }
        }
    }
}
