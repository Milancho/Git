using System;
using System.Linq;
using System.Collections.Generic;
namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = getNumbers();

            Console.WriteLine("SOLUTION 1:");
            var tupleParOne = PartOne(numbers);
            Console.WriteLine("Part One:");
            Console.WriteLine($"{tupleParOne.Item1}*{tupleParOne.Item2}={tupleParOne.Item1 * tupleParOne.Item2}");
            Console.WriteLine("Part Two:");
            var parTwo = PartTwo(numbers);
            Console.WriteLine($"{parTwo[0]}*{parTwo[1]}*{parTwo[2]}={parTwo[0] * parTwo[1] * parTwo[2]}");

            Console.WriteLine("SOLUTION 2:");
            Console.WriteLine(PartOneV2(numbers).ToString());
            Console.WriteLine(PartTwoV2(numbers).ToString());
        }

        static List<int> getNumbers()
        {
            string text = System.IO.File.ReadAllText("input.in");
            return text.Split('\n').Select(int.Parse).ToList<int>();
        }

        static Tuple<int, int> PartOne(List<int> numbers)
        {
            var n1 = 0;
            var n2 = 0;
            for (int i = 0; i < numbers.Count(); i++)
            {
                for (int j = i + 1; j < numbers.Count(); j++)
                {
                    if (numbers[i] + numbers[j] == 2020)
                    {
                        n1 = numbers[i];
                        n2 = numbers[j];
                    }
                }
            }
            return new Tuple<int, int>(n1, n2);
        }

        static List<int> PartTwo(List<int> numbers)
        {
            var n1 = 0;
            var n2 = 0;
            var n3 = 0;
            for (int i = 0; i < numbers.Count(); i++)
            {
                for (int j = i + 1; j < numbers.Count(); j++)
                {
                    for (int k = j + 1; k < numbers.Count(); k++)
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == 2020)
                        {
                            n1 = numbers[i];
                            n2 = numbers[j];
                            n3 = numbers[k];
                        }
                    }
                }
            }
            return new List<int>() { n1, n2, n3 };
        }

        // SOLUTION 2
        static long PartOneV2(List<int> numbers)
        {
            return (
                    from x in numbers
                    let y = 2020 - x
                    where numbers.Contains(y)
                    select x * y
                                    ).First();
        }

        // SOLUTION 2
        static long PartTwoV2(List<int> numbers)
        {
            return (
                    from x in numbers
                    from y in numbers
                    let z = 2020 - x - y
                    where numbers.Contains(z)
                    select x * y * z
                                    ).First();
        }

    }
}
