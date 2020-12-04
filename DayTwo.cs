using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    class DayTwo
    {
        public int ReadValuesFromTextFileDayTwo()
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '-' };

            int bigCount = 0;

            List<string> tempList = new List<string>() { };
            string[] numberArrayAsStrings = System.IO.File.ReadAllLines(@"..\..\DayTwoItems.txt");
            foreach (string stringComplex in numberArrayAsStrings)
            {
                tempList.Clear();
                int count = 0;

                string[] strings = stringComplex.Split(delimiterChars);

                int minValue = int.Parse(strings[0]) - 1;
                int maxValue = int.Parse(strings[1]) - 1;
                string charToLookFor = strings[2];
                string password = strings[4];

                foreach(var letter in password)
                {
                    if (letter.ToString() == charToLookFor)
                    {
                        count++;
                    }
                }
                
                if(((password[minValue].ToString() == charToLookFor && password[maxValue].ToString() != charToLookFor) || (password[minValue].ToString() != charToLookFor && password[maxValue].ToString() == charToLookFor)) && (password[minValue].ToString() == charToLookFor && password[maxValue].ToString() == charToLookFor) == false)
                {
                    bigCount++;
                }
                



                Console.WriteLine(bigCount);

            }
            return bigCount;
        }

    }
}
