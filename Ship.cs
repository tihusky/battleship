internal class Ship
{
    private List<Location> _cells;

    public ShipType Type { get; }

    // Returning a new List so the original can't be changed from the outside
    public List<Location> Cells => new List<Location>(_cells);

    public Ship(ShipType type, List<Location> cells)
    {
        _cells = cells;
        Type = type;
    }
}