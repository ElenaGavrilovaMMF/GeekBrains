using System;
using System.IO;
using ArrayLibrary;

namespace Homework_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            #region TASK 1
            //1. Дан целочисленный массив из 20 элементов.
            //Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
            //Заполнить случайными числами.
            //Написать программу, позволяющую найти и вывести количество пар элементов массива,
            //в которых только одно число делится на 3. В данной задаче под парой подразумевается
            //два подряд идущих элемента массива.
            //Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
            Console.WriteLine("------------------TASK 1 ---------------");
            int[] arr = new int[20];
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-10000, 10001);
                Console.Write(arr[i] + " ");
            }

            int count = 0;
            string result = "";
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if ((arr[i] % 3 == 0 && arr[i + 1] % 3 != 0) || (arr[i + 1] % 3 == 0 && arr[i] % 3 != 0))
                {
                    result += "[" + arr[i] + " " + arr[i + 1] + "] ";
                    count++;
                }
            }

            Console.WriteLine("\nКоличество пар: " + count);
            Console.WriteLine("Список пар: "+ result);
            
            #endregion

            #region TASK2
            //2. Реализуйте задачу 1 в виде статического класса StaticClass;
            //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
            //б) Добавьте статический метод для считывания массива из текстового файла.
            //Метод должен возвращать массив целых чисел;
            //в)*Добавьте обработку ситуации отсутствия файла на диске.
            
            Console.WriteLine("------------------TASK 2 ---------------");
            Console.WriteLine("Используем масссив из задания 1 (удобно сверить ответ)");
            Console.WriteLine("Количетво пар: "+ StaticClass.GetFirstTaskAnswer(arr));
            Console.WriteLine("Массив, считаный из файла: ");
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "array";
            int[] arrTask3 = StaticClass.ReadArrayFromFile(fileName);
            foreach (int element in arrTask3)
            {
                Console.Write(element +" ");
            }

            #endregion
            
            #region TASK3
            //а) Дописать класс для работы с одномерным массивом.
            //Реализовать конструктор, создающий массив определенного размера и
            //заполняющий массив числами от начального значения с заданным шагом.
            //Создать свойство Sum, которое возвращает сумму элементов массива,
            //метод Inverse,возвращающий новый массив с измененными знаками у всех элементов массива
            //(старый массив, остается без изменений),
            //метод Multi, умножающий каждый элемент массива на определённое число, свойство
            //MaxCount, возвращающее количество максимальных элементов.
            //б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
            
            Console.WriteLine("\n------------------TASK 3 ---------------");
            Console.WriteLine("Задание сделано сразу пунктом б) - используя библеотеку ArrayLibrary");

            int size = 6;
            int startValue = 3;
            int step = 4;
            int multiValue = 2;
            MyArray arrayTask3 = new MyArray(size, startValue, step);
            Console.WriteLine($"Конструктор, создающий массив размера {size},начиная с элемента {startValue} и шагом {step}: ");
            Console.WriteLine(arrayTask3.ToString());
            Console.WriteLine("Свойство Sum: ");
            Console.WriteLine(arrayTask3.Sum);
            Console.WriteLine("Метод Inverse: ");
            StaticClass.PrintArray(arrayTask3.Inverse());
            Console.WriteLine($"\nМетод Multi умножает на {multiValue}: ");
            StaticClass.PrintArray(arrayTask3.Multi(multiValue));
            Console.WriteLine("\nСвойство MaxCount - количество максимальних элементов массива: ");
            Console.WriteLine(arrayTask3.MaxCount);

            #endregion
            
        }
    }

    static class StaticClass
    {
        public static int GetFirstTaskAnswer(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if ((arr[i] % 3 == 0 && arr[i + 1] % 3 != 0) || (arr[i + 1] % 3 == 0 && arr[i] % 3 != 0))
                {
                    count++;
                }
            }

            return count;
        }
        
        public static int[] ReadArrayFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader streamReader = new StreamReader(fileName);
                int[] arr = new int [1000];
                int counter = 0;
                while (!streamReader.EndOfStream)
                {
                    arr[counter] = Convert.ToInt32(streamReader.ReadLine());
                    counter++;
                }

                int[] temp = new int [counter];
                Array.Copy(arr,temp,counter);
                streamReader.Close();

                return temp;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public static void PrintArray(int[] arr)
        {
            foreach (int element in arr)
            {
                Console.Write(element+" ");
            }
        }
        
    }
}