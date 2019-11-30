using System;
using System.Text.RegularExpressions;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            String expr = @"f[(]([a-e]|[g-z]|[A-Z]|[0-9]|[.]|[(]|[)]|)+[)]";
            String text = "a+b*f(2+6)^3+f(30)";

            MatchCollection mc = Regex.Matches(text, expr);
            foreach(Match m in mc)
            {
                Console.WriteLine(m);
                Console.WriteLine("");
            }
            //Console.WriteLine(gc.)
            
            //Console.WriteLine("Hello World!");
        }
    }
}
