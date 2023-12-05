using AdventOfCode2023.Day2;
using AdventOfCode2023.Day3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    public class Day3SolutionTests
    {
        [Fact]
        public void GetPartNumberWhenSymbolIsAdjacent()
        {
            // Arrange
            var input = new string[] { "467..114..", "...*......", "..35..633.", "......#...", "617*......", ".....+.58.", "..592.....", "......755.", "...$.*....", ".664.598.." };
            var expected = new List<int> { 467, 35, 633, 617, 592, 755, 664, 598 };

            // Act
            var actual = Day3Solution.GetPartNumbers(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GerGearRatio_FromGearsWithTwoNumbersAdjacent()
        {
            // Arrange
            var input = new string[] { "467..114..", "...*......", "..35..633.", "......#...", "617*......", ".....+.58.", "..592.....", "......755.", "...$.*....", ".664.598.." };
            var expected = 467835;

            // Act
            var actual = Day3Solution.GetGearRatio(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> NumbersInString
        {
            get
            {
                yield return new object[] { "467..114..", new List<(int,int)>() { (0, 467), (5, 114) }  };
                yield return new object[] { "..35..633.", new List<(int, int)>() { (2, 35), (6, 633) }  };
                yield return new object[] { "...$.*....", new List<(int, int)>() };
                yield return new object[] { "617*......", new List<(int, int)>() { (0, 617) } };                
            }
        }

        [Theory]
        [MemberData(nameof(NumbersInString))]
        public void GetNumbersInStringWhenStringContainsNumbers(string input, List<(int, int)> expected)
        {
            // Arrange

            // Act
            var actual = Day3Solution.GetNumbersInString(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("467..114..", "", "...*......", 0, 3, "467....*")]
        [InlineData("..35..633.", "...*......", "......#...",  1, 4, "..*..35.....")]
        [InlineData("..35..633.", "...*......", "......#...",  5, 9, "......633..#...")]
        [InlineData("617*......", "......#...", ".....+.58.",  0, 3, "....617*....")]
        [InlineData(".....+.58.", "617*......", "..592.....",  6, 9, ".....58.....")]
        public void GetAdjancentCharacters(string line, string previousLine, string nextLine, int startIndex, int endIndex, string expected)
        {
            // Arrange

            // Act
            var actual = Day3Solution.GetAdjancentCharacters(line, previousLine, nextLine, startIndex, endIndex);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
