using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    public class Day2SolutionShould // : IDisposable
    {
        //List<GameSet[]>? GameSets = new()
        //{
        //    new GameSet[]
        //    {
        //        new(3, 4, 0),
        //        new(1, 0, 2),
        //        new(5, 4, 13)
        //    }
        //};

        //public Day2SolutionShould() 
        //{ 
        //    GameSets = new()
        //    {
        //        new GameSet[]
        //        {
        //            new(3, 4, 0),
        //            new(1, 0, 2),
        //            new(5, 4, 13)
        //        }
        //    };
        
        //}

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

        public static IEnumerable<object[]> GamesTest
        {
            get
            {
                yield return new object[] { "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", new Game(1, [new(Blue: 3, Red: 4), new(Red: 1, Green: 2, Blue: 6), new(Green:2)]) };               
                yield return new object[] { "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", new Game(2, [new(Blue: 1, Green: 2), new(Red: 1, Green: 3, Blue:4), new(Blue:1, Green:1)]) };               
                yield return new object[] { "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", new Game(3, [new(Blue: 6, Red: 20, Green:8), new(Red: 4, Green: 13, Blue:5), new(Red:1, Green:5)]) };               
                yield return new object[] { "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", new Game(4, [new(Green:1, Blue: 6, Red: 3), new(Red: 6, Green:3), new(Blue:15, Green:3, Red:14)]) };               
                yield return new object[] { "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", new Game(5, [new(Blue: 1, Red: 6, Green:3), new(Blue:2, Red: 1, Green: 2)]) };                             
            }
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
        [MemberData(nameof(GamesTest))]
        public void GetGameSetsFromInput(string input, Game game)
        {
            // Arrange
            var expected = game;

            // Act
            var actual = Game.FromString(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }



}
