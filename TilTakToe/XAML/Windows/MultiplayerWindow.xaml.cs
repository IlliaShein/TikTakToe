using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TilTakToe.Classes.StaticClasses;
using TilTakToe.Classes.StaticClasses.Web;

namespace TilTakToe.XAML.Windows
{
    public partial class MultiplayerWindow : Window
    {
        static private Socket tcpSocket;
        public MultiplayerWindow()
        {
            InitializeComponent();

            const int port = 8080;
            const string ip = "127.0.0.1";

            ReceiveInfoAboutServerAsync(port, ip );
        }

        private void ExitButon_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.CloseWindow();
        }

        private void MinimizeButon_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.MinimizeWindow(multiplayerWindow);
        }

        private void MenuBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMethods.HoldAndMoveWindow(multiplayerWindow);
        }

        private void SingleplayerButton_Click(object sender, RoutedEventArgs e)
        {
            tcpSocket.Close();

            WindowsChanging.ChangeWindow(this, new StartWindow());
        }

        private void CreateGameButton_Click(object sender, RoutedEventArgs e)
        {
            tcpSocket.Close();

            WindowsChanging.ChangeWindow(this, new CreateServerWindow());
        }

        public async void ReceiveInfoAboutServerAsync(int port, string ip)
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
                var size = 0;
                var data = new StringBuilder();

                do
                {
                    size = await listener.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (listener.Available > 0);

                string message = data.ToString();
                string[] dividedMessage = message.Split(" ");

                if(dividedMessage.Length == 2)
                {
                    ServerNameFromServerTextBox.Text = dividedMessage[0];
                    IpFromServerTextBox.Text = dividedMessage[1];

                    var style = (Style)FindResource("GreenButtonStyle");
                    Button connectToServerButton = XAMLObjects.GetServerConnectionButton(style);
                    connectToServerButton.Click += ConnectToServerButton_Click;

                    MultiplayerMenuGrid.Children.Add(connectToServerButton);
                    Grid.SetColumn(connectToServerButton, 2);
                    Grid.SetRow(connectToServerButton, 3);
                }
                else
                {
                    ServerNameFromServerTextBox.Text = " ";
                    IpFromServerTextBox.Text = " ";

                    Button connectToServerButton = (Button)MultiplayerMenuGrid.Children
                        .OfType<Button>()
                        .FirstOrDefault(x => x.Name == "ConnectToServerButton");
                    if (connectToServerButton != null)
                    {
                        MultiplayerMenuGrid.Children.Remove(connectToServerButton);
                    }
                }
                 
                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
        }
        public void ConnectToServerButton_Click(object sender, RoutedEventArgs e)
        {
            const string ip = "127.0.0.1";
            const int port = 8090;
            var message = "connect";

            Server.SendMessageAsync(port, ip, message);
            tcpSocket.Close();

            ServerNameFromServerTextBox.Text = " ";
            IpFromServerTextBox.Text = " ";

            Button connectToServerButton = (Button)MultiplayerMenuGrid.Children
                .OfType<Button>()
                .FirstOrDefault(x => x.Name == "ConnectToServerButton");


            GameVariebles.PlayerSideIsToes = true;

            if (connectToServerButton != null)
            {
                MultiplayerMenuGrid.Children.Remove(connectToServerButton);
            }

            WindowsChanging.ChangeWindow(this, new MultiplayerGameWindow());
        }
    }
}
