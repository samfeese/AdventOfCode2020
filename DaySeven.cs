using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class DaySeven
    {

        List<string> values = File.ReadAllLines(@"..\..\Day07Items.txt").ToList();
        List<string> numBags = new List<string> { "shiny gold" };
        int totalBags = 0;
        
        public void ReadValuesFromTextFile()
        {

            FindNestedBags(numBags);
            Console.WriteLine(FindBagsInGold("shiny gold"));

            

        }

        private int FindNestedBags(List<string> matches)
        {
            List<string> newList = matches;
            int count = matches.Count;
           

            


            foreach (var item in values)
            {
                
                if (matches.Any(s => item.Contains(s))) {
                    string[] colorBag = item.Split();
                    string color = colorBag[0] + " " + colorBag[1];
                    if (matches.Contains(color)) continue;
                    numBags.Add(color);
                    
                }
                
            }
            if (count == numBags.Count)
            {
                //Console.WriteLine(count - 1);
            }
            else if (count != numBags.Count)
            {
                FindNestedBags(newList);
                
            }





            return count - 1;
        }

        private int FindBagsInGold(string starter)
        { 
            int bagCount = 0;

            int firstIndex = values.FindIndex(x => x.StartsWith(starter));
            string firstPhrase = values[firstIndex];
            string phrases = firstPhrase.Substring(firstPhrase.IndexOf("contain") + 8).Replace(".", "").Replace("bags", "bag"); //Had some help here props to reddit user thisrs 
            
            string[] seperatedBags = phrases.Split(", ");

            return FindBagsRecursive(seperatedBags);
            
            
        }
    



        public int FindBagsRecursive(string[] bagColor)
        {
            int count = 0;

            foreach (string bag in bagColor)
            {
               
                int amount = int.Parse(bag.Substring(0, bag.IndexOf(" ") + 1));

                string name = bag.Substring(bag.IndexOf(" ") + 1);
                Console.WriteLine(name);
                int bagIndex = values.FindIndex(x => x.StartsWith(name.Replace(".", "").Replace("bags", "bag")));
                Console.WriteLine(bagIndex);
                string bagRule = values[bagIndex];
                bagRule = bagRule.Substring(bagRule.IndexOf("contain") + 8);
                totalBags += amount;

                if (bagRule != "no other bags.")
                {
                    //string bagsContainedString = bagRule.Replace(".", "").Replace("bags", "bag"); //Make all bag names singular so no bags get missed
                    string[] bagsInside = bagRule.Split(", ");
                    totalBags += amount * FindBagsRecursive(bagsInside);
                }
            }

            return totalBags;
        }

    }
}
