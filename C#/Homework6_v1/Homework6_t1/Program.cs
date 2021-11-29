using System;

namespace Homework6_t1
{
    public delegate double Task1(double x, double a);

    class Program
    {
        public static void Table(Task1 function, double startX, double coeffA, double finishX)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (startX <= finishX)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", startX, function(startX, coeffA));
                startX += 1;
            }
            Console.WriteLine("---------------------");
        }

        static double Parabola(double x, double a)
        {
            return a * Math.Pow(x, 2);
        }
        
        static double Sin(double x, double a)
        {
            return a * Math.Sin(x);
        }

        static void Main()
        {
            double a = 2;
            double finishX = 2;
            double startX = -2;
            
            Console.WriteLine("Таблица функции a*x^2:");
            Table(Parabola,startX, a, finishX);                 
            Console.WriteLine("Таблица функции a*sin(x)");
            Table(Sin, startX, a, finishX);
        }
    }
}