namespace DigitParser.Abstractions
{
    /// <summary>
    /// Interface für die Ausgabe von Ergebnissen
    /// </summary>
    public interface IOutputWriter
    {
        void Write(string text);
        void WriteLine(string text);
        void WriteError(string message);
    }
}