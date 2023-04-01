using Battleship.Board;

internal class Player
{
    public string Name { get; }
    public BattleshipBoard? Board { get; private set; }

    public Player(string name)
    {
        Name = name;
    }

    public void SetBoard(BattleshipBoard board)
    {
        if (Board == null && board != null)
            Board = board;
    }
}