using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day2
{
    public class Day2Solution() : SolutionBase(2, "Cube Conundrum")
    {
        private readonly GameSet ACTUAL_CUBES = new(Red:12, Green:13, Blue:14);
        public override void Solve()
        {
            // Part 1
            var games = Input.Select(Game.FromString).ToList();
            var sumOfPossibleGames = games.Where(g => g.IsPossibleGame(ACTUAL_CUBES)).Sum(g => g.Id);
            Part1Solution = $"{sumOfPossibleGames}";

            // Part 2
            var fewestCubesNeededForMakeItPossible = games.Select(g => g.FewestCubesNeededForMakeItPossible()).ToList();
            var powerOfCubesNeededForMakeItPossible = fewestCubesNeededForMakeItPossible.Sum(g => g.Power);
            Part2Solution = $"{powerOfCubesNeededForMakeItPossible}";
        }
    }

    public record Game(int Id, List<GameSet> GameSets)
    {
        public static Game FromString(string input)
        {
            var id = int.Parse(input.Split(":")[0].Replace("Game", "").Trim());
            var gameSets = input.Split(":")[1].Split(";").Select(s => GameSet.FromString(s.Trim())).ToList();
            return new Game(id, gameSets);
        }

        public bool IsPossibleGame(GameSet actualCubes) => GameSets.All(actualCubes.CouldContain);

        public GameSet FewestCubesNeededForMakeItPossible()
        {
            var blueCubesNeeded = GameSets.Max(gs => gs.Blue);
            var redCubesNeeded = GameSets.Max(gs => gs.Red);
            var greenCubesNeeded = GameSets.Max(gs => gs.Green);

            return new GameSet(Blue: blueCubesNeeded, Red: redCubesNeeded, Green: greenCubesNeeded);
        }      
    }

    public record GameSet(int Blue = 0, int Red = 0, int Green = 0)
    {
        public int Blue { get; set; } = Blue;
        public int Red { get; set; } = Red;
        public int Green { get; set; } = Green;

        public static GameSet FromString(string input)
        {
            var gameSet = new GameSet();

            var parts = input.Split(",");
            foreach (var part in parts)
            {
                var number = part.Trim().Split(" ")[0].Trim();
                var colorString = part.Trim().Split()[1].Trim();

                if (!int.TryParse(number, out var _))
                {
                    throw new ArgumentException($"Invalid input: {input}");
                }

                _ = colorString switch
                {
                    "blue" => gameSet.Blue = int.Parse(number),
                    "red" => gameSet.Red = int.Parse(number),
                    "green" => gameSet.Green = int.Parse(number),
                    _ => throw new ArgumentException($"Invalid input: {input}")
                };

            }
            return gameSet;
        }

        public bool CouldContain(GameSet another)
        {
            return Blue >= another.Blue && Red >= another.Red && Green >= another.Green;
        }

        public int Power => Blue * Red * Green;
    }
}
