﻿using System.Windows;

namespace TilTakToe.Classes.StaticClasses
{
    public static class GeneralMethods
    {
        public static bool CloseMultiplayerGameWindow { get; set; } = false;
        public static void CloseWindow()
        {
            Application.Current.Shutdown();
        }

        public static void MinimizeWindow(Window window)
        {
            window.WindowState = WindowState.Minimized;
        }

        public  static void HoldAndMoveWindow(Window window)
        {
            window.DragMove();
        }
    }
}
