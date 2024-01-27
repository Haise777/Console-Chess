namespace Chess.Pieces;

public class King(int id, Color color) : Piece(id, color)
{
    public override Square[] GetValidMovements(Board board)
    {
        throw new NotImplementedException();
    }
}