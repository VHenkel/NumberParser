namespace DigitParser.Models
{
    /// <summary>
    /// Repräsentiert eine Position im Text-Array
    /// </summary>
    public class ScanPosition
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string[] Content { get; set; }

        public ScanPosition(string[] content, int row, int column)
        {
            Content = content;
            Row = row;
            Column = column;
        }

        public char? GetChar()
        {
            if (Row < 0 || Row >= Content.Length) return null;
            if (Column < 0 || Column >= Content[Row].Length) return null;
            return Content[Row][Column];
        }

        public char? GetCharAt(int rowOffset, int columnOffset)
        {
            int targetRow = Row + rowOffset;
            int targetCol = Column + columnOffset;

            if (targetRow < 0 || targetRow >= Content.Length) return null;
            if (targetCol < 0 || targetCol >= Content[targetRow].Length) return null;

            return Content[targetRow][targetCol];
        }
    }
}