internal class Board
{
    private const int _numRows = 10;
    private const int _numCols = 10;
    private readonly CellState[,] _cells;
    private readonly List<Ship> _ships;

    // Need to use type casting here because the Clone method returns an object instance
    public CellState[,] Cells => (CellState[,])_cells.Clone();

    public Board()
    {
        _cells = new CellState[_numRows, _numCols];
        _ships = new List<Ship>();

        for (int row = 0; row < _numRows; row++)
            for (int col = 0; col < _numCols; col++)
                _cells[row, col] = CellState.NotTargeted;
    }

    public bool AddShip(Ship newShip)
    {
        foreach (Location loc in newShip.Cells)
        {
            if (!Board.IsLocationValid(loc))
                throw new ArgumentOutOfRangeException();

            // Check if one of the existing ships occupies the same location
            foreach (Ship ship in _ships)
                if (ship.Cells.Contains(loc))
                    return false;
        }

        _ships.Add(newShip);

        return true;
    }

    public bool ResolveShot(Location location)
    {
        if (!IsLocationValid(location))
            throw new ArgumentOutOfRangeException();

        foreach (Ship ship in _ships)
        {
            if (ship.Cells.Contains(location))
            {
                _cells[location.Row, location.Column] = CellState.Hit;

                return true;
            }
        }

        _cells[location.Row, location.Column] = CellState.Miss;

        return false;
    }

    public static bool IsLocationValid(Location location)
    {
        bool rowInBounds = location.Row >= 0 && location.Row < _numRows;
        bool colInBounds = location.Column >= 0 && location.Column < _numCols;

        return rowInBounds && colInBounds;
    }
}