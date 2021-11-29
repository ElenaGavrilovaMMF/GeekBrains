using System;
using System.IO;

namespace Homework6_t2
{
    public delegate double Task2(double x, double a);
    
    class Program
        {
            public static Task2[] arrayFunctions = {Parabola, Sin, Cos};
            static double Parabola(double x, double a)
            {
                return a * Math.Pow(x, 2);
            }
        
            static double Sin(double x, double a)
            {
                return a * Math.Sin(x);
            }
            
            static double Cos(double x, double a)
            {
                return a * Math.Cos(x);
            }
            
            public static void SaveFunc(Task2 function, string fileName, double x0, double x1, double a, double h)
            {
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                Console.WriteLine("----- X ----- Y -----");
                while (x0 <= x1)
                {
                    Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x0, function(x0, a));
                    bw.Write(function(x0, a));
                    x0 += h;// x=x+h;
                }
                Console.WriteLine("---------------------");
                bw.Close();
                fs.Close();
            }
            public static double[] Load(string fileName, out double min)
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader bw = new BinaryReader(fs);
                double[] arrayY = new double[fs.Length / sizeof(double)]; 
                min = double.MaxValue;
                double d;
                for(int i=0;i<fs.Length/sizeof(double);i++)
                {
                    d = bw.ReadDouble();
                    arrayY[i] = d;
                    if (d < min) min = d;
                }
                bw.Close();
                fs.Close();
                return arrayY;
            }

            public static void PrintFunction(Task2[] array)
            {
                int i = 1;
                foreach (Task2 value in array)
                {
                    Console.WriteLine(i + ": " + value.Method.Name);
                    i++;
                }
            }

            public static void PrintArray(double[] array)
            {
                foreach (double value in array)
                {
                    Console.Write(value +" ");
                }
            }
            
            static void Main(string[] args)
            {
                PrintFunction(arrayFunctions);
                Console.WriteLine("Введите соответсвующее число для выбора функции:");
                int funcID = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("Введите отрезок для поиска минимума:");
                Console.Write("x0 = ");
                double x0 = Convert.ToDouble(Console.ReadLine());
                Console.Write("x1 = ");
                double x1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"[{x0}, {x1}]");
                
                double coeffA = 1;
                double step = 1;
                Console.WriteLine($"Функции с коэффициентом а = {coeffA} и шагом {step}");

                if (funcID < arrayFunctions.Length)
                {
                    Task2 function =  arrayFunctions[funcID - 1];
                    SaveFunc(function, "data.bin", x0, x1, coeffA,  step);
                    Console.WriteLine("Значения функции как результат метода Load - задание 2б)");
                    PrintArray(Load("data.bin", out double min));
                    Console.WriteLine("\nМинимум (Y): " + min);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Такой функции нет. Проверьте выбранное значение.");
                }
                
            }
        }
}

    