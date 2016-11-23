using System;
using System.Collections.Generic;
using System.Linq;

namespace PP.Expressions
{
    public class ConsoleWriter
    {
        public void DisplayResult(string fixType, string fixValue)
        {
            Console.WriteLine($"{fixType}: {fixValue}");
        }
    }
}
