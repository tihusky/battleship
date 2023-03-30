namespace Battleship;

internal struct Location
{
    public int Row { get; init; }
    public int Column { get; init; }

    public static Location FromString(string location)
    {
        int row = location[0] switch
        {
            'A' => 0,
            'B' => 1,
            'C' => 2,
            'D' => 3,
            'E' => 4,
            'F' => 5,
            'G' => 6,
            'H' => 7,
            'I' => 8,
            'J' => 9,
            _ => Int32.MaxValue
        };

        // Make the location zero-based (e.g. "A1" would be (0, 0))
        int col = Convert.ToInt32(location.Substring(1)) - 1;

        return new Location { Row = row, Column = col };
    }
}