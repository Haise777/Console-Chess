namespace Chess;

public class Piece(int id, Color color, PieceType type)
{
    public int Id { get; } = id;
    public Color Color { get; } = color;
    public PieceType Type { get; } = type;
}

public enum PieceType
{
    King,
    Queen,
    Tower,
    Bishop,
    Knight,
    Pawn,
}