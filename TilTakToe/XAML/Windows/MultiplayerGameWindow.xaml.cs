using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TilTakToe.Classes.StaticClasses;
using TilTakToe.Classes.StaticClasses.Web;
using TilTakToe.XAML.Windows.LittleWindows;

namespace TilTakToe.XAML.Windows
{
    public partial class MultiplayerGameWindow : Window
    {
        private Socket tcpSocket { get; set; }
        public bool CrossTurn { get; set; } = true;
        public string PlayerSide { get; set; }

        public MultiplayerGameWindow()
        {
            GeneralMethods.CloseMultiplayerGameWindow = false;
            InitializeComponent();
            CheckingCloseMultiplayerGameWindowAsync();

            if (Server.PlayerSideIsToes)
            {
                PlayerSide = "Toes";
                GeneralMethods.Port = 8080;
                GeneralMethods.PortTo = 8090;
            }
            else
            {
                PlayerSide = "Crosses";
                GeneralMethods.Port = 8090;
                GeneralMethods.PortTo = 8080;
            }

            WriteStatus();
            if ((PlayerSide == "Toes" && CrossTurn) || (PlayerSide == "Crosses" && !CrossTurn))
            {
                WaitingForTurnChangeAsync(GeneralMethods.Port, "127.0.0.1");
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
                OpponentExitGameWondow opponentExitGameWondow = new OpponentExitGameWondow();
                opponentExitGameWondow.Left = this.Left;
                opponentExitGameWondow.Top = this.Top;
                opponentExitGameWondow.Show();

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

            SetPathToCrossOrToeImage(image);
            WriteStatus();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            if (CellProcessing.IscellEmpty(MainMultiplayerGrid, (Border)sender))
            {
                ((Border)sender).Background = TTTColors.GetCursorAboceCellColor();
            }
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Border)sender).Background = TTTColors.GetNeutralCellColor();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (CellProcessing.IscellEmpty(MainMultiplayerGrid, (Border)sender))
            {
                ((Border)sender).Background = TTTColors.GetCellWhileClickingColor();
            }
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!CellProcessing.IscellEmpty(MainMultiplayerGrid, (Border)sender))
            {
                return;
            }

            ((Border)sender).Background = TTTColors.GetNeutralCellColor();

            if ((PlayerSide == "Crosses" && CrossTurn) || (PlayerSide == "Toes" && !CrossTurn))
            {
                Image image = CellProcessing.GetCellImageForMultiplayer(MainMultiplayerGrid, (Border)sender, GeneralMethods.PortTo);
                SetPathToCrossOrToeImage(image);
                WriteStatus();

                WaitingForTurnChangeAsync(GeneralMethods.Port, "127.0.0.1");
            }
        }

        private void SetPathToCrossOrToeImage(Image image)
        {
            if (CrossTurn)
            {
                image.Source = ImagesURI.GetCrosPath();
                CrossTurn = !CrossTurn;
            }
            else
            {
                image.Source = ImagesURI.GetToePath();
                CrossTurn = !CrossTurn;
            }
        }

        private void WriteStatus()
        {
            GameResult result = GridProcessing.GetWinner(MainMultiplayerGrid);

            if (GridProcessing.IsGridFilled(MainMultiplayerGrid))
            {
                WriteStatusWhenGridFilled(result);
                return;
            }

            if (result == GameResult.Draw)
            {
                MessageTextBlock.Text = WhosTurn();
            }
            else
            {
                WriteStatusBeforeGridFilling(result);
            }
        }

        private void WriteStatusWhenGridFilled(GameResult result)
        {
            if (result == GameResult.Draw)
            {
                MessageTextBlock.Text = "It's draw";
            }
            else if (result == GameResult.Cross)
            {
                MessageTextBlock.Text = "Crosses win";
            }
            else // result == GameResult.Toe
            {
                MessageTextBlock.Text = "Toes win";
            }
        }

        private void WriteStatusBeforeGridFilling(GameResult result)
        {
            if (result == GameResult.Cross)
            {
                MessageTextBlock.Text = "Crosses win";
            }
            else // result == GameResult.Toe
            {
                MessageTextBlock.Text = "Toes win";
            }
        }

        private string WhosTurn()
        {
            if (CrossTurn)
            {
                return "Cross move";
            }
            else
            {
                return "Toe move";
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

            AreYouSureWindow areYouSureWindow = new AreYouSureWindow();
            areYouSureWindow.Left = this.Left;
            areYouSureWindow.Top = this.Top;
            areYouSureWindow.Show();
        }
    }
}
