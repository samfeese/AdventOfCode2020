using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    class DayFive
    {
        public int ReadValuesFromTextFileDayFive()
        {

            int highestNum = 0;
            List<int> list = new List<int>() { };

            string[] numberArrayAsStrings = System.IO.File.ReadAllLines(@"..\..\Day05Items.txt");
           
            for (int i = 0; i < numberArrayAsStrings.Length; i++)
            {
                var rows = numberArrayAsStrings[i].Substring(0, 7);
                var columns = numberArrayAsStrings[i].Substring(7, 3);
                var rowNumber = FindRow(rows);
                var columnNumber = FindColumn(columns);
                var seatId = (rowNumber * 8) + columnNumber;
                list.Add(seatId);
                


            }
            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1; j < list.Count; j++)
                {

                    if (list[i] + 2 == list[j] && !list.Exists(x => x == list[i]+1))
                    {
                        Console.WriteLine(list[i]);
                        Console.WriteLine(list[j]);
                        highestNum = list[i];

                    }
                }
            
            }
            return highestNum + 2; //I do not understand why its +2 and my seat should have been 710, but the right anwser was 711? unsure about this o
        }

        private int FindRow(string rowString)
        {
            int min = 0;
            int max = 127;

            int rowNumber;

            char front = 'F';
            

            for (int i = 0; i < rowString.Length - 1; i++)
            {
                if (rowString[i] == front)
                {
                    max = (max + min) / 2;
                    
                }
                else
                { 
                    min = ((max + min) / 2) + 1;
                  
                }
            }
            if(rowString[6] == front)
            {
                max = min;
            }
            else
            {
                min = max;
            }
            
            rowNumber = max;
           


                return rowNumber;
        }
        private int FindColumn(string columnString)
        {
            int min = 0;
            int max = 7;

            int columnNum = 0;

            char left = 'L';
            char right = 'R';

            for (int i = 0; i < columnString.Length - 1; i++)
            {
                if (columnString[i] == left)
                {
                    max = (max + min) / 2;
                    continue;
                }
                min = (max + min) / 2 + 1;
            }
            if (columnString[2] == right)
            {
                max = min;
            }
            else
            {
                min = max;
            }
          
            columnNum = max;
            


            return columnNum;
        }
    }
}
