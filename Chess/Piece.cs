namespace Chess;

public class Piece(Color side, PieceType type)
{
    public Color Side { get; } = side;
    public PieceType Type { get; } = type;
    public bool IsCaptured { get; set; }
    
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