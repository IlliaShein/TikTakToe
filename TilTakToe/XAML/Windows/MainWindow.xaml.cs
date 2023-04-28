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
            SetPathToCrossOrToe(image);

            WriteStatus();
        }

        private void SetPathToCrossOrToe(Image image)
        {
            if (CrossTurn)
            {
                image.Source = new BitmapImage(ImagesURI.GetCrosPath());
                CrossTurn = !CrossTurn;
            }
            else
            {
                image.Source = new BitmapImage(ImagesURI.GetToePath());
                CrossTurn = !CrossTurn;
            }
        }

        private void WriteStatus()
        {
            if (CellProcessing.IsGridFilled(MainGrid))
            {
                MessageTextBlock.Text = "Game end";
            }
            else
            {
                MessageTextBlock.Text = WhosTurn();
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
            Application.Current.Shutdown();
        }

        private void MinimizeButon_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.WindowState = WindowState.Minimized;
        }

        private void MenuBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
