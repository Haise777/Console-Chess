namespace Chess.Pieces;

public class Pawn(int id, Color color) : Piece(id, color)
{
    public override void ScanAvailableMovements(Board board)
    {
        var squares = board.Squares;
        var position = squares.Single(sqr => sqr.Piece?.Id == Id).Id - 1;
        var availableSquares = new List<Square>();

        if (Color == Color.White)
            AddSquareIfValid(position + 8, availableSquares, squares);
        else
            AddSquareIfValid(position - 8, availableSquares, squares);
        
        if (PinnedBy.Count > 0)
            availableSquares = RemoveIllegalSquares(availableSquares).ToList();
        
        AvailableMovements.AddRange(availableSquares);
    }
}