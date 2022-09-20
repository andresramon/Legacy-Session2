using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe;

public class Tile
{
    public int Row { get; init; }
    public int Column { get; init; }
    public char Player { get; set; }
}

public class Board
{
    private readonly List<Tile> _plays = new();
    public const int MaxRow = 3;
    const int MaxColumn = 3;
    public const char EmptyPlayer = ' ';
    public const char PlayerO = 'O';
    public const int FirstRow = 0;
    public const int FirstColumn = 0;
    public const int SecondRow = 1;
    public const int ThirdRow = 2;
    public const int SecondColumn = 1;
    public const int ThirdColumn = 2;
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
}

public class Game
{
    private readonly Board _board = new();
    private char _lastPlayer = Board.EmptyPlayer;
    const string InvalidFirstPlayer = "Invalid first player";
    const string InvalidNextPlayer = "Invalid next player";
    const string InvalidPosition = "Invalid position";
    
    public void Play(char player, int row, int column)
    {
        ValidatePlay(player, row, column);

        UpdateGameState(player, row, column);
    }

    private void ValidatePlay(char player, int row, int column)
    {
        ValidateFirstPlayer(player);

        ValidatePlayerChanges(player);

        ValidateFreePosition(row, column);
    }

    private void ValidateFreePosition(int row, int column)
    {
        if (IsPositionOccupied(row, column))
        {
            throw new Exception(InvalidPosition);
        }
    }

    private void ValidatePlayerChanges(char player)
    {
        if (IsSamePlayerAsLastMove(player))
        {
            throw new Exception(InvalidNextPlayer);
        }
    }

    private void ValidateFirstPlayer(char player)
    {
        if (IfFirstMove() && IsPlayerO(player))
        {
            throw new Exception(InvalidFirstPlayer);
        }
    }

    private void UpdateGameState(char player, int row, int column)
    {
        _lastPlayer = player;
        _board.AddTileAt(player, row, column);
    }

    private bool IsPositionOccupied(int row, int column)
    {
        return _board.TileAt(row, column).Player != Board.EmptyPlayer;
    }

    private bool IsSamePlayerAsLastMove(char player)
    {
        return player == _lastPlayer;
    }

    private bool IsPlayerO(char player)
    {
        return player == Board.PlayerO;
    }

    private bool IfFirstMove()
    {
        return _lastPlayer == Board.EmptyPlayer;
    }

    public char Winner()
    {
        for (int row = Board.FirstRow; row <= Board.MaxRow; row++)
        {
            if (IsRowTaken(row) && IsRowFullWithSamePlayer(row))
            {
                return _board.TileAt(row, Board.FirstColumn).Player;
            }
        }
        return Board.EmptyPlayer;
    }

    private bool IsRowFullWithSamePlayer(int row)
    {
        return _board.TileAt(row, Board.FirstColumn).Player ==
               _board.TileAt(row, Board.SecondColumn).Player &&
               _board.TileAt(row, Board.ThirdColumn).Player ==
               _board.TileAt(row, Board.SecondColumn).Player;
    }

    private bool IsRowTaken(int row)
    {
        return _board.TileAt(row, Board.FirstColumn).Player != Board.EmptyPlayer &&
               _board.TileAt(row, Board.SecondColumn).Player != Board.EmptyPlayer &&
               _board.TileAt(row, Board.ThirdColumn).Player != Board.EmptyPlayer;
    }
}