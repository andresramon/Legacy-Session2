namespace TicTacToe
{
    public class Tile
    {
        public const char EmptyPlayer = ' ';
        private readonly Position _position;
        private char Player { get; set; }

        public Tile(int row, int column)
        {
            _position = new Position(row, column);
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

        public bool IsMatchesPosition(Position otherPosition)
        {
            return _position.Equals(otherPosition);
        }

        public bool HasSamePlayer(Tile otherTile)
        {
            return Player == otherTile.Player;
        }

    }
}