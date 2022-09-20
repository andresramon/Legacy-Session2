using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe;

public class Tile
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Symbol { get; set; }
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
        for (var row = 0; row < MaxRow; row++)
        {
            for (var column = 0; column < MaxColumn; column++)
            {
                _plays.Add(new Tile { X = row, Y = column, Symbol = EmptyPlayer });
            }
        }
    }

    public Tile TileAt(int x, int y)
    {
        return _plays.Single(tile => tile.X == x && tile.Y == y);
    }

    public void AddTileAt(char symbol, int x, int y)
    {
        _plays.Single(tile => tile.X == x && tile.Y == y).Symbol = symbol;
    }
}

public class Game
{
    private readonly Board _board = new();
    private char _lastSymbol = Board.EmptyPlayer;
    const string InvalidFirstPlayer = "Invalid first player";
    const string InvalidNextPlayer = "Invalid next player";
    const string InvalidPosition = "Invalid position";
    
    public void Play(char symbol, int x, int y)
    {
        if (IfFirstMove() && IsPlayerO(symbol))
        {
            throw new Exception(InvalidFirstPlayer);
        }

        if (IsSamePlayerAsLastMove(symbol))
        {
            throw new Exception(InvalidNextPlayer);
        }

        if (IsPositionOcuppied(x, y))
        {
            throw new Exception(InvalidPosition);
        }

        UpdateGameState(symbol, x, y);
    }

    private void UpdateGameState(char symbol, int x, int y)
    {
        _lastSymbol = symbol;
        _board.AddTileAt(symbol, x, y);
    }

    private bool IsPositionOcuppied(int x, int y)
    {
        return _board.TileAt(x, y).Symbol != Board.EmptyPlayer;
    }

    private bool IsSamePlayerAsLastMove(char symbol)
    {
        return symbol == _lastSymbol;
    }

    private static bool IsPlayerO(char symbol)
    {
        return symbol == Board.PlayerO;
    }

    private bool IfFirstMove()
    {
        return _lastSymbol == Board.EmptyPlayer;
    }

    public char Winner()
    {
        if (IsFirstRowTaken())
            if (IsFirstRowFullWithSamePlayer())
            {
                return _board.TileAt(Board.FirstRow, Board.FirstColumn).Symbol;
            }

        if (IsSecondRowTaken())
            if (IsSecondRowFullWithSamePlayer())
            {
                return _board.TileAt(Board.SecondRow, Board.FirstColumn).Symbol;
            }

        if (IsThirdRowTaken())
            if (IsThirdRowFullWithSamePlayer())
            {
                return _board.TileAt(Board.ThirdRow, Board.FirstColumn).Symbol;
            }

        return Board.EmptyPlayer;
    }

    private bool IsThirdRowFullWithSamePlayer()
    {
        return _board.TileAt(Board.ThirdRow, Board.FirstColumn).Symbol ==
               _board.TileAt(Board.ThirdRow, Board.SecondColumn).Symbol &&
               _board.TileAt(Board.ThirdRow, Board.ThirdColumn).Symbol ==
               _board.TileAt(Board.ThirdRow, Board.SecondColumn).Symbol;
    }

    private bool IsThirdRowTaken()
    {
        return _board.TileAt(Board.ThirdRow, Board.FirstColumn).Symbol != Board.EmptyPlayer &&
               _board.TileAt(Board.ThirdRow, Board.SecondColumn).Symbol != Board.EmptyPlayer &&
               _board.TileAt(Board.ThirdRow, Board.ThirdColumn).Symbol != Board.EmptyPlayer;
    }

    private bool IsSecondRowFullWithSamePlayer()
    {
        return _board.TileAt(Board.SecondRow, Board.FirstColumn).Symbol ==
               _board.TileAt(Board.SecondRow, Board.SecondColumn).Symbol &&
               _board.TileAt(Board.SecondRow, Board.ThirdColumn).Symbol ==
               _board.TileAt(Board.SecondRow, Board.SecondColumn).Symbol;
    }

    private bool IsSecondRowTaken()
    {
        return _board.TileAt(Board.SecondRow, Board.FirstColumn).Symbol != Board.EmptyPlayer &&
               _board.TileAt(Board.SecondRow, Board.SecondColumn).Symbol != Board.EmptyPlayer &&
               _board.TileAt(Board.SecondRow, Board.ThirdColumn).Symbol != Board.EmptyPlayer;
    }

    private bool IsFirstRowFullWithSamePlayer()
    {
        return _board.TileAt(Board.FirstRow, Board.FirstColumn).Symbol ==
               _board.TileAt(Board.FirstRow, Board.SecondColumn).Symbol &&
               _board.TileAt(Board.FirstRow, Board.ThirdColumn).Symbol ==
               _board.TileAt(Board.FirstRow, Board.SecondColumn).Symbol;
    }

    private bool IsFirstRowTaken()
    {
        return _board.TileAt(Board.FirstRow, Board.FirstColumn).Symbol != Board.EmptyPlayer &&
               _board.TileAt(Board.FirstRow, Board.SecondColumn).Symbol != Board.EmptyPlayer &&
               _board.TileAt(Board.FirstRow, Board.ThirdColumn).Symbol != Board.EmptyPlayer;
    }
}