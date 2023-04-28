using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
                        border.Background = new SolidColorBrush(Color.FromArgb(0x54, 0xFF, 0xFF, 0x00));
                    }
                }
            }
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = Brushes.White;
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border)
            {
                string toePath = @"C:\Users\Illy\source\repos\TilTakToe\Images\toe.png";
                string crossPath = @"C:\Users\Illy\source\repos\TilTakToe\Images\cross.png";
                foreach (var child in MainGrid.Children)
                {
                    if (child is Image img && Grid.GetRow(img) == Grid.GetRow(border) && Grid.GetColumn(img) == Grid.GetColumn(border) && img.Source == null)
                    {
                        border.Background = new SolidColorBrush(Color.FromArgb(0x84, 0xFF, 0xFF, 0x00));

                        if (CrossTurn)
                        {
                            img.Source = new BitmapImage(new Uri(crossPath));
                            CrossTurn = !CrossTurn;
                        }
                        else
                        {
                            img.Source = new BitmapImage(new Uri(toePath));
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
                border.Background = new SolidColorBrush(Color.FromArgb(0x54, 0xFF, 0xFF, 0x00));
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
