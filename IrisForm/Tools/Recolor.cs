using System;
using System.Drawing;
using System.Drawing.Drawing2D;

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
        public static Bitmap ToGrey(Bitmap original)
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

        public static Image Resize(Image image, int newWidth, int maxHeight, bool onlyResizeIfWider) {
            if (onlyResizeIfWider && image.Width <= newWidth) newWidth = image.Width;

            var newHeight = image.Height * newWidth / image.Width;
            if (newHeight > maxHeight) {
                // Resize with height instead  
                newWidth = image.Width * maxHeight / image.Height;
                newHeight = maxHeight;
            }

            var res = new Bitmap(newWidth, newHeight);

            using (var graphic = Graphics.FromImage(res)) {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;
                graphic.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return res;
        }
    }
}
