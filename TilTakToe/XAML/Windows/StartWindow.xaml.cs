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
            GameVariebles.CrossTurn = true;
            InitializeComponent();
            MessageTextBlock.Text = GameLogic.WhosTurn();
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

            GameLogic.WriteStatus(MainGrid,MessageTextBlock);
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
            WindowsChanging.ChangeWindow(this, new MultiplayerWindow());
        }
    }
}
