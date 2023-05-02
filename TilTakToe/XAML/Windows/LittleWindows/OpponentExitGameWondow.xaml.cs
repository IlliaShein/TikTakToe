﻿using System.Windows;
using System.Windows.Input;
using TilTakToe.Classes.StaticClasses;

namespace TilTakToe.XAML.Windows.LittleWindows
{
    public partial class OpponentExitGameWondow : Window
    {
        public OpponentExitGameWondow()
        {
            InitializeComponent();
        }
        private void ExitButon_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.CloseWindow();
        }

        private void MinimizeButon_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.MinimizeWindow(opponentExitGameWondow);
        }

        private void MenuBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMethods.HoldAndMoveWindow(opponentExitGameWondow);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.CloseMultiplayerGameWindow = true;

            StartWindow startWindow = new StartWindow();
            startWindow.Left = this.Left;
            startWindow.Top = this.Top;
            startWindow.Show();

            this.Close();
        }
    }
}