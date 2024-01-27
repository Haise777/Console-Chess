namespace Chess.Pieces;

public abstract class Piece(int id, Color color)
{
    public int Id { get; } = id;
    public Color Color { get; } = color;

    public abstract Square[] GetValidMovements(Board board);
}
