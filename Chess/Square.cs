namespace Chess;

public class Square(int id, Piece? piece = null)
{
    public int Id { get; } = id;
    public Piece? Piece { get; set; } = piece;
    
}