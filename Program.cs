using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {

            DayFive dayFive = new DayFive();
            List<int> list = new List<int>() { };
            Console.WriteLine(dayFive.ReadValuesFromTextFileDayFive());

        }
    }
}
