using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Day09
    {
        readonly List<string> values = File.ReadAllLines(@"..\..\Day09Items.txt").ToList();
        List<int> currentTwenty = new List<int> { };
        int numberThatIsntSum;
        int smallestNum;
        int largestNum;

        public void Run()
        {
            int minIndex = 0;
            int maxIndex = 24;

            runNextIndex(minIndex, maxIndex);
            runPartTwo(numberThatIsntSum);

        }
        public void runNextIndex(int minIndex, int maxIndex)
        {
            int numberToTest = int.Parse(values[maxIndex + 1]);
            currentTwenty.Clear();
            for (int i = minIndex; i <= maxIndex; i++)
            {
                currentTwenty.Add(int.Parse(values[i]));

            }
            bool sumMatch = IsSumOfLastTwenty(currentTwenty, numberToTest);
            if (!sumMatch)
            {

                numberThatIsntSum = numberToTest;
                Console.WriteLine(numberThatIsntSum);
                //Console.WriteLine(values.FindIndex(x => int.Parse(x) == numberThatIsntSum));
            }
            else
            {
                runNextIndex(minIndex + 1, maxIndex + 1);
            }




        }
        bool IsSumOfLastTwenty(List<int> list, int numberToTest)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1; j < list.Count; j++)
                {
                    if ((list[i] + list[j]) == numberToTest) return true;

                }

            }
            return false;
        }

        void runPartTwo(int numToLookFor)
        {
            //IsSumOfLastHoweverMany(numToLookFor, 0);
            int num = 0;
            int smallest = int.Parse(values[500]);
            int largest = int.Parse(values[516]);
            List<int> sortedList = new List<int> { };
            for (int i = 500; i < 517; i++)
            {
                sortedList.Add(int.Parse(values[i]));

            }
            sortedList.Sort();
            Console.WriteLine(sortedList[0] + sortedList[16]);
          
            

            //Console.WriteLine(smallestNum + largestNum);


        }
        void IsSumOfLastHoweverMany(int numberToTest, int indexToStart)
        {
            int nextIndex = indexToStart + 1;
           
            
            int runningTotal = 0;
            for (int i = indexToStart; i < values.Count; i++)
            {

                if (runningTotal <= numberToTest)
                { 
                    if (runningTotal == numberToTest) {
                        Console.WriteLine(indexToStart);
                        Console.WriteLine(i);
                        smallestNum = int.Parse(values[indexToStart]);
                        largestNum = int.Parse(values[i]);
                        break;
                    }
                    runningTotal += int.Parse(values[i]);


                }
                else
                {

                    //Console.WriteLine(runningTotal);
                    IsSumOfLastHoweverMany(numberToTest, nextIndex);
                    break;
                }


            }
           
        }
    }
       
           
    

        

            
            

            
       

  
}
