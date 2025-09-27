using DigitParser.Services;

namespace DigitParser
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var container = new DependencyContainer();

                string filePath = args.Length > 0 ? args[0] : "NumberParserExtended.txt";

                var content = container.FileReader.ReadFile(filePath);
                container.Scanner.ScanContent(content);
            }
            catch (FileNotFoundException ex)
            {
                Console.Error.WriteLine($"Fehler: {ex.Message}");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unerwarteter Fehler: {ex.Message}");
                Environment.Exit(2);
            }
        }
    }
}