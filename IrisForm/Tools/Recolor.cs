using System;
using System.Drawing;

namespace Tools
{
    public class Recolor
    {
        public Recolor()
        {
        }

        /// <summary>
        /// Change the picture color to grey
        /// </summary>
        /// <returns>Bitmap picture in grey</returns>
        /// <param name="original">Original picture, passed to convert.</param>
        public Bitmap ToGrey(Bitmap original)
        {
            var greyedPicture = new Bitmap(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++){
                for (int y = 0; y < original.Height;y++){
                    Color pixel = original.GetPixel(x, y);
                    int greyScale = (int)((pixel.R * 0.299) + (pixel.B * 0.114) + (pixel.G * 0.587));
                    Color newColor = Color.FromArgb(pixel.A,greyScale,greyScale,greyScale);
                    greyedPicture.SetPixel(x,y,newColor);
                }
            }

            return greyedPicture;
        }
    }
}
