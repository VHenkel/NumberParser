using DigitParser.Abstractions;
using DigitParser.Models;

namespace DigitParser.Parsers
{
    public class Digit1Parser : IDigitParser
    {
        public int Priority => 10;

        public bool CanParse(string[] content, int rowIndex, int columnIndex)
        {
            var position = new ScanPosition(content, rowIndex, columnIndex);

            // Ziffer 1: Einzelnes '|' ohne '_' in der nächsten Zeile daneben
            if (position.GetChar() != '|') return false;

            // Prüfe ob es NICHT eine 4 ist (4 hat ein '_' in Zeile+1, Spalte+1)
            var charBelow = position.GetCharAt(1, 1);
            return charBelow != '_';
        }

        public string Parse() => "1";

        public int GetWidth() => DigitConstants.DIGIT_1_WIDTH;
    }
}