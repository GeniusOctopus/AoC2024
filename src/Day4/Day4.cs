namespace AoC2024.Day4
{
    internal class Day4
    {
        public void Solve()
        {
            var input = File.ReadAllLines("Day4/input.txt");

            var countPart1 = 0;
            var countPart2 = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == 'X')
                    {
                        // Up
                        if (i >= 3)
                        {
                            if (input[i - 1][j] == 'M' && input[i - 2][j] == 'A' && input[i - 3][j] == 'S') { countPart1++; }
                        }

                        // Up Right
                        if (i >= 3 && j <= input[i].Length - 4)
                        {
                            if (input[i - 1][j + 1] == 'M' && input[i - 2][j + 2] == 'A' && input[i - 3][j + 3] == 'S') { countPart1++; }
                        }

                        // Right
                        if (j <= input[i].Length - 4)
                        {
                            if (input[i][j + 1] == 'M' && input[i][j + 2] == 'A' && input[i][j + 3] == 'S') { countPart1++; }
                        }

                        // Down Right
                        if (i <= input.Length - 4 && j <= input[i].Length - 4)
                        {
                            if (input[i + 1][j + 1] == 'M' && input[i + 2][j + 2] == 'A' && input[i + 3][j + 3] == 'S') { countPart1++; }
                        }

                        // Down
                        if (i <= input.Length - 4)
                        {
                            if (input[i + 1][j] == 'M' && input[i + 2][j] == 'A' && input[i + 3][j] == 'S') { countPart1++; }
                        }

                        // Dowm Left
                        if (i <= input.Length - 4 && j >= 3)
                        {
                            if (input[i + 1][j - 1] == 'M' && input[i + 2][j - 2] == 'A' && input[i + 3][j - 3] == 'S') { countPart1++; }
                        }

                        // Left
                        if (j >= 3)
                        {
                            if (input[i][j - 1] == 'M' && input[i][j - 2] == 'A' && input[i][j - 3] == 'S') { countPart1++; }
                        }

                        // Up Left
                        if (j >= 3 && i >= 3)
                        {
                            if (input[i - 1][j - 1] == 'M' && input[i - 2][j - 2] == 'A' && input[i - 3][j - 3] == 'S') { countPart1++; }
                        }
                    }
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == 'A')
                    {
                        // Up Right
                        if (!(i >= 1 && j <= input[i].Length - 2))
                        {
                            continue;
                        }

                        // Down Right
                        if (!(i <= input.Length - 2 && j <= input[i].Length - 2))
                        {
                            continue;
                        }

                        // Dowm Left
                        if (!(i <= input.Length - 2 && j >= 1))
                        {
                            continue;
                        }

                        // Up Left
                        if (!(j >= 1 && i >= 1))
                        {
                            continue;
                        }

                        if (input[i - 1][j - 1] == 'M' && input[i - 1][j + 1] == 'S' && input[i + 1][j + 1] == 'S' && input[i + 1][j - 1] == 'M'
                            || input[i - 1][j - 1] == 'M' && input[i - 1][j + 1] == 'M' && input[i + 1][j + 1] == 'S' && input[i + 1][j - 1] == 'S'
                            || input[i - 1][j - 1] == 'S' && input[i - 1][j + 1] == 'M' && input[i + 1][j + 1] == 'M' && input[i + 1][j - 1] == 'S'
                            || input[i - 1][j - 1] == 'S' && input[i - 1][j + 1] == 'S' && input[i + 1][j + 1] == 'M' && input[i + 1][j - 1] == 'M')
                        {
                            countPart2++;
                        }
                    }
                }
            }

            Console.WriteLine(countPart1);
            Console.WriteLine(countPart2);
        }
    }
}
