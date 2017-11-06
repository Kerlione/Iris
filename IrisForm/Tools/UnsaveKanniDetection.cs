using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    class UnsaveKanniDetection
    {
        enum Direction { HORIZONTAL, VERTICAL, PLUS_DIAGONAL, MINUS_DIAGONAL }

        public static void Detect(Bitmap b, float lowerThreshold, float uperThreshold)
        {
            Bitmap bSrc = (Bitmap)b.Clone();

            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;

            unsafe
            {
                byte* p, pOriginal = p = (byte*)(void*)bmData.Scan0;
                byte* pSrc, pSrcOriginal = pSrc = (byte*)(void*)bmSrc.Scan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width;
                int nHeight = b.Height;

                double[,] gradient = new double[b.Height, b.Width];
                double[,] nonMax = new double[b.Height, b.Width];
                Direction[,] directions = new Direction[b.Height, b.Width];
                

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        // For borders
                        if (y == 0 || y == nHeight - 1 || x == 0 || x == nWidth - 1)
                            p[0] = p[1] = p[2] = 0;
                        else
                        {
                            // Get matrix
                            float[,] P = new float[3, 3];
                            for (int j = 0; j < 3; j++)
                                for (int i = 0; i < 3; i++)
                                    P[j, i] = ToGray(pSrc + 3 * (i - 1) + stride * (j - 1));

                            double Dx = -P[0, 0] - 2 * P[0, 1] - P[0, 2] + P[2, 0] + 2 * P[2, 1] + P[2, 2];
                            double Dy = -P[0, 0] - 2 * P[1, 0] - P[2, 0] + P[0, 2] + 2 * P[1, 2] + P[2, 2];

                            nonMax[y, x] = gradient[y, x] = Math.Sqrt(Math.Pow(Dx, 2) * Math.Pow(Dy, 2)); // D
                            double GradientDirection = Math.Atan(Dx / Dy) * 180 / Math.PI;

                            // Get direction
                            if (((-22.5 < GradientDirection) && (GradientDirection <= 22.5)) || ((157.5 < GradientDirection) && (GradientDirection <= -157.5)))
                                directions[y, x] = Direction.HORIZONTAL;
                            else if (((-112.5 < GradientDirection) && (GradientDirection <= -67.5)) || ((67.5 < GradientDirection) && (GradientDirection <= 112.5)))
                            {
                                directions[y, x] = Direction.VERTICAL;
                            }
                            else if (((-67.5 < GradientDirection) && (GradientDirection <= -22.5)) || ((112.5 < GradientDirection) && (GradientDirection <= 157.5)))
                            {
                                directions[y, x] = Direction.PLUS_DIAGONAL;
                            }
                            else
                            {
                                directions[y, x] = Direction.MINUS_DIAGONAL;
                            }


                            //// Trashold
                            //if (D > lowerThreshold && D < uperThreshold)
                            //p[0] = p[1] = p[2] = 0;
                            //else
                            //    p[0] = p[1] = p[2] = 255;

                            if (gradient[y, x] < lowerThreshold || gradient[y, x] > uperThreshold)
                                gradient[y, x] = 0;
                            
                                


                        }

                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }

                // Refresh
                p = pOriginal;
                pSrc = pSrcOriginal;



                //for (int y = 0; y < nHeight; ++y)
                //{
                //    for (int x = 0; x < nWidth; ++x)
                //    {
                //        // Only for inside
                //        if (y != 0 && y != nHeight - 1 && x != 0 && x != nWidth - 1)
                //        {

                //            if ((directions[y, x] == Direction.HORIZONTAL && ((gradient[y, x] < gradient[y, x + 1]) || (gradient[y, x] < gradient[y, x - 1]))) ||
                //                (directions[y, x] == Direction.VERTICAL && ((gradient[y, x] < gradient[y - 1, x]) || (gradient[y, x] < gradient[y + 1, x]))) ||
                //                (directions[y, x] == Direction.PLUS_DIAGONAL && ((gradient[y, x] < gradient[y + 1, x - 1]) || (gradient[y, x] < gradient[y - 1, x + 1]))) ||
                //                (directions[y, x] == Direction.MINUS_DIAGONAL && ((gradient[y, x] < gradient[y + 1, x + 1]) || (gradient[y, x] < gradient[y - 1, x - 1]))))
                //                nonMax[y, x] = 255;

                //        }

                //        // Trashold
                //        if (nonMax[y, x] > lowerThreshold && nonMax[y, x] < uperThreshold)
                //            p[0] = p[1] = p[2] = 0;
                //        else
                //            p[0] = p[1] = p[2] = 255;


                //        p += 3;
                //        pSrc += 3;
                //    }
                //    p += nOffset;
                //    pSrc += nOffset;
                //}


                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        // Only for inside
                        if (y > 1 && y < nHeight - 2 && x > 1 && x < nWidth - 2)
                        {

                            //if (directions[y, x] == directions[y, x - 1] && directions[y, x] == directions[y, x + 1] && directions[y, x] == directions[y + 1, x - 1] && directions[y, x] == directions[y + 1, x + 1] &&
                            //    directions[y, x] == directions[y + 1, x] && directions[y, x] == directions[y - 1, x] && directions[y, x] == directions[y - 1, x - 1] && directions[y, x] == directions[y - 1, x + 1])
                                //p[0] = p[1] = p[2] = (byte)(gradient[y, x] >= 255 ? 255 : gradient[y, x]);
                            //else
                            //    p[0] = p[1] = p[2] = 0;

                            switch (directions[y, x])
                            {
                                case Direction.HORIZONTAL:
                                    if (gradient[y, x - 1] < gradient[y, x] && gradient[y, x + 1] < gradient[y, x])
                                        p[0] = p[1] = p[2] = 0;
                                    else
                                        p[0] = p[1] = p[2] = 255;
                                    break;

                                case Direction.VERTICAL:
                                    if (gradient[y - 1, x] < gradient[y, x] && gradient[y + 1, x] < gradient[y, x])
                                        p[0] = p[1] = p[2] = 0;
                                    else
                                        p[0] = p[1] = p[2] = 255;
                                    break;

                                case Direction.MINUS_DIAGONAL:
                                    if (gradient[y - 1, x - 1] < gradient[y, x] && gradient[y + 1, x + 1] < gradient[y, x])
                                        p[0] = p[1] = p[2] = 0;
                                    else
                                        p[0] = p[1] = p[2] = 255;
                                    break;

                                case Direction.PLUS_DIAGONAL:
                                    if (gradient[y + 1, x - 1] < gradient[y, x] && gradient[y - 1, x + 1] < gradient[y, x])
                                        p[0] = p[1] = p[2] = 0;
                                    else
                                        p[0] = p[1] = p[2] = 255;
                                    break;
                            }


                        }

                        // Trashold
                        //if (nonMax[y, x] > lowerThreshold && nonMax[y, x] < uperThreshold)
                        //    p[0] = p[1] = p[2] = 0;
                        //else
                        //    p[0] = p[1] = p[2] = 255;


                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }


            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);
        }

        static private unsafe float ToGray(byte* bgr)
        {
            return bgr[2] * 0.3f + bgr[1] * 0.59f + bgr[0] * 0.11f;
        }
    }
}
