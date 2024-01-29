namespace Chess.Pieces;

public interface IRayPiece
{
    public int Id { get; }
    public Dictionary<int, List<Square>> SquaresInSight { get; set; }
    public Color Color { get; }
    public void ClearRays();
}