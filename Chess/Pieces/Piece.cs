namespace Chess.Pieces;

public abstract class Piece(int id, Color color)
{
    public int Id { get; } = id;
    public Color Color { get; } = color;

    protected void AddSquareIfValid(Square[] squares, List<Square> validSquares, int position)
    {
        if (squares[position].Piece is null || squares[position].Piece.Color != Color)
            validSquares.Add(squares[position]);
    }
    
    public abstract Square[] GetValidMovements(Board board);
}
