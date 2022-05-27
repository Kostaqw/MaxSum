using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace MaxSum
{
    public class MaxSum
    {
        private List<int> NumbersIncorrectStrings { get; }
        public string Path { get; }
        public List<string> Strings { get; }
      
        private int NumberMaxString;
        private bool NumberFind;

        public MaxSum(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException($"\"{nameof(path)}\" can't be null or empty", nameof(path));
            }

            Path = path;
            Strings = new List<string>();
            NumbersIncorrectStrings = new List<int>();

            ReadFile();
            FindMaxString();   
        }

        public string GetNumberMaxString()
        {
            if (NumberFind)
            {
                return NumberMaxString.ToString();
            }

            return null; 
        }

        public string GetNumbersIncorrectStrings()
        {
            var str = new StringBuilder();

            if (NumbersIncorrectStrings.Count == 0)
            {
                return null;
            }

            foreach (var item in NumbersIncorrectStrings)
            {
                str.Append(item.ToString() + " ");
            }

            str.Length--;

            return str.ToString();
        }

        private void ReadFile()
        {
            using (StreamReader Stream = new StreamReader(Path))
            {
                string line;
                while ((line = Stream.ReadLine()) != null)
                { 
                    Strings.Add(line);
                }
            }

            if (Strings.Count == 0)
            {
                throw new InvalidDataException($"\"{Path}\". file is empty");
            }

        }

        private bool CheckString(string str)
        {
            string[] digit = str.Split(",");

            for (int i = 0; i < digit.Length; i++)
            {
                bool success = double.TryParse(digit[i], NumberStyles.Float, CultureInfo.InvariantCulture, out double currentSymbol); ;

                if (!success)
                {
                    return false;
                }
            }

            return true;
        }

        private double CalculateSum(string str)
        {
            double sum = 0;
            string[] digit = str.Split(",");

            for (int i = 0; i < digit.Length; i++)
            {
                double currentSymbol;
                double.TryParse(digit[i], NumberStyles.Float, CultureInfo.InvariantCulture, out currentSymbol); 

                sum += currentSymbol;
            }
             
            return sum;
        }

        private void FindMaxString()
        {
            double max = double.MinValue;
            
            for (int i = 0; i < Strings.Count; i++)
            {
                if (CheckString(Strings[i]))
                {
                    if (CalculateSum(Strings[i]) > max)
                    { 
                        max = CalculateSum(Strings[i]);
                        NumberMaxString = i;
                        NumberFind = true;
                    }
                }
                else
                {
                    NumbersIncorrectStrings.Add(i);
                }
            }
        }
    }
}
