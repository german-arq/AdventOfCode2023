using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day4
{
    public class Day4Solution() : SolutionBase(4, "Scratchcards")
    {
        public override void Solve()
        {
            // Part 1
            var points = Input.Select(GetPointsFromCard).Sum();
            Part1Solution = $"{points}";

            // Part 2
            var totalScratchcards = GetTotalScracthcards(Input);
            Part2Solution = $"{totalScratchcards}";
        }

        public static int GetPointsFromCard(string card)
        {
            var numbersInCommon = GetNumbersInCommon(card);

            var points = 0;
            if (numbersInCommon > 0) points += 1;
            if(numbersInCommon > 1) points = (int)Math.Pow(2, numbersInCommon - 1);

            return points;
        }

        public static int GetNumbersInCommon(string card)
        {
            var numbers = card.Split(':')[1].Trim();
            var winningNumbers = numbers.Split('|')[0].Trim().Split(' ').Select(n => n.Trim()).Where(n => !string.IsNullOrEmpty(n)).Where(n => n.All(char.IsDigit)).Select(int.Parse);
            var numbersYouHave = numbers.Split('|')[1].Trim().Split(' ').Select(n => n.Trim()).Where(n => !string.IsNullOrEmpty(n)).Where(n => n.All(char.IsDigit)).Select(int.Parse);

            var numbersInCommon = winningNumbers.Intersect(numbersYouHave);

            return numbersInCommon.Count();
        }

        public static int GetTotalScracthcards(string[] cards)
        {
            var totalScratchcards = cards.Length;
            var numberOfCopies = Enumerable.Repeat(0, cards.Length).ToArray();

            for (int i = 0; i < cards.Length; i++)
            {
                var card = cards[i];
                var cardIndex = i+1;

                var cardPoints = GetNumbersInCommon(card);
                var numberOfCopiesOfCard = numberOfCopies[i];
                
                for (int j = i+1; j < cardIndex+cardPoints && j < cards.Length; j++)
                {
                    numberOfCopies[j] += 1;
                    numberOfCopies[j] += numberOfCopiesOfCard;
                }                
            }

            return totalScratchcards + numberOfCopies.Sum();
        }


    }
}
