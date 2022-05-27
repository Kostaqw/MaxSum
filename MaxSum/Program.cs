using System;


namespace MaxSum
{
    public class Program
    {
        static void Main(string[] args)
        {
            MaxSum maxSum;

            if (args.Length != 0)
            {
                Console.WriteLine(args[0]);
                maxSum = new MaxSum(args[0]);     
            }
            else
            {
                Console.Write("enter path and name:");
                string path = Console.ReadLine();
                maxSum = new MaxSum(path);
            }
            
            byte i = 0;
            
            foreach (var item in maxSum.Strings)
            {
                Console.WriteLine($" №{i} - {item}");
                i++;
            }

            Console.WriteLine($"Number of the max string: {maxSum.GetNumberMaxString()}");
            Console.WriteLine($"incorrect strings: {maxSum.GetNumbersIncorrectStrings()}");
 
        }
    }
}
