namespace DigitParser.Abstractions
{
    /// <summary>
    /// Interface für das Einlesen von Dateien
    /// </summary>
    public interface IFileReader
    {
        string[] ReadFile(string filePath);
    }
}