using System;
using System.Collections.Generic;
using System.Linq;

namespace PP.Expressions
{
        public class ConsoleWriter 
        {
            public void DisplayResultListInColumn(string title, IEnumerable<string> items)
            {
                System.Console.WriteLine(title + ":");
                System.Console.WriteLine();

                foreach (var item in items)
                {
                    System.Console.WriteLine("   " + item);
                }

                System.Console.WriteLine();
            }

            public void DisplayResult(string result)
            {
                System.Console.WriteLine(result);
                System.Console.WriteLine();
            }

        internal void DisplayResult(string fixType, string fixValue)
        {
            System.Console.WriteLine($"{fixType}: {fixValue}");
            System.Console.WriteLine();
        }

        public void DisplayResultListAfterCommas(string title, IEnumerable<string> items)
            {
                System.Console.WriteLine(title + ": " + string.Join(",", items.ToArray()));
                System.Console.WriteLine();
            }
        }


    }
