using System;

namespace Day03
{
    class Program
    {
        static string path = @"input.in";
        static void Main(string[] args)
        {
            Solution1_PartOne();
            Solution2_PartOne();
            Solution2_PartTwo();
        }
        private static void Solution1_PartOne()
        {
            var x = 0;
            var y = 0;
            var height = Lines().Length;
            var weight = Lines()[0].Length - 1;
            var xi = 1;
            var yi = 3;
            var result = 0;
            while (x < height)
            {
                if (Lines()[x][y] == '#')
                {
                    result += 1;
                }
                x += xi;
                y = (y + yi) % weight;
            }
            Console.WriteLine(result);
        }
        private static void Solution2_PartOne()
        {
            var count = TreeCount(Lines(), (1, 3));
            Console.WriteLine(count);
        }
        private static void Solution2_PartTwo()
        {
            var count = TreeCount(Lines(), (1, 1), (1, 3), (1, 5), (1, 7), (2, 1));
            Console.WriteLine(count);
        }
        static long TreeCount(string[] lines, params (int drow, int dcol)[] slopes)
        {

            var (crow, ccol) = (lines.Length, lines[0].Length - 1);
            var mul = 1L;

            foreach (var (drow, dcol) in slopes)
            {
                var (irow, icol) = (drow, dcol);
                var trees = 0;
                while (irow < crow)
                {
                    var mcol = icol % ccol;
                    if (lines[irow][mcol] == '#')
                    {
                        trees++;
                    }
                    (irow, icol) = (irow + drow, icol + dcol);
                }
                mul *= trees;
            }
            return mul;
        }
        static string[] Lines()
        {
            string text = System.IO.File.ReadAllText(path);
            return text.Split('\n');
        }
    }
}
