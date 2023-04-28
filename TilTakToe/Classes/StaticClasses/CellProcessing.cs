using System.Windows;
using System.Windows.Controls;

namespace TilTakToe.Classes.StaticClasses
{
    static public class CellProcessing
    {
        static public bool IscellEmpty<T>(Grid grid, T Object) where T : UIElement
        {
            foreach (var child in grid.Children)
            {
                if (child is Image img && Grid.GetRow(img) == Grid.GetRow(Object) && Grid.GetColumn(img) == Grid.GetColumn(Object) && img.Source == null)
                {
                    return true;
                }
            }

            return false;
        }

        static public Image GetCellImage<T>(Grid grid, T Object) where T : UIElement
        {
            foreach (var child in grid.Children)
            {
                if (child is Image img && Grid.GetRow(img) == Grid.GetRow(Object) && Grid.GetColumn(img) == Grid.GetColumn(Object))
                {
                    return img;
                }
            }

            return null;
        }
    }
}
