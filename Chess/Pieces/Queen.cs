namespace Chess.Pieces;

public class Queen(int id, Color color) : Piece(id, color)
{
    public override Square[] GetValidMovements(Board board)
    {
        var position = board.Squares.Single(sqr => sqr.Piece?.Id == Id).Id - 1;
        var validSquares = new List<Square>();
        validSquares.AddRange(PieceMovementRay.GetPlusSquares(position, board.Squares, Color));
        validSquares.AddRange(PieceMovementRay.GetCrossSquares(position, board.Squares, Color));

        return validSquares.ToArray();
    }
}