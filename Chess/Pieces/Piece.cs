namespace Chess.Pieces;

public abstract class Piece(int id, Color color)
{
    public int Id { get; } = id;
    public Color Color { get; } = color;
    public Dictionary<IRayPiece, int> PinnedBy { get; set; } = new();


    protected void AddSquareIfValid(Square[] squares, List<Square> validSquares, int position)
    {
        if (squares[position].Piece is null || squares[position].Piece.Color != Color)
            validSquares.Add(squares[position]);
    }

    protected Square[] RemoveIllegalSquares(List<Square> validSquares)
    {
        var squares = new List<Square>();
        foreach (var pinned in PinnedBy)
        {
            squares.AddRange(validSquares.Where(sqr => pinned.Key.SquaresInSight[pinned.Value].Contains(sqr)));
        }

        if (PinnedBy.Count == 1)
            if (validSquares.Exists(sqr => sqr.Piece?.Id == PinnedBy.Keys.First().Id))
                squares.Add(validSquares.Single(sqr => sqr.Piece?.Id == PinnedBy.Keys.First().Id));
        
        return squares.ToArray();
    }

    public abstract Square[] GetValidMovements(Board board);
}