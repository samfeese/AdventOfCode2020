using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Day10
    {
        static List<string> values = File.ReadAllLines(@"..\..\Day10Items.txt").ToList();
        List<int> intValues = new List<int> { };
        
       

        public void Run()
        {
            values.ForEach(x => intValues.Add(int.Parse(x)));
            int startingJolts = 0;
            int phoneJolts = intValues.Max() + 3;
            intValues.Add(0);
            intValues.Add(phoneJolts);
            intValues.Sort();
            Console.WriteLine(SortByJolts(intValues));
            Console.WriteLine(SortByJoltsPartTwo(intValues));



        }
        int SortByJolts(List<int> numbers)
        {
            int threeCount = 0;
            int oneCount = 0;
            
           
            for (int i = 1; i < numbers.Count; i++)
            {

                
                    int difference = numbers[i] - numbers[i -1];
                    if (difference == 3) threeCount++;
                    else if (difference == 1) oneCount++;
               
                               
              

            }
            ;
            return threeCount * oneCount;
        }
        long SortByJoltsPartTwo(List<int> numbers)
        {

            var amountOfCombos = new long[numbers.Count]; //the maximum



            foreach (var index in Enumerable.Range(0, amountOfCombos.Length))
            {
                if (index == 0)
                    amountOfCombos[index] = 1;
                else
                {
                    amountOfCombos[index] = 0;
                    for (var j = index - 1; j >= 0; j--)
                    {
                        if (amountOfCombos[index] - amountOfCombos[j] <= 3)
                            amountOfCombos[index] += amountOfCombos[j];
                        else
                            break;
                    }
                }
            }
            return amountOfCombos[amountOfCombos.Length - 1];

        }
    }
}
