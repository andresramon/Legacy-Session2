namespace TicTacToe;

public class Tile
{
    public const char EmptyPlayer = ' ';
    public int Row { get; }
    public int Column { get; }
    public char Player { get; private set; }

    public Tile(int row, int column)
    {
        Row = row;
        Column = column;
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

    
}