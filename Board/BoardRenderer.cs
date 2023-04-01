using Battleship.UI;

namespace Battleship.Board;

internal class BoardRenderer
{
    private readonly string _rowLetters = "ABCDEFGHIJ";

    public void DisplayBoard(BattleshipBoard board)
    {
        CellState[,] cells = board.Cells;

        // Column header
        ConsoleHelper.WriteLine("\n   [1][2][3][4][5][6][7][8][9][10]", ConsoleColor.DarkYellow);

        for (int row = 0; row < cells.GetLength(0); row++)
        {
            ConsoleHelper.Write($"[{_rowLetters[row]}]", ConsoleColor.DarkYellow);

            for (int col = 0; col < cells.GetLength(1); col++)
            {
                (char symbol, ConsoleColor color) = cells[row, col] switch
                {
                    CellState.Hit => ('+', ConsoleColor.Red),
                    CellState.Miss => ('-', ConsoleColor.Gray),
                    _ => ('~', ConsoleColor.Blue)
                };

                ConsoleHelper.Write($"[{symbol}]", color);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}