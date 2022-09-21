using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe;

public class Board
{
    private readonly List<Tile> _plays = new();
    public const int MaxRow = 3;
    const int MaxColumn = 3;
    public const char EmptyPlayer = ' ';
    public const char PlayerO = 'O';
    public const int FirstRow = 0;
    public const int FirstColumn = 0;
    public const int SecondColumn = 1;
    public const int ThirdColumn = 2;
    const string InvalidPosition = "Invalid position";
    public Board()
    {
        for (var row = FirstRow; row < MaxRow; row++)
        {
            for (var column = FirstColumn; column < MaxColumn; column++)
            {
                _plays.Add(new Tile { Row = row, Column = column, Player = EmptyPlayer });
            }
        }
    }

    public Tile TileAt(int row, int column)
    {
        return _plays.Single(tile => tile.Row == row && tile.Column == column);
    }

    public void AddTileAt(char player, int row, int column)
    {
        _plays.Single(tile => tile.Row == row && tile.Column == column).Player = player;
    }

    public bool IsPositionOccupied(int row, int column)
    {
        return this.TileAt(row, column).Player != Board.EmptyPlayer;
    }

    public void ValidateFreePosition(int row, int column)
    {
        if (this.IsPositionOccupied(row, column))
        {
            throw new Exception(InvalidPosition);
        }
    }

    public bool IsRowFullWithSamePlayer(int row)
    {
        return this.TileAt(row, Board.FirstColumn).Player ==
               this.TileAt(row, Board.SecondColumn).Player &&
               this.TileAt(row, Board.ThirdColumn).Player ==
               this.TileAt(row, Board.SecondColumn).Player;
    }

    public bool IsRowTaken(int row)
    {
        return this.TileAt(row, Board.FirstColumn).Player != Board.EmptyPlayer &&
               this.TileAt(row, Board.SecondColumn).Player != Board.EmptyPlayer &&
               this.TileAt(row, Board.ThirdColumn).Player != Board.EmptyPlayer;
    }
}