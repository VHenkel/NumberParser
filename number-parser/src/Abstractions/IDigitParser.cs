namespace DigitParser.Abstractions
{
    /// <summary>
    /// Interface für die Erkennung einer spezifischen Ziffer
    /// </summary>
    public interface IDigitParser
    {
        /// <summary>
        /// Prüft ob die aktuelle Position eine bestimmte Ziffer darstellt
        /// </summary>
        bool CanParse(string[] content, int rowIndex, int columnIndex);

        /// <summary>
        /// Gibt die erkannte Ziffer zurück
        /// </summary>
        string Parse();

        /// <summary>
        /// Gibt die Breite der erkannten Ziffer zurück (für Spalten-Skip)
        /// </summary>
        int GetWidth();

        /// <summary>
        /// Priorität des Parsers (höhere Werte = höhere Priorität)
        /// </summary>
        int Priority { get; }
    }
}