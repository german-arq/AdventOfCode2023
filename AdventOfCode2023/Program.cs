using AdventOfCode2023.Day1;

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

                // Create a switch statement here to handle the user's input
                // If the user enters a number between 1 and 25, then call the ShowSolution method}
                // If the user enters "exit", then exit the program
                // If the user enters anything else, then display an error message and prompt them again
                //Console.WriteLine($"Selected day: {day}");
                //switch (day)
                //{
                //    case "1":
                //        var day1 = new Day1Solution();
                //        day1.ShowSolution();
                //        break;
                //    case "exit":
                //        return;
                //    default:
                //        Console.WriteLine("Invalid input");
                //        break;
                //}

                var result = day switch
                {
                    "1" => (Action)(() => { new Day1Solution().ShowSolution(); }),
                    "exit" => () => isRunning = false,
                    _ => () => Console.WriteLine("Invalid input")
                };

                result();
            }
        }
    }
}
