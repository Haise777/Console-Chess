namespace Chess.Pieces;

public abstract class Piece(int id, Color color)
{
    public int Id { get; } = id;
    public Color Color { get; } = color;
    protected List<Square> AvailableMovements { get; private set; } = [];
    public Dictionary<IRayPiece, int> PinnedBy { get; set; } = new();

    public IEnumerable<Square> GetAvailableMovements()
    {
        return RemoveIllegalSquares(AvailableMovements);
    }

    public void FlushAvailableMovements()
        => AvailableMovements.Clear();

    protected void AddSquareIfValid(int position, List<Square> validSquares, Square[] squares)
    {
        if (squares[position].Piece is null || squares[position].Piece.Color != Color)
            validSquares.Add(squares[position]);
    }

    protected IEnumerable<Square> RemoveIllegalSquares(IEnumerable<Square> validSquares)
    {
        if (PinnedBy.Count < 1) return validSquares.ToArray();
        
        var squares = new List<Square>();
        foreach (var pinned in PinnedBy)
        {
            squares.AddRange(validSquares.Where(sqr => pinned.Key.SquaresInSight[pinned.Value].Contains(sqr)));
        }

        if (PinnedBy.Count == 1)
            if (validSquares.Any(sqr => sqr.Piece?.Id == PinnedBy.Keys.First().Id))
                squares.Add(validSquares.Single(sqr => sqr.Piece?.Id == PinnedBy.Keys.First().Id));

        return squares;
    }

    public abstract void ScanAvailableMovements(Board board);
}