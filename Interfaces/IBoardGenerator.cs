using Battleship.Board;

namespace Battleship.Interfaces;

internal interface IBoardGenerator
{
    BattleshipBoard GenerateBoard();
}