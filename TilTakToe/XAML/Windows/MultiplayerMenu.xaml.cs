using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TilTakToe.Classes.StaticClasses;

namespace TilTakToe.XAML.Windows
{
    public partial class MultiplayerMenu : Window
    {
        static Socket tcpSocket;
        public MultiplayerMenu()
        {
            InitializeComponent();
            ReceiveInfoAsync();
        }

        public async void ReceiveInfoAsync()
        {
            const string ip = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(6);

            Socket listener;

            while(true)
            {
                try
                {
                    listener = await tcpSocket.AcceptAsync();
                }
                catch (Exception)
                {
                    return;
                }

                var buffer = new byte[256];
                var size = 0;
                var data = new StringBuilder();

                do
                {
                    size = await listener.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (listener.Available > 0);

                ClientReceive.Text = data.ToString();

                await listener.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("Success")), SocketFlags.None);

                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
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
            tcpSocket.Close();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void CreateGameButton_Click(object sender, RoutedEventArgs e)
        {
            tcpSocket.Close();
            CreateServerWindow createServerWindow = new CreateServerWindow();
            createServerWindow.Show();
            Close();
        }
    }
}
