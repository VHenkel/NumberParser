using DigitParser.Abstractions;

namespace DigitParser.Infrastructure
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteError(string message)
        {
            Console.Error.WriteLine(message);
        }
    }
}