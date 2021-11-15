using System;

namespace Homework_3
{
    class Program
    {
        static int Sample(out int a)
        {
            a = 12;
            return 1;
        }

        static void DoProcess(ref int a, ref int b, ref int c, string s)
        {
            a = -a;
            b = -b;
            c = -c;
        }

        static void Main(string[] args)
        {
            int x = 11;
            int y = -5;
            int z = 1;
            string s = "Hello!";


            DoProcess(ref x, ref y, ref z, s);

            Console.WriteLine("Введите число:");
            int number;

            if (int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine($"Вы ввели число: {number}");
            }
            else
            {
                Console.WriteLine("Вы ввели некорректное число.");
            }
            
            Console.ReadKey();
        }
    }
}