namespace AdventOfCode2023
{
    public abstract class SolutionBase(string day, string name)
    {
        public abstract int Day { get; }
        public abstract string Name { get; }
        public abstract bool Input { get; }
        public abstract string Part1Solution(string input);
        public abstract string Part2Solution(string input);

        
        
        public abstract void Solve();

        public string ReadInput(string fileName)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Day" + Day.ToString(), fileName);
            return File.ReadAllText(path);
        }

        public void ShowSolution()
        {
            Solve();
            Console.WriteLine($"Solution for Day {Day} - {Name}");
            Console.WriteLine("===================================");
            Console.WriteLine($"Part 1: {Part1Solution}");
            Console.WriteLine($"Part 2: {Part2Solution}");
        }
    }
}
