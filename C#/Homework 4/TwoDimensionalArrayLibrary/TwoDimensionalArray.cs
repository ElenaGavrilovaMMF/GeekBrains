using System;
using System.IO;

namespace TwoDimensionalArrayLibrary
{
    public class TwoDimensionalArray
    {
        #region Fields
        
        private int[][] arr;
        
        #endregion
        
        #region Constructors
        
        public TwoDimensionalArray(int [][] arr)
        {
            this.arr = arr;
        }

        public TwoDimensionalArray(string fileName)
        {
            arr = Load(AppDomain.CurrentDomain.BaseDirectory + fileName);
        }

        public TwoDimensionalArray(int firstArraySize, int secondArraySize, int minRandom, int maxRandom)
        {
            Random random = new Random();
            int[][] result = new int[firstArraySize][];
            for (int i = 0; i < firstArraySize; i++)
            {
                int[] temp = new int[secondArraySize];
                for (int j = 0; j < temp.Length; j++)
                {
                    temp[j] = random.Next(minRandom, maxRandom);
                }
                result[i] =temp;
            }
            arr = result;
        }
        
        #endregion
        
        #region Public Properties
        
        public int Min
        {
            get
            {
                int min = arr[0][0];
                foreach (int[] arrInside in arr)
                {
                    foreach (int value in arrInside)
                    {
                        if (min > value) min = value;
                    }
                }
                return min;
            }
        }
        
        public int Max
        {
            get
            {
                int max = arr[0][0];
                foreach (int[] arrInside in arr)
                {
                    foreach (int value in arrInside)
                    {
                        if (max < value) max = value;
                    }
                }
                return max;
            }
        }
        #endregion

        #region Public Methods

        public int Sum()
        {
            int sum = 0;
            foreach (int[] arrInside in arr)
            {
                foreach (int value in arrInside)
                {
                    sum += value;
                }
            }

            return sum;
        }

        public int Sum(int number)
        {
            int sum = 0;
            foreach (int[] arrInside in arr)
            {
                foreach (int value in arrInside)
                {
                    if (value>number)
                    {
                        sum += value;
                    }
                }
            }

            return sum;
        }

        public int[][] GetMaxValueIndex()
        {
            int[][] index = new int[arr.Length][];
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] == Max)
                    {
                        index[count] = new[] {i, j};
                        count++;
                    }
                }
            }
            
            int[][] buf = new int[count][];
            Array.Copy(index, buf, count);
            
            return buf;
        }
        
        public int[][] GetMaxValueIndex(out int maxValue)
        {
            maxValue = Max;
            
            return GetMaxValueIndex();
        }

        public int[][] Load(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                int[][] arr = new int[1000][];
                int counter = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    arr[counter] = ParseData(line);
                    counter++;
                }
                int[][] buf = new int[counter][];
                Array.Copy(arr, buf, counter);
                reader.Close();
                return buf;
            }
            else
                throw new FileNotFoundException();
        }
        
        public void Write(string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + fileName, false, System.Text.Encoding.Default))
                {
                    foreach (int[] arrInside in arr)
                    {
                        string line = "";
                        foreach (int value in arrInside)
                        {
                            line += value + " ";
                        }
                        sw.WriteLine(line);
                    }
                }
                
                Console.WriteLine("Запись выполнена в: " + AppDomain.CurrentDomain.BaseDirectory + fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public override string ToString()
        {
            string result = "";
            foreach (int[] arrInside in arr)
            {
                foreach (int value in arrInside)
                {
                    result += value + " ";
                }

                result += "\n";
            }
            return result;
        }

        #endregion
        
        #region Private Methods
        private int[] ParseData(string line)
        {
            string[] data = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] dataInt = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                dataInt[i] = Int32.Parse(data[i]);
            }
            
            return dataInt;
        }
        #endregion
    }
}