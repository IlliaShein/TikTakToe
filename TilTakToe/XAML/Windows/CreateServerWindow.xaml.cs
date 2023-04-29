using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TilTakToe.Classes.StaticClasses;

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
            MultiplayerMenu multiplayerMenu = new MultiplayerMenu();
            multiplayerMenu.Show();
            Close();
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            SendServerInfoAsync(sender, e);
        }

        private async void SendServerInfoAsync(object sender, RoutedEventArgs e)
        {
            const string ip = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            var message = ServerNameTextBox.Text;
            var data = Encoding.UTF8.GetBytes(message);

            await tcpSocket.ConnectAsync(tcpEndPoint);
            await tcpSocket.SendAsync(data, SocketFlags.None);

            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();
        }
    }
}
