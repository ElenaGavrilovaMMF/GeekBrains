using System;

namespace Homework_2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TASK 1
            //1. Написать метод, возвращающий минимальное из трёх чисел.
            
                Console.WriteLine("\n-----------TASK 1---------");
                Console.WriteLine("Введите три числа:");
                float firstNumber = float.Parse(Console.ReadLine());
                float secondNumber = float.Parse(Console.ReadLine());
                float thirdNumber = float.Parse(Console.ReadLine());
                Console.WriteLine($"Числа: {firstNumber}, {secondNumber}, {thirdNumber}");
                Console.WriteLine("Минимальное: " + GetMinNumber(firstNumber,secondNumber,thirdNumber));
           
            #endregion

            #region TASK 2
            //2. Написать метод подсчета количества цифр числа.
                Console.WriteLine("\n-----------TASK 2---------");
                Console.WriteLine("Введите число для подсчета его длинны:");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("Длинна введенного числа: " + GetNumberLength(number));
            
            #endregion

            #region TASK 3
            // С клавиатуры вводятся числа, пока не будет введен 0.
            // Подсчитать сумму всех нечетных положительных чисел.
                Console.WriteLine("\n-----------TASK 3---------");
                Console.WriteLine("Вводите числа через Enter и 0 для завершения:");
                int sum = 0;
                do
                {
                    number = int.Parse(Console.ReadLine());
                    if (number % 2 != 0 && number > 0)
                    {
                        sum += number;
                    }
                } while (number != 0);
                Console.WriteLine("Сумма введеных нечетных положительных чисел: {0}", sum);
            #endregion

            #region TASK 4

            //4. Реализовать метод проверки логина и пароля.
            //На вход метода подается логин и пароль.
            //На выходе истина, если прошел авторизацию, и ложь,
            //если не прошел (Логин: root, Password: GeekBrains).
            //Используя метод проверки логина и пароля, написать программу:
            //пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
            //С помощью цикла do while ограничить ввод пароля тремя попытками.
            
                Console.WriteLine("\n-----------TASK 4---------");
                Console.WriteLine("Пройдите авторизацию (у вас три попытки):");
                int count = 3;
                bool result;
                do
                {   
                    Console.Write("Логин: ");
                    string login = Console.ReadLine();
                    Console.Write("Пароль: ");
                    string password = Console.ReadLine();
                    result = Authorization(login, password);
                    count--;
                    if (!result)
                    {
                        Console.WriteLine("Неправильный логин или пароль.");
                    }
                    else
                    {
                        Console.WriteLine("Вы зашли в систему!");
                    }
                } while (count > 0 && !result);

                if (count==0)
                {
                    Console.WriteLine("Ваш аккаунт заблокирован!");
                }

            #endregion

            #region TASK 5
            //а) Написать программу, которая запрашивает массу и рост человека,
            //вычисляет его индекс массы и сообщает, нужно ли человеку похудеть,
            //набрать вес или всё в норме.
            //б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
                Console.WriteLine("\n-----------TASK 5---------");
                double bmiMax = 24.9;
                double bmiMin = 18.5;
            
                Console.Write("Введите вес (кг): ");
                double weight = double.Parse(Console.ReadLine());
                Console.Write("Введите рост (м): ");
                double height = double.Parse(Console.ReadLine());
            
                double bmi = Math.Round(weight / (height*height),1);
                Console.WriteLine($"Ваш ИМТ: {bmi}");
            
                if (bmi > bmiMax)
                {
                    double rigthWeigth = Math.Round((height * height) * bmiMax,1);
                    Console.WriteLine($"Вам нужно сбросить {weight - rigthWeigth} кг до максимальной нормы ({rigthWeigth} кг)!");
                } else if (bmi < bmiMin)
                {
                    double rigthWeigth = Math.Round((height * height) * bmiMin);
                    Console.WriteLine($"Вам набрать вес {rigthWeigth - weight} кг до минимальной нормы ({rigthWeigth} кг)!");
                }
                else
                {
                    Console.WriteLine("Ваш вес в норме!");
                }

            #endregion

            #region TASK 6
            //*Написать программу подсчета количества «хороших» чисел в диапазоне
            //от 1 до 1 000 000 000.
            //«Хорошим» называется число, которое делится на сумму своих цифр.
            //Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
                Console.WriteLine("\n-----------TASK 6---------");
                int starTime = DateTime.Now.Millisecond;
                    GetCountGoodNumbers();
                int endTime = DateTime.Now.Millisecond;
                Console.WriteLine($"Время выполнения задачи 6: {endTime - starTime} миллисекунд.");
            #endregion

            #region TASK 7
            //a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
            //б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
                Console.WriteLine("\n-----------TASK 7---------");
                Console.WriteLine("Введите два числа через Enter");
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                GetNumbersRecursion(a, b);
                Console.WriteLine("\nСумма чисел от а до b: ");
                Console.WriteLine(GetSumNumbersRecursion(a, b));

            #endregion
        }

        private static float GetMinNumber(float firstNumber, float secondNumber, float thirdNumber)
        {
            if (firstNumber > secondNumber) firstNumber = secondNumber;
            if (firstNumber > thirdNumber) firstNumber = thirdNumber;

            return firstNumber;
        }

        private static int GetNumberLength(int number)
        {
            int count = 0;
            while (number!=0)
            {
                number /= 10;
                count++;
            }
            return count;
        }

        private static bool Authorization(string login, string password)
        {
            string rigthLogin = "root";
            string rigthPasswor = "GeekBrains";
            if (login == rigthLogin && password == rigthPasswor) return true;
            return false;
        }
        
        static void GetCountGoodNumbers()
        {
            int startNumber = 1;
            int endNumber = 1000000;
            int count = 0;
 
            for (int i = startNumber; i <= endNumber; i++)
            {
                int tempNumber = i;
                int sum = 0;
                while (tempNumber != 0)
                {
                    sum += tempNumber % 10;
                    tempNumber /= 10;
                }
                
                if (i % sum == 0) count ++;
            }
            Console.WriteLine($"Количество \"Хороших чисел\": {count}");
        }

        static void GetNumbersRecursion(int a, int b)
        {
            if (a<=b)
            {
                Console.Write(a +" ");
                a++;
                GetNumbersRecursion(a,b);
            }
        }
        
        static int GetSumNumbersRecursion(int a, int b)
        {
            if (b == a) return b;
            return b + GetSumNumbersRecursion(a, b - 1);
        }
    }
}