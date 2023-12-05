namespace AdventOfCode2023.Day1
{
    public class Day1Solution () : SolutionBase (1, "Trebuchet?!")
    {
        public string[] DigitsAsWords = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
        public override void Solve()
        {            
            // Part 1
            var calibrationValuesSum = Input.Select(GetCalibrationValue).Sum();
            Part1Solution = calibrationValuesSum.ToString();

            // Part 2
            var calibrationValuesSumIncludingDigitsAsWords = Input.Select(GetCalibrationValueIncludingDigitsAsWords).Sum();
            Part2Solution = calibrationValuesSumIncludingDigitsAsWords.ToString();

        }

        public static int GetCalibrationValue(string inputLine)
        {
            var firstDigit = inputLine.First(x => char.IsDigit(x));
            var lastDigit = inputLine.Last(x => char.IsDigit(x));

            return int.Parse(firstDigit.ToString() + lastDigit.ToString());
        }

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

        public static int GetDigitFromWord(string word)
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
