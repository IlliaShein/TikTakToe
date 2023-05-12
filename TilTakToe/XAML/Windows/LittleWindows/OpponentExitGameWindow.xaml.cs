using System.Windows;
using System.Windows.Input;
using TilTakToe.Classes.StaticClasses;

namespace TilTakToe.XAML.Windows.LittleWindows
{
    public partial class OpponentExitGameWindow : Window
    {
        public OpponentExitGameWindow()
        {
            InitializeComponent();
        }
        private void ExitButon_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.CloseWindow();
        }

        private void MinimizeButon_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.MinimizeWindow(opponentExitGameWindow);
        }

        private void MenuBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMethods.HoldAndMoveWindow(opponentExitGameWindow);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.CloseMultiplayerGameWindow = true;

            WindowsChanging.ChangeWindowFromLittle(this, new StartWindow());
        }
    }
}
