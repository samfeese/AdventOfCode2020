using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class DaySix
    {
        public void ReadValuesFromTextFile()
        {
            char[] delimiterChars = { ' ', '\n' };
            List<int> yes = new List<int> { };
            string values = File.ReadAllText(@"..\..\Day06Items.txt");
            string[] splitValues = values.Split("\n\r");



           
            

            for (var i = 0; i < splitValues.Length; i++)
            {
                List<char> charList = new List<char> { };
                var newValues = splitValues[i].Trim().Split(delimiterChars);
                var numberOfPeople = newValues.Length;
                
                int count = 0;
                foreach (var item in newValues)
                {
                    
                    for (var j = 0; j < item.Length; j++)
                    {
                        charList.Add(item[j]);
                        
                    }                       
                }
                var g = charList.GroupBy(i => i);
                

                foreach (var grp in g)
                {
                    
                    var y = grp.Count();
                    if (y == numberOfPeople) count++;
                }

                yes.Add(count);

                
            }

            Console.WriteLine(yes.Sum());


        }
    }
}
