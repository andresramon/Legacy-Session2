using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe;

public class Board
{
    private readonly List<Tile> _plays = new();
    private const int MaxRow = 3;
    const int MaxColumn = 3;
    public const char EmptyPlayer = ' ';
    public const char PlayerO = 'O';
    private const int FirstRow = 0;
    private const int FirstColumn = 0;
    private const int SecondColumn = 1;
    private const int ThirdColumn = 2;
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

    private Tile TileAt(int row, int column)
    {
        return _plays.Single(tile => tile.Row == row && tile.Column == column);
    }

    public void AddTileAt(char player, int row, int column)
    {
        _plays.Single(tile => tile.Row == row && tile.Column == column).Player = player;
    }

    private bool IsPositionOccupied(int row, int column)
    {
        return TileAt(row, column).Player != EmptyPlayer;
    }

    public void ValidateFreePosition(int row, int column)
    {
        if (IsPositionOccupied(row, column))
        {
            throw new Exception(InvalidPosition);
        }
    }

    private bool IsRowFullWithSamePlayer(int row)
    {
        return TileAt(row, FirstColumn).Player ==
               TileAt(row, SecondColumn).Player &&
               TileAt(row, ThirdColumn).Player ==
               TileAt(row, SecondColumn).Player;
    }

    private bool IsRowTaken(int row)
    {
        return TileAt(row, FirstColumn).Player != EmptyPlayer &&
               TileAt(row, SecondColumn).Player != EmptyPlayer &&
               TileAt(row, ThirdColumn).Player != EmptyPlayer;
    }

    private bool IsWinnerRow(int row)
    {
        return IsRowTaken(row) && IsRowFullWithSamePlayer(row);
    }

    public char GetWinner()
    {
        for (int row = FirstRow; row <= MaxRow; row++)
        {
            if (IsWinnerRow(row))
            {
                return TileAt(row, FirstColumn).Player;
            }
        }

        return EmptyPlayer;
    }
}