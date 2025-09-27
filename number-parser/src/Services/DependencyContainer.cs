using DigitParser.Abstractions;
using DigitParser.Infrastructure;
using DigitParser.Parsers;

namespace DigitParser.Services
{
    /// <summary>
    /// Einfacher DI-Container für die Abhängigkeiten
    /// Kann später durch einen professionellen DI-Container ersetzt werden
    /// </summary>
    public class DependencyContainer
    {
        public IFileReader FileReader { get; }
        public IOutputWriter OutputWriter { get; }
        public IDigitScanner Scanner { get; }
        public IEnumerable<IDigitParser> Parsers { get; }

        public DependencyContainer()
        {
            FileReader = new FileReader();
            OutputWriter = new ConsoleOutputWriter();

            Parsers = new List<IDigitParser>
            {
                new Digit1Parser(),
                new Digit2Parser(),
                new Digit3Parser(),
                new Digit4Parser(),
                new Digit5Parser()
            };

            Scanner = new DigitScanner(Parsers, OutputWriter);
        }
    }
}