using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TilTakToe.Classes.StaticClasses;

namespace TilTakToe
{
    public partial class MainWindow : Window
    {
        public bool CrossTurn { get; set; }

        public MainWindow()
        {
            CrossTurn = true;
            InitializeComponent();
            MessageTextBlock.Text = WhosTurn();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            if(CellProcessing.IscellEmpty(MainGrid,(Border)sender))
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
            if (CellProcessing.IscellEmpty(MainGrid, (Border)sender))
            {
                ((Border)sender).Background = TTTColors.GetCellWhileClickingColor();
            }
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!CellProcessing.IscellEmpty(MainGrid, (Border)sender))
            {
                return;
            }

            ((Border)sender).Background = TTTColors.GetNeutralCellColor();

            Image image = CellProcessing.GetCellImage(MainGrid, (Border)sender);
            SetPathToCrossOrToeImage(image);

            WriteStatus();
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
            GeneralMethods.MinimizeWindow(StartWindow);
        }

        private void MenuBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMethods.HoldAndMoveWindow(StartWindow);
        }
    }
}
