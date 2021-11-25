using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;

namespace Homework_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            #region TASK 1
            
            //1. Создать программу, которая будет проверять корректность ввода логина.
            //Корректным логином будет строка от 2 до 10 символов,
            //содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
            //а) без использования регулярных выражений;
            //б) **с использованием регулярных выражений.
            Console.WriteLine("-----------------------TASK1----------------------");

            Console.WriteLine("Придумайте логин: от 2х до 10 символов включительно, не начинающийся с цифры и содержащий буквы латинского алфавита ИЛИ цифры.");
            string login = Console.ReadLine();
            
            Console.WriteLine("Результат проверки без использования регулярных выражений");
            ShowLoginTestResult(CheckLoginWithoutRegex(login));
            
            Console.WriteLine("Результат проверки с использованием регулярных выражений");
            ShowLoginTestResult(CheckLoginWithRegex(login));

            #endregion
            

            #region TASK2
            //2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
            //a) Вывести только те слова сообщения, которые содержат не более n букв.
            //б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
            //в) Найти самое длинное слово сообщения.
            //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
            Console.WriteLine("-----------------------TASK2----------------------");
            Console.WriteLine("Введите текст для тестирвоания:");
            string text = Console.ReadLine();
            int count = 3;
            Console.WriteLine($"\nСлова не больше {count} символовов.");
            Message.CheckMessageWithNumber(text, count);
            char symbol = 'м';
            Console.WriteLine($"\nУдалить слова, которые заканчиваются на {symbol}. Удаляла прям в исходнике, чтобы немного потренировать ref");
            Message.DeleteWordsWithSymbol(ref text, symbol);
            Console.WriteLine(text);
            Console.WriteLine("\nВыводит одно самое длинное слово. Если будет несколько одинаковой длинны, выведет первое. \nСделала так, потому что иначе задача получается почти такойже как следующая у меня по решению.");
            Console.WriteLine(Message.FindLongestWords(text));
            Console.WriteLine($"\nStringBuilder с самыми длинными словами массива");
            Console.WriteLine(Message.FindLongestWordsStringBuilder(text));
            #endregion
            
        }

        public static bool CheckLoginWithoutRegex(string login)
        {
            bool result = false;
            if (login.Length >= 2 && login.Length <= 10)
            {
                if (char.IsLetter(login[0]))
                {
                    foreach (char letter in login)
                    {
                        if(letter>=65 && letter<=90 || letter>=97 && letter<=122 || letter>=48 && letter<=57)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        public static bool CheckLoginWithRegex(string login)
        {
            string regex = @"^[a-z]([0-9a-z]{1,9})$";
            
            if (Regex.IsMatch(login, regex, RegexOptions.IgnoreCase)) return true;

            return false;
        }
        
        public static void ShowLoginTestResult(bool isLogin)
        {
            Console.WriteLine(isLogin ? "Логин подходит." : "Логин не подходит.");
        }
    }

    static class Message
    {
        private static Regex regex = new Regex(@"\b(\w+)\b", RegexOptions.IgnoreCase);

        public static void CheckMessageWithNumber(string message, int lettersCount)
        {
            MatchCollection matches = regex.Matches(message);
         
            foreach (Match match in matches)
            {
                if (match.Value.Length <= lettersCount)
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
        
        public static void DeleteWordsWithSymbol(ref string message, char symbol)
        {
            MatchCollection matches = regex.Matches(message);
            string result = "";
            foreach (Match match in matches)
            {
                if (match.Value[match.Value.Length-1] != symbol)
                {
                    result += match.Value + " ";
                }
            }

            message = result;
        }
        
        public static StringBuilder FindLongestWordsStringBuilder(string message)
        {
            MatchCollection matches = regex.Matches(message);
            int wordLength = 0;
            foreach (Match match in matches)
            {
                if (match.Value.Length >= wordLength) wordLength = match.Value.Length;
            }

            StringBuilder stringBuilder = new StringBuilder();
            foreach (Match match in matches)
            {
                if (match.Value.Length == wordLength) stringBuilder.Append(match.Value +" ");
            }
            return stringBuilder;
        }
        
        public static string FindLongestWords(string message)
        {
            MatchCollection matches = regex.Matches(message);
            string longestWord = matches[0].Value;
            foreach (Match match in matches)
            {
                if (match.Value.Length > longestWord.Length) longestWord = match.Value;
            }

            
            return longestWord;
        }
        
    }
}