namespace Chess.Pieces;

public class Pawn(int id, Color color) : Piece(id, color)
{
    public override Square[] GetValidMovements(Board board)
    {
        throw new NotImplementedException();
    }
}