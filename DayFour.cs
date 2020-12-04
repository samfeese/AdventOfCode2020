using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    class DayFour
    {
        public int ReadValuesFromTextFileDayFour()
        {
            char[] delimiterChars = { ' ', '\n', '\r' };
            string values = System.IO.File.ReadAllText(@"..\..\Day04Items .txt");
            string[] split = values.Split("\n\r");
            string[] neededValues = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            string[] eyeColors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            int count = 0;
            int itemCount = 0;
           
            for(var i = 0; i < split.Length; i++)
            { 
                
                var trimmedArray = split[i].Trim().Split(delimiterChars);

                itemCount = 0;
                
                foreach(var item in trimmedArray)
                {

                    if (item == "") continue;
                    
                    var keyValue = item.Split(":");

                    var key = keyValue[0];
                    var value = keyValue[1];
                    if (Array.Exists(neededValues, element => element == key)) 
                    { 
                        switch (key)
                        {
                            case "byr":
                                int intByrValue = int.Parse(value);
                                
                                if (intByrValue >= 1920 && intByrValue <= 2002)
                                {
                                    
                                   
                                    itemCount++;
                                }
                                break;
                            
                            case "iyr":
                                int intIyrValue = int.Parse(value);
                                
                                if (intIyrValue >= 2010 && intIyrValue <= 2020)
                                {
                                   
                                    itemCount++;
                                };
                                break;
                            
                            case "eyr":
                                int expirationYear = int.Parse(value);
                                if (expirationYear >= 2020 && expirationYear <= 2030) itemCount++;
                                break;
                            
                            case "hgt":
                                string num = string.Empty;
                                
                                for (int j = 0; j < value.Length; j++)
                                {
                                    if (Char.IsDigit(value[j]))
                                        num += value[j];
                                }
                                var intNum = int.Parse(num);
                                if (value.Contains("cm"))
                                {
                                    
                                    if (150 <= intNum && intNum <= 193)
                                    {
                                        
                                        itemCount++;
                                    };
                                }
                                else if (value.Contains("in"))
                                {
                                    
                                    if (59 <= intNum && intNum <= 76) itemCount++;
                                }
                                break;
                            
                            case "hcl":
                                if (value[0].ToString() == "#")
                                {
                                    char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f' };
                                    var counter = 0;
                                    for (int j = 1; j < value.Length; j++)
                                    {

                                        if (Char.IsLetter(value[j]) && Array.Exists(letters, element => element == value[j]))
                                        {

                                           counter++;
                                        }
                                        if (Char.IsDigit(value[j])) counter++;
                                        
                                    }
                                    if (counter == 6)
                                    {
                                        
                                        itemCount++;
                                    }; 
                                }
                                break;

                            case "ecl":
                                if (Array.Exists(eyeColors, element => element == value)) 
                                {
                                    
                                    itemCount++;
                                }
                                break;
                            
                            case "pid":
                                var numCount = 0;
                                Console.WriteLine(value);
                                if (value.Length == 9)
                                {
                                    for (int j = 0; j < value.Length; j++)
                                    {

                                        if (Char.IsDigit(value[j])) numCount++;


                                    }
                                }

                                if (numCount == 9)
                                {
                                    
                                    itemCount++;
                                };
                                break;
                        }

                    }         
                    
                    
                }
                

                if (itemCount == 7) count++;          
            }
            return count;
            
            
            
        }
    }
}
