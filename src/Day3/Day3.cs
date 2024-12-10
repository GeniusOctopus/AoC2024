using System.Text.RegularExpressions;

namespace AoC2024.Day3
{
    internal partial class Day3
    {
        public void Solve()
        {
            var input = File.ReadAllText("Day3/input.txt");

            var sumPart1 = MultiplyOperationsRegex().Matches(input).Select(x => int.Parse(x.Groups[1].Value) * int.Parse(x.Groups[2].Value)).Sum();
            Console.WriteLine(sumPart1);

            var dont = input.Split("don't()");
            var dos = dont.Select(x => x.Split("do()")).ToList();

            var sumPart2 = 0;

            for (int i = 0; i < dos.Count; i++)
            {
                for (int j = 0; j < dos[i].Length; j++)
                {
                    if (j == 0 && i > 0)
                    {
                        continue;
                    }

                    sumPart2 += MultiplyOperationsRegex().Matches(dos[i][j]).Select(x => int.Parse(x.Groups[1].Value) * int.Parse(x.Groups[2].Value)).Sum();
                }
            }

            Console.WriteLine(sumPart2);

        }

        [GeneratedRegex(@"mul\((\d*),(\d*)\)")]
        private static partial Regex MultiplyOperationsRegex();
    }
}
