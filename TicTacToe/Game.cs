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

    public Board()
    {
        for (var i = 0; i < 3; i++)
        for (var j = 0; j < 3; j++)
            _plays.Add(new Tile { X = i, Y = j, Symbol = ' ' });
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
    private char _lastSymbol = ' ';

    public void Play(char symbol, int x, int y)
    {
        if (IfFirstMove() && IsPlayerO(symbol)) throw new Exception("Invalid first player");

        if (IsSamePlayerAsLastMove(symbol)) throw new Exception("Invalid next player");

        if (IsPositionOcuppied(x, y)) throw new Exception("Invalid position");

        UpdateGameState(symbol, x, y);
    }

    private void UpdateGameState(char symbol, int x, int y)
    {
        _lastSymbol = symbol;
        _board.AddTileAt(symbol, x, y);
    }

    private bool IsPositionOcuppied(int x, int y)
    {
        return _board.TileAt(x, y).Symbol != ' ';
    }

    private bool IsSamePlayerAsLastMove(char symbol)
    {
        return symbol == _lastSymbol;
    }

    private static bool IsPlayerO(char symbol)
    {
        return symbol == 'O';
    }

    private bool IfFirstMove()
    {
        return _lastSymbol == ' ';
    }

    public char Winner()
    {
        if (IsFirstRowTaken())
            if (IsFirstRowFullWithSamePlayer())
                return _board.TileAt(0, 0).Symbol;
        
        if (IsSecondRowTaken())
            if (IsSecondRowFullWithSamePlayer())
                return _board.TileAt(1, 0).Symbol;
        
        if (IsThirdRowTaken())
            if (IsThirdRowFullWithSamePlayer())
                return _board.TileAt(2, 0).Symbol;
        return ' ';
    }

    private bool IsThirdRowFullWithSamePlayer()
    {
        return _board.TileAt(2, 0).Symbol ==
               _board.TileAt(2, 1).Symbol &&
               _board.TileAt(2, 2).Symbol ==
               _board.TileAt(2, 1).Symbol;
    }

    private bool IsThirdRowTaken()
    {
        return _board.TileAt(2, 0).Symbol != ' ' &&
               _board.TileAt(2, 1).Symbol != ' ' &&
               _board.TileAt(2, 2).Symbol != ' ';
    }

    private bool IsSecondRowFullWithSamePlayer()
    {
        return _board.TileAt(1, 0).Symbol ==
               _board.TileAt(1, 1).Symbol &&
               _board.TileAt(1, 2).Symbol ==
               _board.TileAt(1, 1).Symbol;
    }

    private bool IsSecondRowTaken()
    {
        return _board.TileAt(1, 0).Symbol != ' ' &&
               _board.TileAt(1, 1).Symbol != ' ' &&
               _board.TileAt(1, 2).Symbol != ' ';
    }

    private bool IsFirstRowFullWithSamePlayer()
    {
        return _board.TileAt(0, 0).Symbol ==
               _board.TileAt(0, 1).Symbol &&
               _board.TileAt(0, 2).Symbol ==
               _board.TileAt(0, 1).Symbol;
    }

    private bool IsFirstRowTaken()
    {
        return _board.TileAt(0, 0).Symbol != ' ' &&
               _board.TileAt(0, 1).Symbol != ' ' &&
               _board.TileAt(0, 2).Symbol != ' ';
    }
}