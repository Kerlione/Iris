using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Helpers
{
    public static class EyeDetecter
    {


        private static void Detect(IInputArray image, string eyeHaarCascade, List<Rectangle> eyes)
        {
            CascadeClassifier eye = new CascadeClassifier(eyeHaarCascade);

            UMat gray = new UMat();

            CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);
            CvInvoke.EqualizeHist(gray, gray);

            Rectangle[] eyesDetected = eye.DetectMultiScale(gray, 1.1, 10, new Size(20, 20));
            eyes.AddRange(eyesDetected);

            
        }

        public static void GetEyes(string path)
        {
            IImage image = new UMat(path, ImreadModes.Color);
            List<Rectangle> eyes = new List<Rectangle>();

            Detect(image, "haarcascade_eye.xml", eyes);
            int i = 1;
            if (!Directory.Exists("Eyes/"))
                Directory.CreateDirectory("Eyes");

            foreach (Rectangle eye in eyes)
            {
                CvInvoke.Rectangle(image, eye, new Bgr(Color.Red).MCvScalar, 2);

                Image<Gray, byte> eyeImage = new Image<Gray, byte>(path);
                eyeImage.ROI = eye;
                eyeImage.Save("Eyes//" + i + ".jpg");
                i++;
            }
                

            image.Save("Eyes//Eyes.jpg");
        }
    }
}
