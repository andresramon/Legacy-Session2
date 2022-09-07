using System;

namespace TicTacToe
{
    public class Game
    {
        private char _lastSymbol = ' ';
        private readonly Board _board = new Board();
        
        public void Play(char symbol, int x, int y)
        {
            CheckValidMove(symbol, x, y);
            UpdateGameState(symbol, x, y);
        }

        private void UpdateGameState(char symbol, int x, int y)
        {
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
        }

        private void CheckValidMove(char symbol, int x, int y)
        {
            CheckFirstMoveValid(symbol);
            CheckPlayerRepeated(symbol);
            _board.CheckAlreadyPlayedTile(x, y);
        }

        private void CheckFirstMoveValid(char symbol)
        {
            if (IsFirstMove() && IsPlayerO(symbol))
            {
                throw new Exception("Invalid first player");
            }
        }

        private void CheckPlayerRepeated(char symbol)
        {
            if (symbol == _lastSymbol)
            {
                throw new Exception("Invalid next player");
            } 
        }

        private bool IsFirstMove()
        {
            return _lastSymbol == ' ';
        }

        private static bool IsPlayerO(char symbol)
        {
            return symbol == 'O';
        }

        public char Winner()
        {
            for (int row = 0;row < 3;row++)
            {
                if(IsWinnerInRow(row))
                {
                    return _board.TileAt(row, 0).Symbol;
                } 
            }

            return ' ';
        }

        private bool IsWinnerInRow(int row)
        {
            return IsRowPositionsFull(row) && IsRowWithSameSymbol(row);
        }

        private bool IsRowPositionsFull(int row)
        {
            return _board.TileAt(row, 0).Symbol != ' ' &&
                   _board.TileAt(row, 1).Symbol != ' ' &&
                   _board.TileAt(row, 2).Symbol != ' ';
        }

        private bool IsRowWithSameSymbol(int row)
        {
            return _board.TileAt(row, 0).Symbol == 
                   _board.TileAt(row, 1).Symbol &&
                   _board.TileAt(row, 2).Symbol == 
                   _board.TileAt(row, 1).Symbol;
        }
    }
}