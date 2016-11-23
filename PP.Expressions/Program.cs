using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLAP;

namespace PP.Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = new Commands(new ConsoleWriter(),new ExpressionsConverter());
            Parser.RunConsole(args, commands);
        }
    }
}
