using System.Windows.Media;

namespace TilTakToe.Classes.StaticClasses
{
    static public class TTTColors
    {
        static public SolidColorBrush GetCellWhileClickingColor()
        {
            return new SolidColorBrush(Color.FromArgb(0x84, 0xFF, 0xFF, 0x00));
        }

        static public SolidColorBrush GetCursorAboceCellColor()
        {
            return new SolidColorBrush(Color.FromArgb(0x54, 0xFF, 0xFF, 0x00));
        }

        static public SolidColorBrush GetNeutralCellColor()
        {
            return new SolidColorBrush(Color.FromRgb(0xFF, 0xFF, 0xFF));
        }
    }
}
