using System;

namespace Homework3_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int userValue;
            int sum = 0;
            string numbers = "";
            Console.WriteLine("Вводите целые числа через Enter. \nВведите 0 для завершения.");

            do
            {
                if (int.TryParse(Console.ReadLine(), out userValue))
                {
                    if (userValue % 2 != 0 && userValue > 0)
                    {
                        sum += userValue;
                        numbers += userValue + " ";
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели некорректное число. \nПопробуйте еще раз или введите 0 для завершения.");
                }
            } while (userValue != 0);

            Console.WriteLine($"Положительные нечетные числа: {numbers}");
            Console.WriteLine($"Их сумма: {sum}");
            
        }
    }
}