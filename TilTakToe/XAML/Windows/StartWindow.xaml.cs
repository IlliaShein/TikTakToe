using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TilTakToe.Classes.StaticClasses;
using TilTakToe.XAML.Windows;

namespace TilTakToe
{
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            GlobalVariebles.CrossTurn = true;
            InitializeComponent();
            MessageTextBlock.Text = WhosTurn();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            if(CellProcessing.IscellEmpty(MainGrid,(Border)sender))
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
            if (CellProcessing.IscellEmpty(MainGrid, (Border)sender))
            {
                ((Border)sender).Background = TTTColors.CellWhileClickingColor;
            }
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!CellProcessing.IscellEmpty(MainGrid, (Border)sender))
            {
                return;
            }

            ((Border)sender).Background = TTTColors.NeutralCellColor;

            Image image = CellProcessing.GetCellImage(MainGrid, (Border)sender);
            GameLogic.SetPathToCrossOrToeImage(image);

            WriteStatus();
        }

        private void WriteStatus()
        {
            GameResult result = GridProcessing.GetWinner(MainGrid);

            if (GridProcessing.IsGridFilled(MainGrid))
            {
                WriteStatusWhenGridFilled(result);
                return;
            }
            
            if(result == GameResult.Draw)
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
            if (GlobalVariebles.CrossTurn)
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
            GeneralMethods.MinimizeWindow(startWindow);
        }

        private void MenuBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMethods.HoldAndMoveWindow(startWindow);
        }

        private void MultiplayerButton_Click(object sender, RoutedEventArgs e)
        {
            MultiplayerWindow multiplayerMenu = new MultiplayerWindow();
            multiplayerMenu.Left = this.Left;
            multiplayerMenu.Top = this.Top;
            multiplayerMenu.Show();

            this.Close();
        }
    }
}
