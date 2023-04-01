using Battleship.UI;
using Battleship.Board;
using Battleship.Interfaces;

namespace Battleship;

internal class Game
{
    private BoardRenderer _renderer;

    private Player _playerOne;
    private Player _playerTwo;
    private Player _activePlayer;
    private Player _opponent;

    public Game()
    {
        IBoardGenerator boardGenerator = new RandomBoardGenerator();

        _playerOne = new Player("Player One");
        _playerOne.SetBoard(boardGenerator.GenerateBoard());
        _playerTwo = new Player("Player Two");
        _playerTwo.SetBoard(boardGenerator.GenerateBoard());
        _activePlayer = _playerOne;
        _opponent = _playerTwo;

        _renderer = new BoardRenderer();
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            ConsoleHelper.WriteLine($"{_activePlayer.Name}, it is your turn.");
            _renderer.DisplayBoard(_opponent.Board!);
            Location target = GetTargetFromPlayer();

            ShotResult result = _opponent.Board!.ResolveShot(target);

            if (result.IsHit)
            {
                ConsoleHelper.WriteLine($"Good job, you hit a {result.ShipType}!", ConsoleColor.Green);

                if (_opponent.Board!.AllShipsSunk())
                {
                    ConsoleHelper.WriteLine($"All of {_opponent.Name}'s ships were sunk. {_activePlayer.Name} won the game!", ConsoleColor.Yellow);
                    break;
                }
            }
            else
            {
                ConsoleHelper.WriteLine("You missed!", ConsoleColor.Red);
            }

            ConsoleHelper.WriteLine("Press any key to continue...");
            Console.ReadKey();

            _activePlayer = (_activePlayer == _playerOne) ? _playerTwo : _playerOne;
            _opponent = (_activePlayer == _playerOne) ? _playerTwo : _playerOne;
        }
    }

    public Location GetTargetFromPlayer()
    {
        Location target = new Location { Row = Int32.MaxValue, Column = Int32.MaxValue };

        while (!BattleshipBoard.IsLocationValid(target))
        {
            ConsoleHelper.Write("Enter target: ");
            string? input = ConsoleHelper.GetUppercasedString();

            if (!String.IsNullOrEmpty(input))
                target = Location.FromString(input);
        }

        return target;
    }
}