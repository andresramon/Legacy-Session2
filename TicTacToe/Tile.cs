namespace TicTacToe;

public class Tile
{
    public const char EmptyPlayer = ' ';
    public int Row { get; init; }
    public int Column { get; init; }
    public char Player { get; set; }
    
    public bool IsPositionOccupied()
    {
        return Player != EmptyPlayer;
    }

    
}