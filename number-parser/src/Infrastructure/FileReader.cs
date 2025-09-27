using DigitParser.Abstractions;

namespace DigitParser.Infrastructure
{
    public class FileReader : IFileReader
    {
        public string[] ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Die Datei '{filePath}' wurde nicht gefunden.");
            }

            try
            {
                return File.ReadAllLines(filePath);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Fehler beim Lesen der Datei '{filePath}'", ex);
            }
        }
    }
}