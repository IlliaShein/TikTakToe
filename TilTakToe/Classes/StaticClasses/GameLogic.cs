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
    }
}
