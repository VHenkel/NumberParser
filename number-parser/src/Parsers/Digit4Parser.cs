using DigitParser.Abstractions;
using DigitParser.Models;

namespace DigitParser.Parsers
{
    public class Digit4Parser : IDigitParser
    {
        public int Priority => 11; // Höhere Priorität als 1, da spezifischer

        public bool CanParse(string[] content, int rowIndex, int columnIndex)
        {
            var position = new ScanPosition(content, rowIndex, columnIndex);

            // Ziffer 4: '|' mit '_' in der nächsten Zeile
            if (position.GetChar() != '|') return false;

            var charBelow = position.GetCharAt(1, 1);
            return charBelow == '_';
        }

        public string Parse() => "4";

        public int GetWidth() => DigitConstants.DIGIT_4_WIDTH;
    }
}