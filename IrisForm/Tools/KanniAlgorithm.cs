using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Helpers
{
    public static class KanniAlgorithm
    {
        const int LowerBorder = 120;
        const int UpperBorder = 140;

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
            image = Recolor.ToGrey(new Bitmap(path));
            newImage = new Bitmap(image);

            for (int y = 0; y < image.Width; y++)
                for (int x = 0; x < image.Height; x++)
                {
                    double Gx = G(y, x, true);
                    double Gy = G(y, x, false);

                    //int color = (int)Math.Sqrt(Math.Pow(Gx,2) + Math.Pow(Gy, 2));

                    //Console.WriteLine(Math.Atan(Gx/Gy) * 180 / Math.PI * 2 + 180 + 22.5);

                    try
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if ((Math.Atan(Gx / Gy) * 180 / Math.PI * 2 + 180 + 22.5) < ((i + 1) * 45))
                            {
                                Console.Write(i);
                                switch (i)
                                {
                                    case 0:
                                        newImage.SetPixel(y, x, Color.Red);
                                        break;

                                    case 1:
                                        newImage.SetPixel(y, x, Color.Orange);
                                        break;

                                    case 2:
                                        newImage.SetPixel(y, x, Color.Yellow);
                                        break;

                                    case 3:
                                        newImage.SetPixel(y, x, Color.Green);
                                        break;

                                    case 4:
                                        newImage.SetPixel(y, x, Color.LightBlue);
                                        break;

                                    case 5:
                                        newImage.SetPixel(y, x, Color.Blue);
                                        break;

                                    case 6:
                                        newImage.SetPixel(y, x, Color.Purple);
                                        break;

                                    case 7:
                                        newImage.SetPixel(y, x, Color.Brown);
                                        break;
                                }
                                break;
                            }
                        }
                    }
                    catch (Exception)
                    { }

                    //if (color < LowerBorder) color = 0;
                    //if (color > UpperBorder) color = 225;

                    //newImage.SetPixel(y, x, Color.FromArgb(color, color, color));
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
