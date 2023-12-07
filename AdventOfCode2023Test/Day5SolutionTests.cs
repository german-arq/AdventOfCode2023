using AdventOfCode2023.Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    public class Day5SolutionTests
    {
        //[Fact]
        //public void MapRanges()
        //{
        //    // Arrange
        //    (List<int> expectedSourceRange, List<int> expectedDestinationRange) = (new List<int> { 50, 51, 52, 53 }, new List<int> { 98, 99, 100, 101 });

        //    // Act
        //    var (sourceRange, destinationRange) = Day5Solution.MapRanges(50, 98, 4);

        //    // Assert
        //    Assert.Equal(expectedSourceRange, sourceRange);
        //    Assert.Equal(expectedDestinationRange, destinationRange);
        //}

        [Fact]
        public void GetMappedValue()
        {
            // Arrange
            (long destRangeStart, long sourceRangeStart, long rangeLenght) = (50, 98, 2);
            var expectedMappedValue = 51;

            // Act
            var mappedValue = Day5Solution.GetMapppedValue(99, destRangeStart, sourceRangeStart, rangeLenght);

            // Assert
            Assert.Equal(expectedMappedValue, mappedValue);
        }

        [Fact]
        public void GetMappedValue_Default_IfValueNotInRange()
        {
            // Arrange
            (long destRangeStart, long sourceRangeStart, long rangeLenght) = (50, 98, 2);
            var expectedMappedValue = 10;

            // Act
            var mappedValue = Day5Solution.GetMapppedValue(10, destRangeStart, sourceRangeStart, rangeLenght);

            // Assert
            Assert.Equal(expectedMappedValue, mappedValue);
        }

        [Fact]
        public void GetMappedValueFromRanges()
        {
            // Arrange
            var seed = 79;
            IEnumerable<(long destRangeStart, long sourceRangeStart, long rangeLenght)> seedToSoilRanges = new List<(long destRangeStart, long sourceRangeStart, long rangeLenght)> { (50, 98, 2), (52, 50, 48) };
            IEnumerable<(long destRangeStart, long sourceRangeStart, long rangeLenght)> seedToFertalizerRange = new List<(long destRangeStart, long sourceRangeStart, long rangeLenght)> { (0, 15, 37), (37, 52, 2), (39, 0, 15) };
            var expectedMappedValue = 81;

            // Act
            var mappedValueToSoil = Day5Solution.GetMappedValueFromRanges(seed, seedToSoilRanges);
            var mappedValueToFertalizer = Day5Solution.GetMappedValueFromRanges(mappedValueToSoil, seedToFertalizerRange);

            // Assert
            Assert.Equal(expectedMappedValue, mappedValueToFertalizer);
        }
    }
}
