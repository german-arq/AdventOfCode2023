using AdventOfCode2023.Day1;

namespace AdventOfCode2023Tests
{
    public class Day1SolutionShould
    {
        [Theory]
        [InlineData("1abc2", 12)]
        [InlineData("pqr3stu8vwx", 38)]
        [InlineData("a1b2c3d4e5f", 15)]
        [InlineData("treb7uchet", 77)]
        public void GetCalibrationValue_ReturnsFirstAndLastDigits(string inputLine, int expected)
        {
            // Arrange
            var day1 = new Day1Solution();

            // Act
            var actual = day1.GetCalibrationValue(inputLine);

            // Assert
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("two1nine", 29)]
        [InlineData("eightwothree", 83)]
        [InlineData("abcone2threexyz", 13)]
        [InlineData("xtwone3four", 24)]
        [InlineData("4nineeightseven2", 42)]
        [InlineData("zoneight234", 14)]
        [InlineData("7pqrstsixteen", 76)]
        public void GetCalibrationValueIncludingDigitsAsWords_ReturnsFirstAndLastDigits(string inputLine, int expected)
        {
            // Arrange
            var day1 = new Day1Solution();

            // Act
            var actual = day1.GetCalibrationValueIncludingDigitsAsWords(inputLine);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}