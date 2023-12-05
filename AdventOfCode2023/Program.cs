using AdventOfCode2023.Day1;
using AdventOfCode2023.Day2;
using AdventOfCode2023.Day3;

namespace AdventOfCode2023
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool isRunning = true;

            Console.WriteLine("Welcome to Advent of Code 2023");
            Console.WriteLine("===================================");
            Console.WriteLine("*Enter exit to quit*");
            Console.WriteLine("===================================");

            while (isRunning)
            {
                Console.WriteLine("Enter the day you want to solve (1-25):");
                var day = Console.ReadLine();

                var result = day switch
                {
                    "1" => (Action)(() => { new Day1Solution().ShowSolution(); }),
                    "2" => (Action)(() => { new Day2Solution().ShowSolution(); }),
                    "3" => (Action)(() => { new Day3Solution().ShowSolution(); }),
                    "exit" => () => isRunning = false,
                    _ => () => Console.WriteLine("Invalid input")
                };

                result();
            }
        }
    }
}
