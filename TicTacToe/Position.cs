namespace TicTacToe
{
    public class Position
    {
        private int Row { get; }
        private int Column { get; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

       public bool Equals(Position otherPosition)
        {
            return this.Row == otherPosition.Row && this.Column == otherPosition.Column;
        }
    }
}