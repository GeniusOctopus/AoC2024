namespace AoC2024.Day1
{
    internal class Day1
    {
        public void Solve()
        {
            var input = File.ReadAllLines("Day1/input.txt");
            var distance = 0;
            var groupDistance = 0;

            List<int> leftList = [];
            List<int> rightList = [];

            for (int i = 0; i < input.Length; i++)
            {
                var distances = input[i].Split("   ");
                leftList.Add(int.Parse(distances[0]));
                rightList.Add(int.Parse(distances[1]));
            }

            leftList.Sort();
            rightList.Sort();
            var groups = rightList.GroupBy(x => x);

            for (int i = 0; i < leftList.Count; i++)
            {
                distance += Math.Abs(leftList[i] - rightList[i]);

                var group = groups.FirstOrDefault(x => x.Key == leftList[i]);

                if (group != null)
                {
                    groupDistance += leftList[i] * group.Count();
                }
            }

            Console.WriteLine(distance);
            Console.WriteLine(groupDistance);
        }
    }
}
