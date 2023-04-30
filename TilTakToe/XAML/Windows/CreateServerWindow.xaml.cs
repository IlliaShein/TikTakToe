using System.Windows;
using System.Windows.Input;
using TilTakToe.Classes.StaticClasses;
using TilTakToe.Classes.StaticClasses.Web;

namespace TilTakToe.XAML.Windows
{
    public partial class CreateServerWindow : Window
    {
        public CreateServerWindow()
        {
            InitializeComponent();
        }

        private void ExitButon_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.CloseWindow();
        }

        private void MinimizeButon_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.MinimizeWindow(createServerWindow);
        }

        private void MenuBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMethods.HoldAndMoveWindow(createServerWindow);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MultiplayerWindow multiplayerMenu = new MultiplayerWindow();
            multiplayerMenu.Left = this.Left;
            multiplayerMenu.Top = this.Top;

            multiplayerMenu.Show();
            this.Close();
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            const string ip = "127.0.0.1";
            const int port = 8080;
            var message = ServerNameTextBox.Text + " " + ip;

            Server.SendMessageAsync(port, ip, message);

            WaitingOpponentScreen waitingOpponentScreen = new WaitingOpponentScreen();
            waitingOpponentScreen.Left = this.Left;
            waitingOpponentScreen.Top = this.Top;

            waitingOpponentScreen.Show();
            this.Close();
        }
    }
}
