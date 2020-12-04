using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public class DayOne
    {
        private int numberRequested { get; set; }
        private List<int> numbersToIterate { get; set; }
        public int finalProduct { get; }
        public DayOne(int numberRequested)
        {
            this.numberRequested = numberRequested;
            numbersToIterate = ReadNumbersFromTextFileDayOne();
            finalProduct = CalculateTheProduct(this.numberRequested);
        }

        public List<int> ReadNumbersFromTextFileDayOne()
        {
            List<int> numberList = new List<int>() { };
            string[] numberArrayAsStrings = System.IO.File.ReadAllLines(@"..\..\DayOneItems.txt");
            foreach(string stringNumber in numberArrayAsStrings)
            {
                numberList.Add(int.Parse(stringNumber));
            }
            return numberList;
        }

        public int CalculateTheProduct(int numberThatIsTheSum)
        {
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            List<int> numbers = ReadNumbersFromTextFileDayOne();
            for(int i = 0; i < numbersToIterate.Count; i++)
            { 
                for(int j = i + 1; j < numbersToIterate.Count; j++)
                {
                    for(int k = i + 1; k < numbersToIterate.Count; k++)
                    if (numbersToIterate[i] + numbersToIterate[j] + numbersToIterate[k] == numberThatIsTheSum)
                    { 
                        num1 = numbersToIterate[i];
                        num2 = numbersToIterate[j];
                        num3 = numbersToIterate[k];
                    }
                    else continue;
                }
            }

            return num1 * num2 * num3;
        }

        
        
   
        
    }
}
