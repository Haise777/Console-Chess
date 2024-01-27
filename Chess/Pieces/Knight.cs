namespace Chess.Pieces;

public class Knight(int id, Color color) : Piece(id, color)
{
    public override Square[] GetValidMovements(Board board)
    {
        throw new NotImplementedException();
    }
}