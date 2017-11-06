using System;
using System.Diagnostics;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using OpenTK.Graphics.ES11;

namespace Helpers {

    class Program {
        static void Main(string[] args) {



            //Bitmap b = new Bitmap("eye.jpg");
            //EdgeDetection.Detect(b, 6);
            //b.Save("EdgeDetection.jpg");
            //Console.WriteLine("Unasve end!");
            //KanniAlgorithm.Filtr("testingImage.jpg");

            

            //for (int j = 0; j < 255; j += 3)
            //    for (int i = 255; i > j; i -= 3)
            //    {
            //        b.Dispose();
            //        b = new Bitmap("eye.jpg");
            //        UnsaveKanniDetection.Detect(b, j, i);
            //        b.Save("Kanni//" + j + "x" + i + ".jpg");
            //        Console.WriteLine(j + "x" + i + " - completed!");
            //    }
            
            Bitmap img = new Bitmap("eye.jpg");
            Image<Bgr,Byte> temp = new Image<Bgr, byte>(img);
            UnsaveKanniDetection.Detect(img,0,255);
            Image<Gray,Byte> gray = new Image<Gray, byte>(img);
            
            CircleF[] circles = 
            CvInvoke.HoughCircles(gray, HoughType.Gradient, 1.0, 150);
            Image<Bgr, Byte> circleImage = temp.Copy();
            foreach (CircleF circle in circles)
            {
                circleImage.Draw(circle,new Bgr(Color.Yellow),2);
            }
            circleImage.Save("result.jpg");
            Console.WriteLine("That's all!");
            Console.ReadKey();       
        }
    }
}
