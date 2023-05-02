using System.Windows;
using System.Windows.Controls;
using TilTakToe.Classes.StaticClasses.Web;

namespace TilTakToe.Classes.StaticClasses
{
    public  static class CellProcessing
    {
        public  static bool IscellEmpty<T>(Grid grid, T Object) where T : UIElement
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

        public  static Image GetCellImage<T>(Grid grid, T Object) where T : UIElement
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

        public static Image GetCellImageForMultiplayer<T>(Grid grid, T Object , int port) where T : UIElement
        {
            foreach (var child in grid.Children)
            {
                if (child is Image img && Grid.GetRow(img) == Grid.GetRow(Object) && Grid.GetColumn(img) == Grid.GetColumn(Object))
                {
                    Server.SendMessageAsync(port, "127.0.0.1", Grid.GetRow(Object).ToString() + " " + Grid.GetColumn(Object).ToString() );
                    return img;
                }
            }

            return null;
        }
    }
}
