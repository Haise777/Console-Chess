namespace Chess.Pieces;

public interface ITracePiece
{
    public int Id { get; }
    public Dictionary<int, List<Square>> SquaresInSight { get; }
    public Color Color { get; }
    public void ClearTraces();
}