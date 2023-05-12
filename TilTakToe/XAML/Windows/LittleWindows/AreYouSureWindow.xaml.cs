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
            Server.SendMessageAsync(SocketsInfo.PortTo, "127.0.0.1", "Close");
            GeneralMethods.CloseMultiplayerGameWindow = true;

            WindowsChanging.ChangeWindowFromLittle(this, new StartWindow());
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
