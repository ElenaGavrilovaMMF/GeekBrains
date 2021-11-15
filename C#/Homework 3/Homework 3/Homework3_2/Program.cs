using System;

namespace Homework3_2
{
    struct Complex
    {
        #region Fields (Fields)
            public double im;
            public double re; // private
        #endregion

        #region Actions (Methods)
            public Complex Plus(Complex complex)
            {
                Complex complexResult;
                complexResult.re = re + complex.re;
                complexResult.im = im + complex.im;

                return complexResult;
            }

            public Complex Minus(Complex complex)
            {
                Complex complexResult;
                complexResult.re = re - complex.re;
                complexResult.im = im - complex.im;

                return complexResult;
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
            Complex complex01;
            complex01.re = 3;
            complex01.im = 2;

            Complex complex02;
            complex02.re = 0;
            complex02.im = -1;

            Complex complex03 = complex01.Plus(complex02);
            Complex complex04 = complex01.Minus(complex02);
            Console.WriteLine($"Результат сложения комплексных чисел {complex01} и {complex02} >>> {complex03}");
            Console.WriteLine($"Результат вычитания комплексных чисел {complex01} и {complex02} >>> {complex04}");
            Console.ReadKey();
        }
    }
}