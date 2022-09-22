using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        private readonly List<Tile> tiles = new();
        private const int MaxRow = 3;
        const int MaxColumn = 3;
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
                    tiles.Add(new Tile(row, column));
                }
            }
        }

        private Tile TileAt(Position position)
        {
            return tiles.Single(tile => tile.IsMatchesPosition(position));
        }

        public void SetPlayerToTile(char player, Position position)
        {
            TileAt(position).SetPlayer(player);
        }

        private bool IsPositionOccupied(Position position)
        {
            return TileAt(position).IsPositionOccupied();
        }

        public void ValidateFreePosition(Position position)
        {
            if (IsPositionOccupied(position))
            {
                throw new Exception(InvalidPosition);
            }
        }

        private bool IsRowFullWithSamePlayer(int row)
        {
            return TileAt(new Position(row, FirstColumn)).HasSamePlayer(TileAt(new Position(row, SecondColumn))) &&
                   TileAt(new Position(row, ThirdColumn)).HasSamePlayer(TileAt(new Position(row, SecondColumn)));
        }

        private bool IsRowTaken(int row)
        {
            return TileAt(new Position(row, FirstColumn)).IsPositionOccupied() &&
                   TileAt(new Position(row, SecondColumn)).IsPositionOccupied() &&
                   TileAt(new Position(row, ThirdColumn)).IsPositionOccupied();
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
                    return TileAt(new Position(row, FirstColumn)).GetPlayer();
                }
            }

            return Tile.EmptyPlayer;
        }
    }
}