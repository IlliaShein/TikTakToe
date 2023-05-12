using System.Windows;

namespace TilTakToe.Classes.StaticClasses
{
    public static class WindowsChanging
    {
        public static void ChangeWindow(Window oldWindow, Window newWindow)
        {
            newWindow.Left = oldWindow.Left;
            newWindow.Top = oldWindow.Top;
            newWindow.Show();

            oldWindow.Close();
        }

        public static void ChangeWindowFromLittle(Window oldWindow, Window newWindow)
        {
            newWindow.Left = oldWindow.Left + oldWindow.Width / 2 - newWindow.Width / 2;
            newWindow.Top = oldWindow.Top + oldWindow.Height / 2 - newWindow.Height / 2;
            newWindow.Show();

            oldWindow.Close();
        }

        public static void OpenLittleWindow(Window currentWindow, Window newWindow)
        {
            newWindow.Left = currentWindow.Left + currentWindow.Width / 2 - newWindow.Width / 2;
            newWindow.Top = currentWindow.Top + currentWindow.Height / 2 - newWindow.Height / 2;

            newWindow.Show();
        }
    }
}
