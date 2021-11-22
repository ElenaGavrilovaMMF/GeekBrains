using System;
using System.IO;

namespace ArrayLibrary
{
    public class MyArray
    {
        #region Fields

        private int[] arr;

        #endregion

        #region Constructors
        
        public MyArray(int[] arr)
        {
            this.arr = arr;
        }
        
        public MyArray(string fileName)
        {
            arr = LoadArrayFromFile(fileName);
        }

        public MyArray(int size, int startValue, int step)
        {
            int[] arrTemp = new int[size];
            arrTemp[0] = startValue;
            for (int i = 1; i < size; i++)
            {
                startValue += step;
                arrTemp[i] = startValue;
            }

            arr = arrTemp;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Обратиться к элементу массива по индексу
        /// </summary>
        /// <param name="index">Индекс элемента массива</param>
        /// <returns></returns>
        public int this[int index]
        {
            get
            {
                return arr[index];
            }

            set
            {
                arr[index] = value;
            }
        }

        public int Sum
        {
            get
            {
                int sum = 0;
                foreach (int element in arr)
                {
                    sum += element;
                }

                return sum;
            }
        }

        public int MaxCount
        {
            get
            {
                int maxCount = 1;
                int maxElement = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (maxElement == arr[i])
                    {
                        maxCount++;
                    }
                    if (maxElement<arr[i])
                    {
                        maxElement = arr[i];
                        maxCount = 1;
                    }
                }

                return maxCount;
            }
        }

 
        #endregion

        #region Public Methods

        /// <summary>
        /// Распечатать массив
        /// </summary>
        public void PrintArray()
        {
            foreach (int element in arr)
            {
                Console.Write($"{element}\t");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Вернуть элемент массива по индексу
        /// </summary>
        /// <param name="index">Индекс элемента массива</param>
        /// <returns>Элемент массива</returns>
        public int GetElement(int index)
        {
            return arr[index];
        }

        public int[] Inverse()
        {
            int[] temp = new int[arr.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = -arr[i];
            }

            return temp;
        }

        public int[] Multi(int number)
        {
            int[] temp = new int[arr.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = arr[i]*number;
            }

            return temp;
            
        }

        public override string ToString()
        {
            string arr = "";
            foreach (int element in this.arr)
            {
                arr += element + " ";
            }
            return arr;
        }

        #endregion

        #region Private Methods

        private int[] LoadArrayFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);

                int[] arr = new int[1000];
                int counter = 0;

                while (!reader.EndOfStream)
                {
                    int number = int.Parse(reader.ReadLine());
                    arr[counter] = number;
                    counter++;
                }

                int[] buf = new int[counter];

                Array.Copy(arr, buf, counter);

                reader.Close();

                return buf;
            }
            else
                throw new FileNotFoundException();
        }

        #endregion
        
    }

}