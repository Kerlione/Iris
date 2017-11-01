using System;
using System.Diagnostics;
using System.Drawing;

namespace Helpers {

    class Program {
        static void Main(string[] args) {

            //Console.WriteLine(" --- TESTING TIME TESTER ---");
            //TimeTester test = new TimeTester("Test");
            //test.SetTimer();

            //Console.WriteLine("Don't panic! I'm calculating pi 2 000 000 000 times to test TimeTester class...");
            //for (int i = 0; i < 2000000000; i++)
            //{
            //    float pi = 82 / 26;
            //}

            //test.StopTimer();

            //Console.WriteLine(test.GetStringTime());
            //test.WriteToFile();
            //Console.WriteLine(" --- END --- ");


            //Console.WriteLine(" --- TESTING EYE DETECTER CLASS ---");
            //TimeTester EyeTime = new TimeTester("Eye detection", "Eye detection");
            //EyeTime.SetTimer();
            //EyeDetecter.GetEyes("testingImage.jpg");
            //EyeTime.StopTimer();
            //Console.WriteLine(EyeTime.GetStringTime());
            //EyeTime.WriteToFile();
            //Console.WriteLine("Cuker!");
            //Console.WriteLine(" --- END --- ");


            //KanniAlgorithm.Filtr("eye.jpg");

            //for (int i = 10; i >= 0; i--)
            //{
            //    Bitmap image = new Bitmap("eye.jpg");
            //    EdgeDetection.Detect(image, i);
            //    image.Save("New_image(" + i + ").jpg");
            //}

            KanniAlgorithm.Filtr("eye.jpg");

            Console.WriteLine("That's all!");
            Console.ReadKey();
        }
    }
}
