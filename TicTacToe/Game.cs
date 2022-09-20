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
    const int MaxRow = 3;
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

    public void AddTileAt(char symbol, int row, int column)
    {
        _plays.Single(tile => tile.Row == row && tile.Column == column).Player = symbol;
    }
}

public class Game
{
    private readonly Board _board = new();
    private char _lastSymbol = Board.EmptyPlayer;
    const string InvalidFirstPlayer = "Invalid first player";
    const string InvalidNextPlayer = "Invalid next player";
    const string InvalidPosition = "Invalid position";
    
    public void Play(char symbol, int row, int column)
    {
        if (IfFirstMove() && IsPlayerO(symbol))
        {
            throw new Exception(InvalidFirstPlayer);
        }

        if (IsSamePlayerAsLastMove(symbol))
        {
            throw new Exception(InvalidNextPlayer);
        }

        if (IsPositionOccupied(row, column))
        {
            throw new Exception(InvalidPosition);
        }

        UpdateGameState(symbol, row, column);
    }

    private void UpdateGameState(char symbol, int row, int column)
    {
        _lastSymbol = symbol;
        _board.AddTileAt(symbol, row, column);
    }

    private bool IsPositionOccupied(int row, int column)
    {
        return _board.TileAt(row, column).Player != Board.EmptyPlayer;
    }

    private bool IsSamePlayerAsLastMove(char symbol)
    {
        return symbol == _lastSymbol;
    }

    private bool IsPlayerO(char symbol)
    {
        return symbol == Board.PlayerO;
    }

    private bool IfFirstMove()
    {
        return _lastSymbol == Board.EmptyPlayer;
    }

    public char Winner()
    {
        if (IsFirstRowTaken() && IsFirstRowFullWithSamePlayer())
        {
            return _board.TileAt(Board.FirstRow, Board.FirstColumn).Player;
        }

        if (IsSecondRowTaken() && IsSecondRowFullWithSamePlayer())
        {
            return _board.TileAt(Board.SecondRow, Board.FirstColumn).Player;
        }

        if (IsThirdRowTaken() && IsThirdRowFullWithSamePlayer())
        {
            return _board.TileAt(Board.ThirdRow, Board.FirstColumn).Player;
        }

        return Board.EmptyPlayer;
    }

    private bool IsThirdRowFullWithSamePlayer()
    {
        return _board.TileAt(Board.ThirdRow, Board.FirstColumn).Player ==
               _board.TileAt(Board.ThirdRow, Board.SecondColumn).Player &&
               _board.TileAt(Board.ThirdRow, Board.ThirdColumn).Player ==
               _board.TileAt(Board.ThirdRow, Board.SecondColumn).Player;
    }

    private bool IsThirdRowTaken()
    {
        return _board.TileAt(Board.ThirdRow, Board.FirstColumn).Player != Board.EmptyPlayer &&
               _board.TileAt(Board.ThirdRow, Board.SecondColumn).Player != Board.EmptyPlayer &&
               _board.TileAt(Board.ThirdRow, Board.ThirdColumn).Player != Board.EmptyPlayer;
    }

    private bool IsSecondRowFullWithSamePlayer()
    {
        return _board.TileAt(Board.SecondRow, Board.FirstColumn).Player ==
               _board.TileAt(Board.SecondRow, Board.SecondColumn).Player &&
               _board.TileAt(Board.SecondRow, Board.ThirdColumn).Player ==
               _board.TileAt(Board.SecondRow, Board.SecondColumn).Player;
    }

    private bool IsSecondRowTaken()
    {
        return _board.TileAt(Board.SecondRow, Board.FirstColumn).Player != Board.EmptyPlayer &&
               _board.TileAt(Board.SecondRow, Board.SecondColumn).Player != Board.EmptyPlayer &&
               _board.TileAt(Board.SecondRow, Board.ThirdColumn).Player != Board.EmptyPlayer;
    }

    private bool IsFirstRowFullWithSamePlayer()
    {
        return _board.TileAt(Board.FirstRow, Board.FirstColumn).Player ==
               _board.TileAt(Board.FirstRow, Board.SecondColumn).Player &&
               _board.TileAt(Board.FirstRow, Board.ThirdColumn).Player ==
               _board.TileAt(Board.FirstRow, Board.SecondColumn).Player;
    }

    private bool IsFirstRowTaken()
    {
        return _board.TileAt(Board.FirstRow, Board.FirstColumn).Player != Board.EmptyPlayer &&
               _board.TileAt(Board.FirstRow, Board.SecondColumn).Player != Board.EmptyPlayer &&
               _board.TileAt(Board.FirstRow, Board.ThirdColumn).Player != Board.EmptyPlayer;
    }
}