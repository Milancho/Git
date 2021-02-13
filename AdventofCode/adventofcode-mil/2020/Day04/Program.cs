using System;

namespace Day04
{
    class Program
    {
        static string path = @"input.in";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            foreach (var line in Lines())
            {
                Console.WriteLine(line);
            }
        }

        static string[] Lines()
        {
            string text = System.IO.File.ReadAllText(path);
            return text.Split(Environment.NewLine + Environment.NewLine);
        }
    }
}
