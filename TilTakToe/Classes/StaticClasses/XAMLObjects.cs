using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TilTakToe.Classes.StaticClasses.Web;
using TilTakToe.XAML.Windows;

namespace TilTakToe.Classes.StaticClasses
{
    public static class XAMLObjects
    {
        public static Button GetServerConnectionButton(Style style)
        {
            Button connectToServerButton = new Button();
            connectToServerButton.Name = "ConnectToServerButton";
            connectToServerButton.Content = "+";
            connectToServerButton.Style = style;
            connectToServerButton.FontSize = 16;
            connectToServerButton.Height = 50;
            connectToServerButton.Width = 50;
            connectToServerButton.FontFamily = new FontFamily("Consolas");
            connectToServerButton.Margin = new Thickness(6);

            return connectToServerButton;
        }
    }
}
