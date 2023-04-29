﻿using System.Windows;
using System.Windows.Input;
using TilTakToe.Classes.StaticClasses;

namespace TilTakToe.XAML.Windows
{
    public partial class MultiplayerMenu : Window
    {
        public MultiplayerMenu()
        {
            InitializeComponent();
            Client.ReceiveInfoAsync(ClientReceive);
            ClientReceive.Text = Client.test.Text;
        }

      

        private void ExitButon_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.CloseWindow();
        }

        private void MinimizeButon_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.MinimizeWindow(MultiplayerWindow);
        }

        private void MenuBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMethods.HoldAndMoveWindow(MultiplayerWindow);
        }

        private void SingleplayerButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void CreateGameButton_Click(object sender, RoutedEventArgs e)
        {
            CreateServerWindow createServerWindow = new CreateServerWindow();
            createServerWindow.Show();
            Close();
        }
    }
}
