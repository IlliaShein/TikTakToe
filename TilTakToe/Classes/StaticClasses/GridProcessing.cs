using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TilTakToe.Classes.StaticClasses
{
    static public class GridProcessing
    {
        static public GameResult GetWinner(Grid grid)
        {
            int[,] field = GetGameFieldAsArray(grid);

            for (int i = 0; i < field.GetLength(0); i++)
            {
                if(CheckRow(field,i) != GameResult.Draw)
                {
                    return CheckRow(field, i);
                }
                if (CheckColumn(field, i) != GameResult.Draw)
                {
                    return CheckColumn(field, i);
                }
            }

            return CheckDiagonals(field);
        }

        static private int[,] GetGameFieldAsArray(Grid grid)
        {
            int[,] field = new int[3, 3];

            for (int row = 2; row < grid.RowDefinitions.Count; row++)
            {
                for (int col = 0; col < grid.ColumnDefinitions.Count; col++)
                {
                    UIElement element = grid.Children
                       .Cast<UIElement>()
                       .FirstOrDefault(e => e is Image && Grid.GetRow(e) == row && Grid.GetColumn(e) == col);

                    FillCell(element, field, row, col);
                }
            }

            return field;
        }

        static private void FillCell(UIElement element , int[,] field, int row, int col)
        {
            if (((Image)element).Source == null)
            {
                return;
            }

            if (((Image)element).Source.ToString() == ImagesURI.GetCrosPath().ToString())
            {
                field[row - 2, col] = 1;
            }
            else if (((Image)element).Source.ToString() == ImagesURI.GetToePath().ToString())
            {
                field[row - 2, col] = 2;
            }
        }

        static private GameResult CheckRow(int[,] field , int row)
        {
            int crosses = 0;
            int toes = 0;

            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[row, j] == 1)
                {
                    crosses++;
                }
                else if (field[row, j] == 2)
                {
                    toes++;
                }
            }

            return GetResult(crosses, toes);
        }

        static private GameResult CheckColumn(int[,] field, int col)
        {
            int crosses = 0;
            int toes = 0;

            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[j, col] == 1)
                {
                    crosses++;
                }
                else if (field[j, col] == 2)
                {
                    toes++;
                }
            }

            return GetResult(crosses, toes);
        }

        static private GameResult GetResult(int crosses, int toes)
        {
            if (crosses == 3)
            {
                return GameResult.Cross;
            }
            else if (toes == 3)
            {
                return GameResult.Toe;
            }
            else
            {
                return GameResult.Draw;
            }
        }

        static private GameResult CheckDiagonals(int[,] field)
        {
            if (field[0, 0] == 1 && field[1, 1] == 1 && field[2, 2] == 1)
            {
                return GameResult.Cross;
            }
            if (field[0, 0] == 2 && field[1, 1] == 2 && field[2, 2] == 2)
            {
                return GameResult.Toe;
            }

            if (field[2, 0] == 1 && field[1, 1] == 1 && field[0, 2] == 1)
            {
                return GameResult.Cross;
            }
            if (field[2, 0] == 2 && field[1, 1] == 2 && field[0, 2] == 2)
            {
                return GameResult.Toe;
            }

            return GameResult.Draw;
        }

        static public bool IsGridFilled(Grid grid)
        {
            int images = 0;

            foreach (var child in grid.Children)
            {
                if (child is Image img && img.Source != null)
                {
                    images++;
                }
            }

            if (images == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
