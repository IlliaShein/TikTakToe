using System.Windows;
using System.Windows.Input;
using TilTakToe.Classes.StaticClasses;
using TilTakToe.Classes.StaticClasses.Web;

namespace TilTakToe.XAML.Windows.LittleWindows
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

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            Server.SendMessageAsync(GeneralMethods.PortTo, "127.0.0.1", "Close");

            StartWindow startWindow = new StartWindow();
            startWindow.Left = this.Left + this.Width/2 - startWindow.Width/2;
            startWindow.Top = this.Top + this.Height/2 - startWindow.Height/2;
            startWindow.Show();

            GeneralMethods.CloseMultiplayerGameWindow = true;
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
