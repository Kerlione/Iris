using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Collections.Generic;
using System.Drawing;

namespace Helpers
{
    public static class EyeDetecter
    {


        public static void Detect(IInputArray image, string eyeHaarCascade, List<Rectangle> eyes)
        {
            CascadeClassifier eye = new CascadeClassifier(eyeHaarCascade);

            UMat gray = new UMat();

            CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);
            CvInvoke.EqualizeHist(gray, gray);

            Rectangle[] eyesDetected = eye.DetectMultiScale(gray, 1.1, 10, new Size(20, 20));
            eyes.AddRange(eyesDetected);

            foreach (Rectangle e in eyesDetected)
                eyes.Add(e);
        }

        public static void GetEyes(string path)
        {
            IImage image;
            //image = new UMat(path, );

        }
    }
}
