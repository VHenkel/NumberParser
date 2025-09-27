using DigitParser.Abstractions;
using DigitParser.Models;

namespace DigitParser.Services
{
    public class DigitScanner : IDigitScanner
    {
        private readonly IEnumerable<IDigitParser> _parsers;
        private readonly IOutputWriter _outputWriter;

        public DigitScanner(IEnumerable<IDigitParser> parsers, IOutputWriter outputWriter)
        {
            _parsers = parsers.OrderByDescending(p => p.Priority);
            _outputWriter = outputWriter;
        }

        public void ScanContent(string[] content)
        {
            for (int rowIndex = 0; rowIndex <= content.Length - DigitConstants.DIGIT_HEIGHT;
                 rowIndex += DigitConstants.DIGIT_HEIGHT)
            {
                if (rowIndex >= content.Length) break;

                ScanRow(content, rowIndex);
                _outputWriter.WriteLine("");
            }
        }

        private void ScanRow(string[] content, int rowIndex)
        {
            string currentLine = content[rowIndex];

            for (int columnIndex = 0; columnIndex < currentLine.Length; columnIndex++)
            {
                char currentChar = currentLine[columnIndex];

                // Skip Leerzeichen und Tabulatoren
                if (currentChar == ' ' || currentChar == '\t') continue;

                // Versuche Ziffer zu parsen
                var parser = FindParser(content, rowIndex, columnIndex);

                if (parser != null)
                {
                    _outputWriter.Write(parser.Parse() + " ");
                    columnIndex += parser.GetWidth() - 1; // -1 weil die for-Schleife auch incrementiert
                }
                else
                {
                    _outputWriter.Write("? ");
                    _outputWriter.WriteError($"Warnung: Unbekanntes Zeichen '{currentChar}' " +
                                           $"bei Zeile {rowIndex}, Spalte {columnIndex}");
                }
            }
        }

        private IDigitParser? FindParser(string[] content, int rowIndex, int columnIndex)
        {
            return _parsers.FirstOrDefault(p => p.CanParse(content, rowIndex, columnIndex));
        }
    }
}