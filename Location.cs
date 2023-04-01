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

        int column;
        bool couldBeParsed = Int32.TryParse(location.Substring(1), out column);

        if (!couldBeParsed)
            column = Int32.MaxValue;

        return new Location { Row = row, Column = column };
    }
}