using System;
using System.Windows.Media.Imaging;

namespace TilTakToe.Classes.StaticClasses
{
    public static class ImagesURI
    {
        public static BitmapImage ToePath { get; } = new BitmapImage(new Uri(@"C:\Users\Illy\source\repos\TilTakToe\Images\toe.png"));
        public static BitmapImage CrosPath { get; } = new BitmapImage(new Uri(@"C:\Users\Illy\source\repos\TilTakToe\Images\cross.png"));
    }
}
