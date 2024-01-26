namespace Chess;

public partial class Board
{
    public Square[,] Squares { get; set; }

    public Board()
    {
        Squares = new Square[8,8];
        for (var y = 0; y < 8; y++)
        {
            for (var x = 0; x < 8; x++)
            {
                Squares[y, x] = SquareFactory(y, x);
            }
        }
    }
    
    
}