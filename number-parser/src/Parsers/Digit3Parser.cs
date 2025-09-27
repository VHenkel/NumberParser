using DigitParser.Abstractions;
using DigitParser.Models;

namespace DigitParser.Parsers
{
    public class Digit3Parser : IDigitParser
    {
        public int Priority => 6; // Höhere Priorität als 2, da spezifischer

        public bool CanParse(string[] content, int rowIndex, int columnIndex)
        {
            var position = new ScanPosition(content, rowIndex, columnIndex);

            // Ziffer 3: "---" mit '/' in der nächsten Zeile
            string sequence = ExtractDashSequence(position);
            if (sequence != "---") return false;

            // Prüfe auf '/' in Zeile+1, am Ende der Sequenz-2
            var slashChar = position.GetCharAt(1, sequence.Length - 2);
            return slashChar == '/';
        }

        public string Parse() => "3";

        public int GetWidth() => DigitConstants.DIGIT_3_WIDTH;

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