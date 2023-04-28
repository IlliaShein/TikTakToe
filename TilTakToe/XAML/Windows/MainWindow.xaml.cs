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
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                foreach (var child in MainGrid.Children)
                {
                    if (child is Image img && Grid.GetRow(img) == Grid.GetRow(border) && Grid.GetColumn(img) == Grid.GetColumn(border) && img.Source == null)
                    {
                        border.Background = TTTColors.GetCursorAboceCellColor();
                    }
                }
            }
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = TTTColors.GetNeutralCellColor();
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border)
            {
                foreach (var child in MainGrid.Children)
                {
                    if (child is Image img && Grid.GetRow(img) == Grid.GetRow(border) && Grid.GetColumn(img) == Grid.GetColumn(border) && img.Source == null)
                    {
                        border.Background = TTTColors.GetCellWhileClickingColor();

                        if (CrossTurn)
                        {
                            img.Source = new BitmapImage(ImagesURI.GetCrosPath());
                            CrossTurn = !CrossTurn;
                        }
                        else
                        {
                            img.Source = new BitmapImage(ImagesURI.GetToePath());
                            CrossTurn = !CrossTurn;
                        }
                        break;
                    }
                }
            }
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = TTTColors.GetCursorAboceCellColor();
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
