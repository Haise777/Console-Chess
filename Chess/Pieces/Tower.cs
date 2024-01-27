namespace Chess.Pieces;

public class Tower(int id, Color color) : Piece(id, color)
{
    public override Square[] GetValidMovements(Board board)
    {
        var position = board.Squares.Single(s => s.Piece?.Id == Id).Id - 1;
        
        return PieceMovementRay.GetPlusSquares(position, board.Squares, Color);
    }
}