namespace Chess.Pieces;

public class Pawn(int id, Color color) : Piece(id, color)
{
    protected override List<Square> GetAvailableMovements(Board board)
    {
        var squares = board.Squares;
        var position = board.GetPositionNum(this);
        var availableSquares = new List<Square>();

        if (Color == Color.White)
            AddSquareIfValid(position + 8, availableSquares, squares);
        else
            AddSquareIfValid(position - 8, availableSquares, squares);

        return availableSquares;
    }
}