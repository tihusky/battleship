Board board = new Board();
BoardRenderer renderer = new BoardRenderer();

while (true)
{
    Console.Clear();
    renderer.DisplayBoard(board);

    Console.Write("Enter location: ");
    Location loc = Location.FromString(Console.ReadLine());

    if (Board.IsLocationValid(loc))
    {
        if (board.ResolveShot(loc))
            Console.WriteLine("You hit something!");
        else
            Console.WriteLine("You missed!");
    }
    else
    {
        Console.WriteLine("Not a valid location.");
    }
}