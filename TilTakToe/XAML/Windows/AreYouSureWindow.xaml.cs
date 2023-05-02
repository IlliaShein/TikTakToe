using System.Windows;
using System.Windows.Input;
using TilTakToe.Classes.StaticClasses;

namespace TilTakToe.XAML.Windows
{
    public partial class AreYouSureWindow : Window
    {
        public AreYouSureWindow()
        {
            InitializeComponent();
        }
        private void ExitButon_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.CloseWindow();
        }

        private void MinimizeButon_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.MinimizeWindow(areYouSureWindow);
        }

        private void MenuBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMethods.HoldAndMoveWindow(areYouSureWindow);
        }
    }
}
