using System;
using System.Diagnostics;
using System.Drawing;

namespace Helpers {

    class Program {
        static void Main(string[] args) {



            //Bitmap b = new Bitmap("eye.jpg");
            //EdgeDetection.Detect(b, 6);
            //b.Save("EdgeDetection.jpg");
            //Console.WriteLine("Unasve end!");
            //KanniAlgorithm.Filtr("testingImage.jpg");

            Bitmap b = new Bitmap("eye.jpg");

            UnsaveKanniDetection.Detect(b, 0, 255);
            b.Save("UltraTest.jpg");

            //for (int j = 0; j < 255; j += 3)
            //    for (int i = 255; i > j; i -= 3)
            //    {
            //        b.Dispose();
            //        b = new Bitmap("eye.jpg");
            //        UnsaveKanniDetection.Detect(b, j, i);
            //        b.Save("Kanni//" + j + "x" + i + ".jpg");
            //        Console.WriteLine(j + "x" + i + " - completed!");
            //    }

            Console.WriteLine("That's all!");
            Console.ReadKey();
        }
    }
}
