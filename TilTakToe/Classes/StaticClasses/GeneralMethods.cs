using System.Windows;

namespace TilTakToe.Classes.StaticClasses
{
    static public class GeneralMethods
    {
        static public void CloseWindow()
        {
            Application.Current.Shutdown();
        }

        static public void MinimizeWindow(Window window)
        {
            window.WindowState = WindowState.Minimized;
        }

        static public void HoldAndMoveWindow(Window window)
        {
            window.DragMove();
        }
    }
}
