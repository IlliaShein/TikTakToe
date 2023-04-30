using System;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Input;
using TilTakToe.Classes.StaticClasses;
using TilTakToe.Classes.StaticClasses.Web;

namespace TilTakToe.XAML.Windows
{
    public partial class WaitingOpponentScreen : Window
    {
        static private Socket tcpSocket;

        public WaitingOpponentScreen()
        {
            InitializeComponent();
            ReceiveInfoAboutConnectionAsync(8090, "127.0.0.1");
        }

        private void BackButon_Click(object sender, RoutedEventArgs e)
        {
            Server.SendMessageAsync(8080, "127.0.0.1", "Close");

            tcpSocket.Close();

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

        public async void ReceiveInfoAboutConnectionAsync(int port, string ip)
        {

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(6);

            Socket listener;

            while (true)
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
                await listener.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);

                break;
            }

            listener.Shutdown(SocketShutdown.Both);
            listener.Close();
            tcpSocket.Close();

            MultiplayerGameWindow multiplayerGameWindow = new MultiplayerGameWindow();
            multiplayerGameWindow.Left = this.Left;
            multiplayerGameWindow.Top = this.Top;
            multiplayerGameWindow.Show();

            this.Close();
        }
    }
}
