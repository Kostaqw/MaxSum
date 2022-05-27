using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;


namespace MaxSum
{
    [TestClass()]
    public class MaxSumTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyDates()
        {
            MaxSum maxSum = new MaxSum("");
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidDataException))]
        public void TestEmptyFile()
        {
            string file = CreateFile();
            MaxSum maxSum = new MaxSum(file);
        }

        [TestMethod()]
        public void FindMaxStringInStandartFile()
        {
            string file = CreateFile("1,2,3,4,5", "1,2,2", "sad", "5,3,2.2,1,5,6");
            MaxSum maxSum = new MaxSum(file);

            string expect = "3";

            Assert.AreEqual(expect, maxSum.GetNumberMaxString());
            File.Delete(file);
        }

        [TestMethod()]
        public void FindMaxStringInIncorrectFile()
        {
            string file = CreateFile("qwert", "asxcv", "sad", "asdccx");
            MaxSum maxSum = new MaxSum(file);

            Assert.AreEqual(null, maxSum.GetNumberMaxString());
            File.Delete(file);
        }

        [TestMethod()]
        public void FindIncorrectStringInStandartFile()
        {
            string file = CreateFile("qwer", "1,2,2", "sad", "5,3,2,1,5,6");
            MaxSum maxSum = new MaxSum(file);

            string expect = "0 2";

            Assert.AreEqual(expect, maxSum.GetNumbersIncorrectStrings());
            File.Delete(file);
        }

        [TestMethod()]
        public void FindIncorrectStringInCorrectFile()
        {
            string file = CreateFile("1,4,6", "1,2,2", "2.2", "5,3,2,1,5,6");
            MaxSum maxSum = new MaxSum(file);

            Assert.AreEqual(null, maxSum.GetNumbersIncorrectStrings());
            File.Delete(file);
        }

        private string CreateFile(params string[] strings)
        {
            string path = Path.GetTempFileName();
            FileInfo file = new FileInfo(path);

            using (StreamWriter SW = file.CreateText())
            {
                for (int i = 0; i < strings.Length; i++)
                {
                    SW.WriteLine(strings[i]);
                }
            }
            return path;
        }
    }
}