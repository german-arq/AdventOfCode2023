using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day1
{
    public class Day1Solution () : SolutionBase (1, "Trebuchet?!")
    {
        public override void Solve()
        {
            var inputLines = Input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            
            // Part 1
            var calibrationValuesSum = inputLines.Select(GetCalibrationValue).Sum();
            Part1Solution = calibrationValuesSum.ToString();

            // Part 2
            var calibrationValuesSumIncludingDigitsAsWords = inputLines.Select(GetCalibrationValueIncludingDigitsAsWords).Sum();
            Part2Solution = calibrationValuesSumIncludingDigitsAsWords.ToString();

        }

        public int GetCalibrationValue(string inputLine)
        {
            var firstDigit = inputLine.First(x => char.IsDigit(x));
            var lastDigit = inputLine.Last(x => char.IsDigit(x));

            return int.Parse(firstDigit.ToString() + lastDigit.ToString());
        }

        public string[] DigitsAsWords = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

        public int GetCalibrationValueIncludingDigitsAsWords(string inputLine)
        {
            // Find the first digit
            var firstDigit = inputLine.FirstOrDefault(char.IsDigit);
            var firstDigitIndex = default(char).Equals(firstDigit) ? inputLine.Length : inputLine.IndexOf(firstDigit);
            
            foreach (var digitAsWord in DigitsAsWords)
            {
                var digitIndex = inputLine.IndexOf(digitAsWord);
                if (digitIndex > -1 && digitIndex < firstDigitIndex)
                {
                    firstDigitIndex = digitIndex;
                    firstDigit = GetDigitFromWord(digitAsWord).ToString()[0];
                }
            }

            // Find the last digit
            var lastDigit = inputLine.LastOrDefault(char.IsDigit);
            var lastDigitIndex = default(char).Equals(lastDigit) ? 0 : inputLine.LastIndexOf(lastDigit);

            foreach (var digitAsWord in DigitsAsWords)
            {
                var digitIndex = inputLine.LastIndexOf(digitAsWord);
                if (digitIndex > -1 && digitIndex > lastDigitIndex)
                {
                    lastDigitIndex = digitIndex;
                    lastDigit = GetDigitFromWord(digitAsWord).ToString()[0];
                }
            }

            return int.Parse(firstDigit.ToString() + lastDigit.ToString());
        }

        public int GetDigitFromWord(string word)
        {
            return (int)Enum.Parse(typeof(DigitsAsWords), word);
        }
    }

    public enum DigitsAsWords
    {
        one = 1,
        two = 2,
        three = 3,
        four = 4,
        five = 5,
        six = 6,
        seven = 7,
        eight = 8,
        nine = 9
    }
}
