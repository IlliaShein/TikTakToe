using System.Windows.Media;

namespace TilTakToe.Classes.StaticClasses
{
    public  static class TTTColors
    {
        public static SolidColorBrush CellWhileClickingColor { get; } = new SolidColorBrush(Color.FromArgb(0x84, 0xFF, 0xFF, 0x00));
        public static SolidColorBrush CursorAboceCellColor { get; } = new SolidColorBrush(Color.FromArgb(0x54, 0xFF, 0xFF, 0x00));
        public static SolidColorBrush NeutralCellColor { get;  } = new SolidColorBrush(Color.FromRgb(0xFF, 0xFF, 0xFF));
    }
}
