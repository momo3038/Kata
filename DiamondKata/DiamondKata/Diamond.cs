using System.Collections.Generic;
using System.Text;

namespace DiamondKata
{
    public class Diamond
    {
        private const char FirstLetter = 'A';

        public static List<string> Create(char maxLetter)
        {
            var totalLetterToDisplay = maxLetter - FirstLetter;

            var diamond = new List<string>();

            for (var lineIndex = 0; lineIndex <= totalLetterToDisplay; lineIndex++)
            {
                var letterToDisplay = (char)(FirstLetter + lineIndex);
                diamond.Add(CreateLine(letterToDisplay, totalLetterToDisplay, lineIndex));
            }

            ReverseDiamondHorizontaly(diamond);

            return diamond;
        }

        private static string CreateLine(char letterToDisplay, int numberLetterToDisplay, int lineIndex)
        {
            var builder = new StringBuilder();
            var diamondWidth = ((numberLetterToDisplay + 1) * 2) - 1;
            AddDash(diamondWidth, builder);
            AddLetter(letterToDisplay, diamondWidth, lineIndex, builder);
            return builder.ToString();
        }

        private static void AddLetter(char letterToDisplay, int diamondWith, int lineIndex, StringBuilder builder)
        {
            builder[diamondWith / 2 - lineIndex] = letterToDisplay;
            builder[diamondWith / 2 + lineIndex] = letterToDisplay;
        }

        private static void AddDash(int numberLetterToDisplay, StringBuilder builder)
        {
            builder.Insert(0, "-", numberLetterToDisplay);
        }

        private static void ReverseDiamondHorizontaly(List<string> diamond)
        {
            var diamondCopy = new List<string>(diamond);
            diamondCopy.Reverse();
            diamondCopy.RemoveAt(0);
            diamond.AddRange(diamondCopy);
        }
    }
}