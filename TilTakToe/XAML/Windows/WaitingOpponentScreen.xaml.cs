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

            WindowsChanging.ChangeWindow(this, new CreateServerWindow());
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
            Server.InitializeSocket(ref tcpSocket, port, ip);
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
                break;
            }

            listener.Shutdown(SocketShutdown.Both);
            listener.Close();
            tcpSocket.Close();

            WindowsChanging.ChangeWindow(this, new MultiplayerGameWindow());
        }
    }
}
