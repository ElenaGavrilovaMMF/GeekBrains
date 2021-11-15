using System;

namespace Homework3_3
{
    class Complex
    {
        #region Fields (Fields)
            private double im;
            private double re;
        #endregion

        #region Parameters
        public double Im
        {
            get
            {
                return im;
            }

            set
            {
                if (value == 0)
                {
                    throw new Exception("Недопустимое значение.");
                }

                im = value;
            }
        }

        public double Re
        {
            get
            {
                return re;
            }

            set
            {
                re = value;
            }
        }

        #endregion

        #region Constructor

        public Complex(double re, double im)
        {
            if (im == 0)
            {
                throw new Exception("Недопустимое значение.");
            }
            
            this.re = re;
            this.im = im;
        }

        public Complex()
        {

        }
        
        #endregion

        #region Action (Methods)

        public Complex Plus(Complex complex)
        {
            return new Complex(this.re + complex.re, this.im + complex.im);
        }

        public Complex Minus(Complex complex)
        {
            return new Complex(this.re - complex.re, this.im - complex.im);
        }

        public Complex Composition(Complex complex)
        {
            double reComposition = this.re * complex.re - this.im * complex.im;
            double imComposition = this.re * complex.im + this.im * complex.re;

            return new Complex(reComposition, imComposition);
        }
        
        #endregion

        public override string ToString()
        {
            return $"{re} + {im}i";
        }


    }

    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Complex complex01 = new Complex(3, -1);
                Complex complex02 = new Complex(-1, 2);
                string userValue;
                do
                {
                    string result = $"Результат операции: {complex01} и {complex02} >>> ";
                    Console.WriteLine("Выберите операцию над комплексными числами: " +
                                      "\n - \"+\" для сложения;" +
                                      "\n - \"-\" для вычитания;" +
                                      "\n - \"*\" для произведения. " +
                                      "\n Введите 0 чтобы выйти из программы.");
                    userValue = Console.ReadLine();
                    switch (userValue)
                    {
                        case "+":
                            result += complex01.Plus(complex02).ToString();
                            break;
                        case "-":
                            result += complex01.Minus(complex02).ToString();
                            break;
                        case "*":
                            result += complex01.Composition(complex02).ToString();
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