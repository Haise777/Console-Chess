namespace Chess;

public partial class Board
{
    public Square[] Squares { get; set; }

    public Board()
    {
        Squares = new Square[64];
        for (var i = 0; i < 64; i++)
        {
            Squares[i] = SquareFactory(i);
        }
    }
}