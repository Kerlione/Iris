using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using OpenTK.Graphics.ES11;

//COnvert image to array of pixels - crap



namespace Daugman
{
    public class Helpers
    {
        /// <summary>
        /// The method for getting iris template from image loaded
        /// </summary>
        /// <param name="img">Image loaded</param>
        /// <param name="arr">Pointer to array to store template</param>
        /// <param name="template">Binary iris biometric template</param>
        /// <param name="mask">Binary iris noise mask</param>
        public void CreateIrisTemplate(Image img,Array[,] arr,int template, int mask)
        {
            
        }

        public void SegmentIris(Image img, Array[,,] arr)
        {
            
        }

        public void SearchInnerBoundary(Bitmap img)
        {
            var X = img.Width;
            var Y = img.Height;
            var sect = X / 4;
            var minrad = 10;
            var maxrad = sect * 0.8;
            var jump = 4;
            var hy = (Y - 2 * sect) / jump;
            var hx = (X - 2 * sect) / jump;
            var hr = (maxrad-minrad) / jump;
            uint[,,] hs = new uint[(int) Math.Floor((double) hy),(int) Math.Floor((double) hx),(int) Math.Floor(hr)];
            int integrationPrecision = 1;
            var angs = RangeIncrement(0, 2 * Math.PI, integrationPrecision);
            for (int x = 0; x < (int) Math.Floor((double) hx); x++)
            {
                for (int y = 0; y < (int) Math.Floor((double) hy); y++)
                {
                    for (int r = 0; r < (int) Math.Floor(hr); r++)
                    {
                        ContourIntegralCircuit(img, sect + y * jump, sect + x * jump, minrad + r * jump,
                            angs);
                    }
                }
            }

            uint[,,] hspdr = new uint[(int) Math.Floor((double) hy), (int) Math.Floor((double) hx),
                (int) Math.Floor(hr)];
            
        }

        public uint ContourIntegralCircuit(Bitmap img, double y_0, double x_0, double r, List<double> angs)
        {
            uint sum=0;
            foreach (var ang in angs)
            {
                var y = Math.Round(y_0 - Math.Cos(ang) * r);
                var x = Math.Round(x_0 + Math.Sin(ang) * r);
                if (y < 1) y = 1;
                else if (y > img.Height) y = img.Height;
                if (x < 1) x = 1;
                else if (x > img.Width) x = img.Width;
                sum = sum + ColorToUInt(img.GetPixel((int)x, (int)y));
            }
            return sum;
        }
                
        public static List<double> RangeIncrement(double start, double end, double increment)
        {
            return Enumerable
                .Repeat(start, (int) ((end - start) / increment) + 1)
                .Select((tr, ti) => tr + (increment * ti))
                .ToList();
        }
        
        
        private uint ColorToUInt(Color color)
        {
            return (uint)((color.A << 24) | (color.R << 16) |
                          (color.G << 8)  | (color.B << 0));
        }
    }
}