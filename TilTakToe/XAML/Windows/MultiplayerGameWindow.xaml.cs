using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TilTakToe.Classes.StaticClasses;
using TilTakToe.XAML.Windows.LittleWindows;

namespace TilTakToe.XAML.Windows
{
    public partial class MultiplayerGameWindow : Window
    {
        private Socket tcpSocket { get; set; }
        public string PlayerSide { get; set; }

        public MultiplayerGameWindow()
        {
            GameVariebles.CrossTurn = true;
            GeneralMethods.CloseMultiplayerGameWindow = false;
            InitializeComponent();
            CheckingCloseMultiplayerGameWindowAsync();

            if (GameVariebles.PlayerSideIsToes)
            {
                PlayerSide = "Toes";
                SocketsInfo.Port = 8080;
                SocketsInfo.PortTo = 8090;
            }
            else
            {
                PlayerSide = "Crosses";
                SocketsInfo.Port = 8090;
                SocketsInfo.PortTo = 8080;
            }

            GameLogic.WriteStatus(MainMultiplayerGrid, MessageTextBlock);
            if ((PlayerSide == "Toes" && GameVariebles.CrossTurn) || (PlayerSide == "Crosses" && !GameVariebles.CrossTurn))
            {
                WaitingForTurnChangeAsync(SocketsInfo.Port, "127.0.0.1");
            }
        }

        public async Task CheckingCloseMultiplayerGameWindowAsync()
        {
            while (true)
            {
                if (GeneralMethods.CloseMultiplayerGameWindow == true)
                {
                    tcpSocket.Close();
                    this.Close();
                }

                await Task.Delay(100);
            }
        }


        public async void WaitingForTurnChangeAsync(int port, string ip )
        {
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(6);

            Socket listener;

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

            listener.Shutdown(SocketShutdown.Both);
            listener.Close();
            tcpSocket.Close();

            string message = data.ToString();

            string[] dividedMessage = message.Split(" ");

            if(dividedMessage.Length == 1)
            {
                WindowsChanging.OpenLittleWindow(this, new OpponentExitGameWindow());

                return;
            }

            Image image = null;
            foreach (var child in MainMultiplayerGrid.Children)
            {
                if (child is Image img && Grid.GetRow(img) == Convert.ToInt32(dividedMessage[0]) && Grid.GetColumn(img) == Convert.ToInt32(dividedMessage[1]))
                {
                    image = img;
                }
            }

            GameLogic.SetPathToCrossOrToeImage(image);
            GameLogic.WriteStatus(MainMultiplayerGrid, MessageTextBlock);
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            if (CellProcessing.IscellEmpty(MainMultiplayerGrid, (Border)sender))
            {
                ((Border)sender).Background = TTTColors.CursorAboceCellColor;
            }
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Border)sender).Background = TTTColors.NeutralCellColor;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (CellProcessing.IscellEmpty(MainMultiplayerGrid, (Border)sender))
            {
                ((Border)sender).Background = TTTColors.CellWhileClickingColor;
            }
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!CellProcessing.IscellEmpty(MainMultiplayerGrid, (Border)sender))
            {
                return;
            }

            ((Border)sender).Background = TTTColors.NeutralCellColor;

            if ((PlayerSide == "Crosses" && GameVariebles.CrossTurn) || (PlayerSide == "Toes" && !GameVariebles.CrossTurn))
            {
                Image image = CellProcessing.GetCellImageForMultiplayer(MainMultiplayerGrid, (Border)sender, SocketsInfo.PortTo);
                GameLogic.SetPathToCrossOrToeImage(image);
                GameLogic.WriteStatus(MainMultiplayerGrid,MessageTextBlock);

                WaitingForTurnChangeAsync(SocketsInfo.Port, "127.0.0.1");
            }
        }

        private void ExitButon_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.CloseWindow();
        }

        private void MinimizeButon_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.MinimizeWindow(multiplayerGameWindow);
        }

        private void MenuBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMethods.HoldAndMoveWindow(multiplayerGameWindow);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tcpSocket.Close();
            }
            catch(Exception)
            { 
            }

            WindowsChanging.OpenLittleWindow(this,new AreYouSureWindow());
        }
    }
}
