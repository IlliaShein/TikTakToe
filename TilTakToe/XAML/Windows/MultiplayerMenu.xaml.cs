using System.Windows;
using System.Windows.Input;
using TilTakToe.Classes.StaticClasses;

namespace TilTakToe.XAML.Windows
{
    public partial class MultiplayerMenu : Window
    {
        public MultiplayerMenu()
        {
            InitializeComponent();
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
    }
}
