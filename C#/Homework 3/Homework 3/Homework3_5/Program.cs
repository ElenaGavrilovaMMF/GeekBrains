using System;

namespace Homework3_5
{
    class Fraction
    {
        #region Fields (Fields)
            private int numerator;
            private int denominator;
        #endregion

        #region Parameters
        public int Numerator
        {
            get
            {
                return numerator;
            }

            set
            {
                numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return denominator;
            }

            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                }
                
                denominator = value;
            }
        }
        
        public double Decimal
        {
            get
            {
                return Math.Round((double) numerator / denominator, 2);
            }
        }

        #endregion

        #region Constructor

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }
            
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public Fraction()
        {

        }
        
        #endregion

        #region Action (Methods)

        public Fraction Plus(Fraction complex)
        {
            int denominatorResult = this.denominator * complex.denominator;
            int numerator1 = this.numerator * complex.denominator;
            int numerator2 = complex.numerator * this.denominator;
            int numeratorResult = numerator1 + numerator2;

            return new Fraction(numeratorResult, denominatorResult).Suppress();
        }



        public Fraction Minus(Fraction complex)
        {
            int denominatorResult = this.denominator * complex.denominator;
            int numerator1 = this.numerator * complex.denominator;
            int numerator2 = complex.numerator * this.denominator;
            int numeratorResult = numerator1 - numerator2;
            
            return new Fraction(numeratorResult, denominatorResult).Suppress();
        }

        public Fraction Composition(Fraction complex)
        {
            int numeratorResult = this.numerator * complex.numerator;
            int denominatorResult = this.denominator * complex.denominator;
            
            return new Fraction(numeratorResult, denominatorResult).Suppress();
        }
        
        public Fraction Division (Fraction complex)
        {
            int numeratorResult = this.numerator * complex.denominator;
            int denominatorResult = this.denominator * complex.numerator;
            
            return new Fraction(numeratorResult, denominatorResult).Suppress();
        }

        public Fraction Suppress()
        {
            int gcf = GetGCF(numerator, denominator);
            if (numerator < 0 && denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
            
            return new Fraction(numerator/gcf, denominator/gcf);
        }

        //НОД
        private int GetGCF(int a, int b) {
            if (b == 0)
                return Math.Abs(a);
            return GetGCF(b, a % b);
        }
        
        #endregion

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }


    }

    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Fraction fraction01 = new Fraction(3, -6);
                Fraction fraction02 = new Fraction(-1, 2);
                Console.WriteLine($"Проверяемые дроби: {fraction01}, {fraction02}");
                string userValue;
                do
                {
                    string result = $"Результат операции: {fraction01} и {fraction02} >>> ";
                    Console.WriteLine("Выберите операцию над дробями числами: " +
                                      "\n - \"+\" для сложения;" +
                                      "\n - \"-\" для вычитания;" +
                                      "\n - \"*\" для произведения. " +
                                      "\n - \"/\" для деления. " +
                                      "\n - \"//\" для упрощения. " +
                                      "\n - \"%\" для десятичного вывода. " +
                                      "\n Введите 0 чтобы выйти из программы.");
                    userValue = Console.ReadLine();
                    switch (userValue)
                    {
                        case "+":
                            result += fraction01.Plus(fraction02).ToString();
                            break;
                        case "-":
                            result += fraction01.Minus(fraction02).ToString();
                            break;
                        case "*":
                            result += fraction01.Composition(fraction02).ToString();
                            break;
                        case "/":
                            result += fraction01.Division(fraction02).ToString();
                            break;
                        case "//":
                            result += fraction01.Suppress() + " и " + fraction02.Suppress();
                            break;
                        case "%":
                            result += fraction01.Decimal + " и " + fraction02.Decimal;
                            break;
                        case "0":
                            result = "Программа завершена.";
                            break;
                        default:
                            throw new Exception("Такой математической операции не предусмотрено в программе.");
                    }

                    Console.WriteLine(result);
                } while (userValue != "0");
            }
            catch (Exception e)
            {
                Console.WriteLine("При выполнении приложения возникло исключение.");
                Console.WriteLine(e.Message);
            }
         
            Console.ReadKey();
        }
    }
}