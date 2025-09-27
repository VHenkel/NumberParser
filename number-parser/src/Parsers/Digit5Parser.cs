using DigitParser.Abstractions;
using DigitParser.Models;

namespace DigitParser.Parsers
{
    public class Digit5Parser : IDigitParser
    {
        public int Priority => 7;

        public bool CanParse(string[] content, int rowIndex, int columnIndex)
        {
            var position = new ScanPosition(content, rowIndex, columnIndex);

            // Ziffer 5: "-----"
            string sequence = ExtractDashSequence(position);
            return sequence == "-----";
        }

        public string Parse() => "5";

        public int GetWidth() => DigitConstants.DIGIT_5_WIDTH;

        private string ExtractDashSequence(ScanPosition position)
        {
            string sequence = "";
            int col = position.Column;

            while (col < position.Content[position.Row].Length &&
                   position.Content[position.Row][col] == '-')
            {
                sequence += '-';
                col++;
            }

            return sequence;
        }
    }
}