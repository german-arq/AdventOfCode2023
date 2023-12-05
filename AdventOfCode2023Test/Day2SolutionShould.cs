using AdventOfCode2023.Day2;

namespace AdventOfCode2023.Tests
{
    public class Day2SolutionShould
    {
        public static IEnumerable<object[]> GameSetsTest
        {   get
            {                
                yield return new object[] { "3 blue, 4 red", new GameSet(Blue:3, Red:4) };
                yield return new object[] { "1 blue, 2 green", new GameSet(Blue:1, Green:2) };
                yield return new object[] { "5 blue, 4 red, 13 green", new GameSet(Blue:5, Red:4, Green:13) };
            }
        }  

        [Theory]
        [MemberData(nameof(GameSetsTest))]
        public void GameSet_FromString(string input, GameSet gameSet)
        {
            // Arrange
            var expected = gameSet;

            // Act
            var actual = GameSet.FromString(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", true)]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", true)]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", false)]
        [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", false)]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", true)]
        public void IsPossibleGame_ActualCubesInTheBag(string input, bool possible)
        {
            // Arrange
            var actualCubesInTheBag = new GameSet(Blue: 14, Red: 12, Green: 13);
            var expected = possible;

            // Act
            var actual = Game.FromString(input).IsPossibleGame(actualCubesInTheBag);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 48)]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 12)]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 1560)]
        [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 630)]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 36)]
        public void PowerOfCubesNeededForMakeAGamePossible(string input, int expected)
        {
            // Act
            var actual = Game.FromString(input).FewestCubesNeededForMakeItPossible().Power;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
