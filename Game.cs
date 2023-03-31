using Battleship.UI;
using Battleship.Board;

namespace Battleship;

internal class Game
{
    private Board.Board _board;
    private BoardRenderer _renderer;

    public Game()
    {
        _board = new Board.Board();
        _renderer = new BoardRenderer();
    }

    public void Run()
    {
        _renderer.DisplayBoard(_board);
    }
}