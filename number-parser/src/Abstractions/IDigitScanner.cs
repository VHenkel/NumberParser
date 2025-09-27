namespace DigitParser.Abstractions
{
    /// <summary>
    /// Interface für den Hauptprozess des Scannens
    /// </summary>
    public interface IDigitScanner
    {
        void ScanContent(string[] content);
    }
}