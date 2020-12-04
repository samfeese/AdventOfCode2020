using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    class DayThree
    {
        public int ReadValuesFromTextFileDayThree(int xChange, int yChange)
        {
            int x = 0;
            int y = 1;
           
            int treeCount = 0;

            string tree = "#";
            
 
            string[] numberArrayAsStrings = System.IO.File.ReadAllLines(@"..\..\Day03Items.txt");
            for (int i = 0; i < numberArrayAsStrings.Length; i++)
            {
                if (i % yChange == 0)
                {
                    string stringComplex = numberArrayAsStrings[i];
                    string openOrTree = stringComplex[x].ToString();

                    if (openOrTree == tree)
                    {
                        treeCount++;
                    }

                    x += xChange;

                    if (x > 30)
                    {
                        x -= 31;
                    }


                    Console.WriteLine(x);
                }
                
               


            }
            return treeCount;
        }
    }
}
