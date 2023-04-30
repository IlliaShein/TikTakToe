using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TilTakToe.Classes.StaticClasses;

namespace TilTakToe.XAML.Windows
{
    /// <summary>
    /// Interaction logic for WaitingOpponentScreen.xaml
    /// </summary>
    public partial class WaitingOpponentScreen : Window
    {
        public WaitingOpponentScreen()
        {
            InitializeComponent();
        }

        private void BackButon_Click(object sender, RoutedEventArgs e)
        {
            CreateServerWindow createServerWindow = new CreateServerWindow();
            createServerWindow.Left = this.Left;
            createServerWindow.Top = this.Top;
            createServerWindow.Show();

            this.Close();
        }

        private void MenuBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMethods.HoldAndMoveWindow(waitingOpponentScreen);
        }

        private void ExitButon_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.CloseWindow();
        }

        private void MinimizeButon_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.MinimizeWindow(waitingOpponentScreen);
        }
    }
}
