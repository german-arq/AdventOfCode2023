namespace AdventOfCode2023
{
    public abstract class SolutionBase
    {
        public int Day { get; set; }
        public string Name { get; set; }
        public string Input { get; set; }
        public string Part1Solution { get; set; } = "Not solved yet";
        public string Part2Solution { get; set; } = "Not solved yet";

        protected SolutionBase(int day, string name, string inputFileName = "input.txt")
        {
            Day = day;
            Name = name;
            Input = ReadInput(inputFileName);
        }

        public abstract void Solve();

        public string ReadInput(string fileName)
        {
            try
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Day" + Day.ToString(), fileName);
                Console.WriteLine($"Reading input from {path}");    
                return File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading input file: {ex.Message}");
                return string.Empty;
            }
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
