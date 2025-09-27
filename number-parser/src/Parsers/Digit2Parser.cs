using DigitParser.Abstractions;
using DigitParser.Models;

namespace DigitParser.Parsers
{
    public class Digit2Parser : IDigitParser
    {
        public int Priority => 5;

        public bool CanParse(string[] content, int rowIndex, int columnIndex)
        {
            var position = new ScanPosition(content, rowIndex, columnIndex);

            // Ziffer 2: "---" ohne '/' in der nächsten Zeile
            string sequence = ExtractDashSequence(position);
            if (sequence != "---") return false;

            // Prüfe ob es NICHT eine 3 ist (3 hat '/' in Zeile+1, Spalte-2)
            var slashChar = position.GetCharAt(1, -2);
            return slashChar != '/';
        }

        public string Parse() => "2";

        public int GetWidth() => DigitConstants.DIGIT_2_WIDTH;

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