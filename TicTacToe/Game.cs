using System;

namespace TicTacToe
{

    public class Game
    {
        private readonly Board _board = new();
        private char _lastPlayer = Tile.EmptyPlayer;
        const string InvalidFirstPlayer = "Invalid first player";
        const string InvalidNextPlayer = "Invalid next player";

        public void Play(char player, int row, int column)
        {
            Position position = new Position(row, column);

            ValidatePlay(player, position);
            UpdateGameState(player, position);
        }

        private void ValidatePlay(char player, Position position)
        {
            ValidateFirstPlayer(player);

            ValidatePlayerChanges(player);

            _board.ValidateFreePosition(position);
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

        private void UpdateGameState(char player, Position position)
        {
            _lastPlayer = player;
            _board.SetPlayerToTile(player, position);
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
            return _lastPlayer == Tile.EmptyPlayer;
        }

        public char Winner()
        {
            return _board.GetWinner();
        }
    }
}