using System.Windows.Media;

namespace TilTakToe.Classes.StaticClasses
{
    public  static class TTTColors
    {
        public  static SolidColorBrush GetCellWhileClickingColor()
        {
            return new SolidColorBrush(Color.FromArgb(0x84, 0xFF, 0xFF, 0x00));
        }

        public  static SolidColorBrush GetCursorAboceCellColor()
        {
            return new SolidColorBrush(Color.FromArgb(0x54, 0xFF, 0xFF, 0x00));
        }

        public  static SolidColorBrush GetNeutralCellColor()
        {
            return new SolidColorBrush(Color.FromRgb(0xFF, 0xFF, 0xFF));
        }
    }
}
