using System;
using System.IO;

namespace Homework4_4
{
    public struct Account
    {
        #region Fields
        
        private string Login;
        private string Password;
        
        #endregion
        
        #region Constructors
        public Account(string login, string password)
        {
            Login = login;
            Password = password;
        }
        #endregion
        
        #region Public Methods
        public string GetLogin() => Login;
        public string GetPassword() => Password;
        #endregion
    }

    public class Storage
    {
        #region Fields

        private static Account[] autorizationData;

        #endregion
        
        #region Constructors
        
        public Storage()
        {
            autorizationData = Load(AppDomain.CurrentDomain.BaseDirectory + "authorization_data.txt");
        }
        
        #endregion

        #region Public Methods
        public bool Authorization(string login, string password)
        {
            bool authorization = false;
            Account account = FindAccount(login);
            if (account.GetLogin()!=null)
            {
                if (account.GetPassword()==password)
                {
                    authorization = true;
                }
            }

            return authorization;
        }
       
        #endregion
        
        #region Private Methods
        private Account[] Load(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                Account[] arr = new Account[1000];
                int counter = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    arr[counter] = ParseLoginData(line);
                    counter++;
                }
                Account[] buf = new Account[counter];
                Array.Copy(arr, buf, counter);
                reader.Close();
                return buf;
            }

            throw new FileNotFoundException();
        }
        
        private Account FindAccount(string login)
        {
            foreach (Account data in autorizationData)
            {
                if (data.GetLogin() == login)
                {
                    return data;
                }
            }

            return new Account();
        }

        private Account ParseLoginData(string line)
        {
            string[] data = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Account account = new Account(data[0], data[1]);
            return account;
        }
        #endregion
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            //4. Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
            //Создайте структуру Account, содержащую Login и Password.
            
            //4. Реализовать метод проверки логина и пароля.
            //На вход метода подается логин и пароль.
            //На выходе истина, если прошел авторизацию,
            //и ложь, если не прошел (Логин: root, Password: GeekBrains).
            
            //Используя метод проверки логина и пароля, написать программу:
            //пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
            //С помощью цикла do while ограничить ввод пароля тремя попытками.
            Storage storage = new Storage();
            
            Console.WriteLine("Войдите в систему. У вас три попытки!");
            bool authorization;
            int counter = 3;
            do
            {
                Console.Write("Введите логин: ");
                string userLogin = Console.ReadLine();
                Console.Write("Введите пароль: ");
                string userPassword = Console.ReadLine();

                authorization = storage.Authorization(userLogin, userPassword);
                counter--;

                if (authorization)
                {
                    Console.WriteLine("Вы вошли в систему!");
                    break;
                }
                Console.WriteLine($"Вы неправильно ввели логин или пароль. Количество оставшихся попыток: {counter} \n");
                
            } while (counter != 0);

            if (counter == 0)
            {
                Console.WriteLine("Вы заблокированы!");
            }
        }
    }
}