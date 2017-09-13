using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers {

    class Program {
        static void Main(string[] args) {

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

            Console.WriteLine("That's all!");
            Console.ReadKey();
        }
    }
}
