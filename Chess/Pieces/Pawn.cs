namespace Chess.Pieces;

public class Pawn(int id, Color color) : Piece(id, color)
{
    public override Square[] GetValidMovements(Board board)
    {
        var squares = board.Squares;
        var position = squares.Single(sqr => sqr.Piece?.Id == Id).Id - 1;
        var validSquares = new List<Square>();

        if (Color == Color.White)
            AddSquareIfValid(squares, validSquares, position + 8);
        else
            AddSquareIfValid(squares, validSquares, position - 8);
        
        return validSquares.ToArray();
    }
}