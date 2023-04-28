using System;

namespace TilTakToe.Classes.StaticClasses
{
    public static class ImagesURI
    {
        static public Uri GetToePath()
        {
            return new Uri(@"C:\Users\Illy\source\repos\TilTakToe\Images\toe.png");
        }
        static public Uri GetCrosPath()
        {
            return new Uri(@"C:\Users\Illy\source\repos\TilTakToe\Images\cross.png");
        }
    }
}
