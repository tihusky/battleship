using Battleship.Interfaces;

namespace Battleship.Board;

internal class RandomBoardGenerator : IBoardGenerator
{
    private Random _rng;

    public RandomBoardGenerator()
    {
        _rng = new Random();
    }

    public BattleshipBoard GenerateBoard()
    {
        BattleshipBoard board = new BattleshipBoard();

        PlaceDestroyer(board);
        PlaceSubmarine(board);
        PlaceCruiser(board);
        PlaceBattleship(board);
        PlaceCarrier(board);

        return board;
    }

    private void PlaceDestroyer(BattleshipBoard board)
    {
        while (true)
        {
            Ship ship = new Ship(ShipType.Destroyer, new List<Location> { GetRandomLocation() });

            if (board.AddShip(ship))
                return;
        }
    }

    private void PlaceSubmarine(BattleshipBoard board)
    {
        ShipOrientation orientation = GetRandomOrientation();

        while (true)
        {
            List<Location> shipCells = GetShipCells(orientation, 2);

            if (!shipCells.TrueForAll(BattleshipBoard.IsLocationValid))
                continue;

            if (board.AddShip(new Ship(ShipType.Submarine, shipCells)))
                return;
        }
    }

    private void PlaceCruiser(BattleshipBoard board)
    {
        ShipOrientation orientation = GetRandomOrientation();

        while (true)
        {
            List<Location> shipCells = GetShipCells(orientation, 3);

            if (!shipCells.TrueForAll(BattleshipBoard.IsLocationValid))
                continue;

            if (board.AddShip(new Ship(ShipType.Cruiser, shipCells)))
                return;
        }
    }

    private void PlaceBattleship(BattleshipBoard board)
    {
        ShipOrientation orientation = GetRandomOrientation();

        while (true)
        {
            List<Location> shipCells = GetShipCells(orientation, 4);

            if (!shipCells.TrueForAll(BattleshipBoard.IsLocationValid))
                continue;

            if (board.AddShip(new Ship(ShipType.Battleship, shipCells)))
                return;
        }
    }

    private void PlaceCarrier(BattleshipBoard board)
    {
        ShipOrientation orientation = GetRandomOrientation();

        while (true)
        {
            List<Location> shipCells = GetShipCells(orientation, 5);

            if (!shipCells.TrueForAll(BattleshipBoard.IsLocationValid))
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
        int row = _rng.Next(0, BattleshipBoard.NumRows);
        int col = _rng.Next(0, BattleshipBoard.NumColumns);

        return new Location { Row = row, Column = col };
    }

    private List<Location> GetShipCells(ShipOrientation orientation, int shipLength)
    {
        List<Location> shipCells = new List<Location> { GetRandomLocation() };
        int offset = 1;

        while (shipCells.Count < shipLength)
        {
            Location nextLocation;

            if (orientation == ShipOrientation.Horizontal)
                nextLocation = new Location { Row = shipCells[0].Row, Column = shipCells[0].Column + offset };
            else
                nextLocation = new Location { Row = shipCells[0].Row + offset, Column = shipCells[0].Column };

            shipCells.Add(nextLocation);
            offset++;
        }

        return shipCells;
    }
}

internal enum ShipOrientation
{
    Horizontal,
    Vertical
}