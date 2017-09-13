using System;
using System.Diagnostics;

namespace Helpers {

    class Program {
        static void Main(string[] args) {

            Console.WriteLine(" --- TESTING TIME TESTER ---");
            TimeTester test = new TimeTester("Test");
            test.SetTimer();

            Console.WriteLine("Don't panic! I'm calculating pi 2 000 000 000 times to test TimeTester class...");
            for (int i = 0; i < 2000000000; i++)
            {
                float pi = 82 / 26;
            }

            test.StopTimer();

            Console.WriteLine(test.GetStringTime());
            test.WriteToFile();
            Console.WriteLine(" --- END --- ");


            Console.WriteLine(" --- TESTING EYE DETECTER CLASS ---");
            EyeDetecter.GetEyes("testingImage.jpg");
            Console.WriteLine("Cuker!");
            Process.Start(new ProcessStartInfo("Eyes.jpg"));
            Console.WriteLine(" --- END --- ");

            Console.WriteLine("That's all!");
            Console.ReadKey();
        }
    }
}
