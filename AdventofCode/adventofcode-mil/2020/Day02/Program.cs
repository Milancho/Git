using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solution1");
            Solution1_PartOne();
            Console.WriteLine("Solution2");
            Solution1_PartTwo();
        }

        private static void Solution1_PartOne()
        {
            var i = 0;
            foreach (var line in Lines())
            {
                var s3 = line.Split(' ');

                var policyPolicy = s3[0];
                var part2 = s3[1];
                var password = s3[2];

                var leastMost = policyPolicy.Split('-').Select(int.Parse).ToList();
                var least = leastMost[0];
                var most = leastMost[1];

                var letter = part2[0];
                var counter = password.Count(c => c == letter);

                if (counter >= least && counter <= most)
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
                var s3 = line.Split(' ');

                var policyPolicy = s3[0];
                var part2 = s3[1];
                var password = s3[2];

                var policyList = policyPolicy.Split('-').Select(int.Parse).ToList();
                var posOne = policyList[0];
                var posThree = policyList[1];

                var letter = part2[0];

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
            string text = System.IO.File.ReadAllText(@"Day02\input.in"); 
            return text.Split('\n');
        }

    }
}
