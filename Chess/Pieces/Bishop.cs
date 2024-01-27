namespace Chess.Pieces;

public class Bishop(int id, Color color) : Piece(id, color)
{
    public override Square[] GetValidMovements(Board board)
    {
        var position = board.Squares.Single(sqr => sqr.Piece?.Id == Id).Id - 1;

        return PieceMovementRay.GetCrossSquares(position, board.Squares, Color);
    }
}