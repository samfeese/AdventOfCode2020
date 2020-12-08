using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


namespace AdventOfCode
{
    class Day08
    {
        readonly string[] values = File.ReadAllLines(@"..\..\Day08Items.txt");
        int accum = 0;
        List<int> indexRun = new List<int> { };
        public void ReadFirstValuesFromTextFile()
        {
            string[] words = values[0].Split();
            int index = 0;
            string task = words[0];
            string modifier = words[1].Substring(0, 1);
            int numbers = int.Parse(words[1].Substring(1));
            int nextIndex = 0;
            indexRun.Add(0);
            if (modifier == "-")
            {
                numbers *= -1;
            }
            if (task == "acc")
            {
                accum += numbers;
                nextIndex++;
            }
           
            if (task == "jmp")
            {
                nextIndex = index + numbers;
            }
            if(task == "nop")
            {
                nextIndex++;
            }


            
           
            runNextIndex(nextIndex);


        }
        public void runNextIndex(int nextIndex) 
        {
            int index = nextIndex;
            if(indexRun.Exists(x => x == nextIndex))
            {
                Console.WriteLine(accum);
            }
            else {
               
                string[] words = values[nextIndex].Split();
                string task = words[0];
                string modifier = words[1].Substring(0, 1);
                int numbers = int.Parse(words[1].Substring(1));
                indexRun.Add(nextIndex);
                if (modifier == "-")
                {
                    numbers *= -1;
                }
                if (task == "acc")
                {
                    accum += numbers;
                    nextIndex++;
                }
               
                if (task == "jmp")
                {
                    nextIndex = index + numbers;
                }
                if (task == "nop")
                {
                    nextIndex++;
                }

                runNextIndex(nextIndex);
            }

        }
        

    }
}
