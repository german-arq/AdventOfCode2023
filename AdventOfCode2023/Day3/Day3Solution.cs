using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day3
{
    public class Day3Solution() : SolutionBase(3, "Gear Ratios")
    {
        public override void Solve()
        {
            // Part 1
            var partNumbers = GetPartNumbers(Input);
            var sumOfPartNumbers = partNumbers.Sum();
            Part1Solution = $"{sumOfPartNumbers}";

            // Part 2
            var gearRatio = GetGearRatio(Input);
            Part2Solution = $"{gearRatio}";

        }

        public static List<int> GetPartNumbers(string[] inputLines)
        {
            var partNumbers = new List<int>();
            for (var y = 0; y < inputLines.Length; y++)
            {
                var previousLine = y > 0 ? inputLines[y - 1] : string.Empty;
                var line = inputLines[y];
                var nextLine = y < inputLines.Length - 1 ? inputLines[y + 1] : string.Empty;

                var numbersInLine = GetNumbersInString(line);
                foreach (var number in numbersInLine)
                {
                    var index = number.index;
                    var length = number.number.ToString().Length;

                    var startIndex = index > 0 ? index - 1 : index;
                    var endIndex = index + length < line.Length ? index + length : startIndex + length;

                    var adjacentCharacters = GetAdjancentCharacters(line, previousLine, nextLine, startIndex, endIndex);

                    if (adjacentCharacters.Any(IsSymbol))
                    {
                        partNumbers.Add(number.number);
                    }
                }
            }
            return partNumbers;
        }

        public static int GetGearRatio(string[] inputLines)
        {
            var gearRatio = 0;
            for (int y = 0; y < inputLines.Length; y++)
            {
                var previousLine = y > 0 ? inputLines[y - 1] : string.Empty;
                var line = inputLines[y];
                var nextLine = y < inputLines.Length - 1 ? inputLines[y + 1] : string.Empty;

                var gearIndexes = GetGearsIndexes(line);
                foreach (var gearIndex in gearIndexes)
                {
                    var startIndex = gearIndex > 0 ? gearIndex - 1 : gearIndex;
                    var endIndex = gearIndex < line.Length ? gearIndex + 1 : gearIndex;
                        
                    var digitNextToNonDigitRegex = new Regex(@"\d+(?=\D)|(?<=\D)\d+|\d+");

                    endIndex += 1;
                    var previousLineAdjacentCharacters = string.IsNullOrEmpty(previousLine) ? string.Empty : previousLine[startIndex..endIndex];
                    var lineAdjacentCharacters = line[startIndex..endIndex];
                    var nextLineAdjacentCharacters = string.IsNullOrEmpty(nextLine) ? string.Empty : nextLine[startIndex..endIndex];

                    var numbersAdjacentToGear = new List<int>();

                    var matchesPreviousLine = digitNextToNonDigitRegex.Matches(previousLineAdjacentCharacters);
                    foreach (Match match in matchesPreviousLine.Cast<Match>())
                    {
                        var matchIndex = match.Index;
                        var number = GetCompleteNumberInStringFromIndex(previousLine, startIndex + matchIndex);
                        numbersAdjacentToGear.Add(number);                                
                    }

                    var matchesLine = digitNextToNonDigitRegex.Matches(lineAdjacentCharacters);
                    foreach (Match match in matchesLine.Cast<Match>())
                    {
                        var matchIndex = match.Index;
                        var number = GetCompleteNumberInStringFromIndex(line, startIndex + matchIndex);
                        numbersAdjacentToGear.Add(number);
                    }

                    var matchesNextLine = digitNextToNonDigitRegex.Matches(nextLineAdjacentCharacters);
                    foreach (Match match in matchesNextLine.Cast<Match>())
                    {
                        var matchIndex = match.Index;
                        var number = GetCompleteNumberInStringFromIndex(nextLine, startIndex + matchIndex);
                        numbersAdjacentToGear.Add(number);
                    }
                        
                    if(numbersAdjacentToGear.Count == 2)
                    {
                        int firstNumber = numbersAdjacentToGear[0];
                        int secondNumber = numbersAdjacentToGear[1];
                        gearRatio += firstNumber * secondNumber;
                    }                    
                }
            }
            return gearRatio;
        }



        public static bool IsSymbol(char character) => !char.IsDigit(character) && character != '.';

        public static string GetAdjancentCharacters(string line, string previousLine, string nextLine, int startIndex, int endIndex)
        {
            endIndex += 1;
            var previousLineSubstring = string.IsNullOrEmpty(previousLine) ? string.Empty: previousLine[startIndex..endIndex];
            var lineSubstring = line[startIndex..endIndex];
            var nextLineSubstring = string.IsNullOrEmpty(nextLine) ? string.Empty : nextLine[startIndex..endIndex];

            var adjacentSymbols = previousLineSubstring + lineSubstring + nextLineSubstring;
            return adjacentSymbols;
        }

        public static List<(int index, int number)> GetNumbersInString(string input)
        {
            var result = new List<(int, int)>();
            var currentNumber = "";
            for (var i = 0; i < input.Length; i++)
            {
                var symbol = input[i];
                if (char.IsDigit(symbol))
                {
                    currentNumber += symbol;
                }
                else
                {
                    if (currentNumber != "")
                    {
                        result.Add((i - currentNumber.Length, int.Parse(currentNumber)));
                        currentNumber = "";
                    }
                }
            }
            if(currentNumber != "")
            {
                result.Add((input.Length - currentNumber.Length, int.Parse(currentNumber)));
            }

            return result;
        }

        public static List<int> GetGearsIndexes(string input)
        {
            var result = new List<int>();
            for (var i = 0; i < input.Length; i++)
            {
                var character = input[i];
                if (character == '*')
                {
                    result.Add(i);
                }
            }
            return result;
        }

        public static int GetCompleteNumberInStringFromIndex(string input, int index)
        {
            string number = input[index].ToString();
            for (var i = index-1; i >= 0; i--)
            {
                var character = input[i];
                if (char.IsDigit(character))
                {
                    number = number.Insert(0, character.ToString());
                }
                else
                {
                    break;
                }
            }
            for (var i = index+1; i < input.Length; i++)
            {
                var character = input[i];
                if (char.IsDigit(character))
                {
                    number += character;
                }
                else
                {
                    break;
                }
            }
            return int.Parse(number);
        }
    }
}
