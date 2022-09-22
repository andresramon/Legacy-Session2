namespace TicTacToe
{
    public class Tile
    {
        public const char EmptyPlayer = ' ';
        private readonly Position position;
        private char Player { get; set; }

        public Tile(int row, int column)
        {
            position = new Position(row, column);
            Player = EmptyPlayer;
        }
        public bool IsPositionOccupied()
        {
            return Player != EmptyPlayer;
        }

        public void SetPlayer(char player)
        {
            Player = player;
        }

        public char GetPlayer()
        {
            return Player;
        }


        public bool IsMatchesPosition(int row, int column)
        {
            return position.Row == row && position.Column == column;
        }

        public bool IsMatchesPosition(Position otherPosition)
        {
            return position.Row == otherPosition.Row && position.Column == otherPosition.Column;
        }

        public bool HasSamePlayer(Tile otherTile)
        {
            return Player == otherTile.Player;
        }

    }
}