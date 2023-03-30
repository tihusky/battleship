namespace Battleship.Board;

internal class BoardRenderer
{
    private readonly string _rowLetters = "ABCDEFGHIJ";

    public void DisplayBoard(Board board)
    {
        CellState[,] cells = board.Cells;

        // Column header
        Console.WriteLine("   [1][2][3][4][5][6][7][8][9][10]");

        for (int row = 0; row < cells.GetLength(0); row++)
        {
            Console.Write($"[{_rowLetters[row]}]");

            for (int col = 0; col < cells.GetLength(1); col++)
            {
                (char symbol, ConsoleColor color) = cells[row, col] switch
                {
                    CellState.Hit => ('+', ConsoleColor.Red),
                    CellState.Miss => ('-', ConsoleColor.Gray),
                    _ => ('~', ConsoleColor.Blue)
                };

                Console.ForegroundColor = color;
                Console.Write($"[{symbol}]");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
}