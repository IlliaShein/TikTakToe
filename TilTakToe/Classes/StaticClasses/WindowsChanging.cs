using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
