internal class RandomBoardGenerator : IBoardGenerator
{
    private Random _rng;

    public RandomBoardGenerator()
    {
        _rng = new Random();
    }

    public Board GenerateBoard()
    {
        Board board = new Board();

        PlaceDestroyer(board);
        PlaceSubmarine(board);
        PlaceCruiser(board);
        PlaceBattleship(board);
        PlaceCarrier(board);

        return board;
    }

    private void PlaceDestroyer(Board board)
    {
        while (true)
        {
            Ship ship = new Ship(ShipType.Destroyer, new List<Location> { GetRandomLocation() });

            if (board.AddShip(ship))
                return;
        }
    }

    private void PlaceSubmarine(Board board)
    {
        ShipOrientation orientation = GetRandomOrientation();

        while (true)
        {
            List<Location> shipCells = new List<Location> { GetRandomLocation() };

            if (orientation == ShipOrientation.Horizontal)
            {
                shipCells.Add(new Location { Row = shipCells[0].Row, Column = shipCells[0].Column + 1 });
            }
            else
            {
                shipCells.Add(new Location { Row = shipCells[0].Row + 1, Column = shipCells[0].Column });
            }

            bool allLocationsValid = shipCells.TrueForAll(Board.IsLocationValid);

            if (!allLocationsValid)
                continue;

            if (board.AddShip(new Ship(ShipType.Submarine, shipCells)))
                return;
        }
    }

    private void PlaceCruiser(Board board)
    {
        ShipOrientation orientation = GetRandomOrientation();

        while (true)
        {
            List<Location> shipCells = new List<Location> { GetRandomLocation() };

            if (orientation == ShipOrientation.Horizontal)
            {
                shipCells.Add(new Location { Row = shipCells[0].Row, Column = shipCells[0].Column + 1 });
                shipCells.Add(new Location { Row = shipCells[0].Row, Column = shipCells[0].Column + 2 });
            }
            else
            {
                shipCells.Add(new Location { Row = shipCells[0].Row + 1, Column = shipCells[0].Column });
                shipCells.Add(new Location { Row = shipCells[0].Row + 2, Column = shipCells[0].Column });
            }

            bool allLocationsValid = shipCells.TrueForAll(Board.IsLocationValid);

            if (!allLocationsValid)
                continue;

            if (board.AddShip(new Ship(ShipType.Cruiser, shipCells)))
                return;
        }
    }

    private void PlaceBattleship(Board board)
    {
        ShipOrientation orientation = GetRandomOrientation();

        while (true)
        {
            List<Location> shipCells = new List<Location> { GetRandomLocation() };

            if (orientation == ShipOrientation.Horizontal)
            {
                shipCells.Add(new Location { Row = shipCells[0].Row, Column = shipCells[0].Column + 1 });
                shipCells.Add(new Location { Row = shipCells[0].Row, Column = shipCells[0].Column + 2 });
                shipCells.Add(new Location { Row = shipCells[0].Row, Column = shipCells[0].Column + 3 });
            }
            else
            {
                shipCells.Add(new Location { Row = shipCells[0].Row + 1, Column = shipCells[0].Column });
                shipCells.Add(new Location { Row = shipCells[0].Row + 2, Column = shipCells[0].Column });
                shipCells.Add(new Location { Row = shipCells[0].Row + 3, Column = shipCells[0].Column });
            }

            if (!shipCells.TrueForAll(Board.IsLocationValid))
                continue;

            if (board.AddShip(new Ship(ShipType.Battleship, shipCells)))
                return;
        }
    }

    private void PlaceCarrier(Board board)
    {
        ShipOrientation orientation = GetRandomOrientation();

        while (true)
        {
            List<Location> shipCells = new List<Location> { GetRandomLocation() };

            if (orientation == ShipOrientation.Horizontal)
            {
                shipCells.Add(new Location { Row = shipCells[0].Row, Column = shipCells[0].Column + 1 });
                shipCells.Add(new Location { Row = shipCells[0].Row, Column = shipCells[0].Column + 2 });
                shipCells.Add(new Location { Row = shipCells[0].Row, Column = shipCells[0].Column + 3 });
                shipCells.Add(new Location { Row = shipCells[0].Row, Column = shipCells[0].Column + 4 });
            }
            else
            {
                shipCells.Add(new Location { Row = shipCells[0].Row + 1, Column = shipCells[0].Column });
                shipCells.Add(new Location { Row = shipCells[0].Row + 2, Column = shipCells[0].Column });
                shipCells.Add(new Location { Row = shipCells[0].Row + 3, Column = shipCells[0].Column });
                shipCells.Add(new Location { Row = shipCells[0].Row + 4, Column = shipCells[0].Column });
            }

            if (!shipCells.TrueForAll(Board.IsLocationValid))
                continue;

            if (board.AddShip(new Ship(ShipType.Carrier, shipCells)))
                return;
        }
    }

    private ShipOrientation GetRandomOrientation()
    {
        return _rng.Next(2) switch
        {
            0 => ShipOrientation.Horizontal,
            _ => ShipOrientation.Vertical
        };
    }

    private Location GetRandomLocation()
    {
        int row = _rng.Next(0, Board.NumRows);
        int col = _rng.Next(0, Board.NumColumns);

        return new Location { Row = row, Column = col };
    }
}

internal enum ShipOrientation
{
    Horizontal,
    Vertical
}