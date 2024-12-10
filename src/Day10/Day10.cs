namespace AoC2024.Day10
{
    internal class Day10
    {
        public void Solve()
        {
            var input = File.ReadAllLines("Day10/input.txt").Select(x => x.ToArray().Select(y => int.Parse(y.ToString())).ToList()).ToList();

            List<(int x, int y, int score)> trailheads = [];
            List<(int x, int y)> alreadyVisited = [];

            for (int y = 0; y < input.Count; y++)
            {
                for (int x = 0; x < input[y].Count; x++)
                {
                    if (alreadyVisited.Contains((x, y)))
                    {
                        continue;
                    }

                    Queue<(int x, int y)> nextPoints = [];

                    if (input[y][x] == 0)
                    {
                        alreadyVisited.Clear();
                        nextPoints.Enqueue((x, y));
                        var score = 0;

                        while (nextPoints.Count > 0)
                        {
                            var currentPoint = nextPoints.Dequeue();
                            if (!alreadyVisited.Contains(currentPoint))
                            {
                                alreadyVisited.Add(currentPoint);
                            }
                            // Remove this to solve Part 2
                            else
                            {
                                continue;
                            }

                            // look up
                            if (currentPoint.y > 0)
                            {
                                if (input[currentPoint.y - 1][currentPoint.x] - input[currentPoint.y][currentPoint.x] == 1)
                                {
                                    nextPoints.Enqueue((currentPoint.x, currentPoint.y - 1));
                                }
                            }

                            // look right
                            if (currentPoint.x < input[currentPoint.y].Count - 1)
                            {
                                if (input[currentPoint.y][currentPoint.x + 1] - input[currentPoint.y][currentPoint.x] == 1)
                                {
                                    nextPoints.Enqueue((currentPoint.x + 1, currentPoint.y));
                                }
                            }

                            // look down
                            if (currentPoint.y < input.Count - 1)
                            {
                                if (input[currentPoint.y + 1][currentPoint.x] - input[currentPoint.y][currentPoint.x] == 1)
                                {
                                    nextPoints.Enqueue((currentPoint.x, currentPoint.y + 1));
                                }
                            }

                            // look left
                            if (currentPoint.x > 0)
                            {
                                if (input[currentPoint.y][currentPoint.x - 1] - input[currentPoint.y][currentPoint.x] == 1)
                                {
                                    nextPoints.Enqueue((currentPoint.x - 1, currentPoint.y));
                                }
                            }

                            if (input[currentPoint.y][currentPoint.x] == 9)
                            {
                                score++;
                            }
                        }

                        trailheads.Add((x, y, score));
                    }
                }
            }

            Console.WriteLine(trailheads.Sum(x => x.score));
        }
    }
}
