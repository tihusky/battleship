internal class Board
{
    private const int _numRows = 10;
    private const int _numCols = 10;
    private readonly CellState[,] _cells;

    public Board()
    {
        _cells = new CellState[_numRows, _numCols];

        for (int row = 0; row < _numRows; row++)
            for (int col = 0; col < _numCols; col++)
                _cells[row, col] = CellState.NotTargeted;
    }

    public static bool IsLocationValid(Location location)
    {
        bool rowInBounds = location.Row >= 0 && location.Row < _numRows;
        bool colInBounds = location.Column >= 0 && location.Column < _numCols;

        return rowInBounds && colInBounds;
    }
}