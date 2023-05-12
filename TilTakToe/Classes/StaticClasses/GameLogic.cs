using System.Windows.Controls;

namespace TilTakToe.Classes.StaticClasses
{
    public static class GameLogic
    {
        public static void SetPathToCrossOrToeImage(Image image)
        {
            if (GlobalVariebles.CrossTurn)
            {
                image.Source = ImagesURI.CrosPath;
                GlobalVariebles.CrossTurn = !GlobalVariebles.CrossTurn;
            }
            else
            {
                image.Source = ImagesURI.ToePath;
                GlobalVariebles.CrossTurn = !GlobalVariebles.CrossTurn;
            }
        }

        public static void WriteStatus(Grid grid , TextBlock textBlock)
        {
            GameResult result = GridProcessing.GetWinner(grid);

            if (GridProcessing.IsGridFilled(grid))
            {
                WriteStatusWhenGridFilled(textBlock, result);
                return;
            }

            if (result == GameResult.Draw)
            {
                textBlock.Text = WhosTurn();
            }
            else
            {
                WriteStatusBeforeGridFilling(textBlock, result);
            }
        }

        private static void WriteStatusWhenGridFilled(TextBlock textBlock, GameResult result)
        {
            if (result == GameResult.Draw)
            {
                textBlock.Text = "It's draw";
            }
            else if (result == GameResult.Cross)
            {
                textBlock.Text = "Crosses win";
            }
            else // result == GameResult.Toe
            {
                textBlock.Text = "Toes win";
            }
        }

        private static void WriteStatusBeforeGridFilling(TextBlock textBlock, GameResult result)
        {
            if (result == GameResult.Cross)
            {
                textBlock.Text = "Crosses win";
            }
            else // result == GameResult.Toe
            {
                textBlock.Text = "Toes win";
            }
        }

        public static string WhosTurn()
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
    }
}
