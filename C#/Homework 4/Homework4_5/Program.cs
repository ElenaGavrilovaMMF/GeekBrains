using System;
using TwoDimensionalArrayLibrary;

namespace Homework4_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //а) Реализовать библиотеку с классом для работы с двумерным массивом.
            //Реализовать конструктор, заполняющий массив случайными числами.
            //Создать методы, которые возвращают сумму всех элементов массива,
            //сумму всех элементов массива больше заданного, свойство,
            //возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива,
            //метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
            //*б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
            //**в) Обработать возможные исключительные ситуации при работе с файлами.
            
            TwoDimensionalArray twoDimensionalArray1 = new TwoDimensionalArray(3, 4, -10, 10);
            Console.WriteLine("Случайный массив: ");
            Console.WriteLine(twoDimensionalArray1.ToString());
            twoDimensionalArray1.Write("output.txt");
            
            Console.WriteLine($"\nСумма всех элементов: {twoDimensionalArray1.Sum()}");
            int checkSum = 0;
            Console.WriteLine($"Сумма всех элементов больше {checkSum}: {twoDimensionalArray1.Sum(checkSum)}");
            Console.WriteLine($"Свойство минимальный элемент: {twoDimensionalArray1.Min}\n" +
                              $"Свойство максимальный элемент: {twoDimensionalArray1.Max}");
            TwoDimensionalArray twoDimensionalArray2 = new TwoDimensionalArray(twoDimensionalArray1.GetMaxValueIndex());
            Console.WriteLine($"Метод находит индексы всех максимальных (в массиве может же быть три максимальные 9ки, например):" +
                              $"\n{twoDimensionalArray2}");
            int maxValue = -2;
            TwoDimensionalArray twoDimensionalArray3 = new TwoDimensionalArray(twoDimensionalArray1.GetMaxValueIndex(out maxValue));
            Console.WriteLine($"Пример с модификатором out. Логика странная, зато пример наглядный. \nМетод внутри перезапишет максимальное значение, которое ввел пользователь (вдруг пользователь ерунду ввел):" +
                              $"\n{twoDimensionalArray3}");
            int[][] arrWithDoubleMax = new int[2][];
            arrWithDoubleMax[0] = new[] {1, 2, 3, 99};
            arrWithDoubleMax[1] = new[] {5, 1, 99, 4, 7};
            TwoDimensionalArray twoDimensionalArray4 = new TwoDimensionalArray(arrWithDoubleMax);
            
            Console.WriteLine($"Или, например, нахождение индексов нескольких максимальных значений для массива: \n{twoDimensionalArray4}");
            TwoDimensionalArray twoDimensionalArray5 = new TwoDimensionalArray(twoDimensionalArray4.GetMaxValueIndex());
            Console.Write($"Индексы максимальных:\n{twoDimensionalArray5}");
            
            Console.WriteLine("\nДвумерный массив, считанный из Input.txt");
            TwoDimensionalArray twoDimensionalArray = new TwoDimensionalArray("input.txt");
            Console.WriteLine(twoDimensionalArray.ToString());
        }
    }
}