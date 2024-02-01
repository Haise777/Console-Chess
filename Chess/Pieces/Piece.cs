namespace Chess.Pieces;

public abstract class Piece(int id, Color color)
{
    public int Id { get; } = id;
    public Color Color { get; } = color;
    public List<Square> AvailableMovements { get; } = [];
    public Dictionary<ITracePiece, int> PinnedBy { get; } = new();

    public void FlushAvailableMovements() => AvailableMovements.Clear();

    public void ScanAvailableMovements(Board board)
    {
        var availableSquares = GetAvailableMovements(board);
        AvailableMovements.AddRange(availableSquares);
    }

    public void ValidateMovements() //Sadly it needed to be separate from ScanAvailableMovements
    {
        if (PinnedBy.Count > 0)
            RemoveIllegalSquares(AvailableMovements);

        RegisterThreats(AvailableMovements);
    }

    protected virtual void RemoveIllegalSquares(List<Square> validSquares)
    {
        if (PinnedBy.Count < 1) return;

        Square? pinnerSquare = null; //*1
        if (validSquares.Any(sqr => sqr.Piece?.Id == PinnedBy.Keys.First().Id))
            pinnerSquare = validSquares.Single(sqr => sqr.Piece?.Id == PinnedBy.Keys.First().Id);

        foreach (var pinned in PinnedBy)
            validSquares.RemoveAll(sqr => !pinned.Key.SquaresInSight[pinned.Value].Contains(sqr));

        //*1 - Important for allowing the pinned piece to capture it's pinner only if its only one pinner
        if (PinnedBy.Count == 1 && pinnerSquare is not null)
            validSquares.Add(pinnerSquare);
    }

    protected void AddSquareIfValid(int position, List<Square> validSquares, Square[] squares)
    {
        if (squares[position].Piece is null || squares[position].Piece.Color != Color)
            validSquares.Add(squares[position]);
    }

    protected abstract List<Square> GetAvailableMovements(Board board);

    private void RegisterThreats(IEnumerable<Square> availableSquares)
    {
        foreach (var sqr in availableSquares) 
            sqr.Threats.Add(this);
    }
}