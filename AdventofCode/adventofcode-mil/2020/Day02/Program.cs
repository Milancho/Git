using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day02
{
    ///
    /// Password Philosophy
    ///
    class Program
    {
        // static string path = @"Day02\input.in";
         static string path = @"input.in";
        static void Main(string[] args)
        {
            Console.WriteLine("Solution1");
            Solution1_PartOne();
            Solution1_PartTwo();
            Console.WriteLine("Solution2");
            Console.WriteLine(PartOne(Lines()).ToString());

        }

        private static void Solution1_PartOne()
        {
            var i = 0;
            foreach (var line in Lines())
            {
                var parts = line.Split(' ');

                var part1 = parts[0];
                var range = part1.Split('-').Select(int.Parse).ToList();
                var min = range[0];
                var max = range[1];

                var letter = parts[1][0];
                var password = parts[2];

                var counter = password.Count(c => c == letter);

                if (counter >= min && counter <= max)
                {
                    i++;
                }
            }
            Console.WriteLine(i);
        }
        private static void Solution1_PartTwo()
        {
            var i = 0;
            foreach (var line in Lines())
            {
                var parts = line.Split(' ');

                var part1 = parts[0];
                var range = part1.Split('-').Select(int.Parse).ToList();
                var posOne = range[0];
                var posThree = range[1];

                var letter = parts[1][0];
                var password = parts[2];

                var firstMatch = letter == password[posOne - 1];
                var secondMatch = letter == password[posThree - 1];

                if ((firstMatch || secondMatch) && (firstMatch != secondMatch))
                {
                    i++;
                }
            }
            Console.WriteLine(i);
        }
        static string[] Lines()
        {
            string text = System.IO.File.ReadAllText(path);
            return text.Split('\n');
        }
        record PasswordEntry(int a, int b, char ch, string password);

        static int PartOne(string[] input) => ValidCount(input, pe =>
         {
             var count = pe.password.Count(ch => ch == pe.ch);
             return pe.a <= count && count <= pe.b;
         });

        static int ValidCount(string[] input, Func<PasswordEntry, bool> isValid) =>
           input.Select(line =>
           {
               var parts = line.Split(' ');
               var range = parts[0].Split('-').Select(int.Parse).ToArray();
               var ch = parts[1][0];
               return new PasswordEntry(range[0], range[1], ch, parts[2]);
           }).Count(isValid);
    }
}
