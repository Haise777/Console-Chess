using Chess.Pieces;

// ReSharper disable SimplifyLinqExpressionUseAll

namespace Chess;

public class Engine
{
    private Board? _board;

    public IEnumerable<Piece> GetValidPieces(Board board, bool isWhite)
    {
        var validPieces = board.Squares
            .Where(sqr => sqr.Piece is not null)
            .Select(sqr => sqr.Piece)
            .Where(p => (p?.Color == Color.White) == isWhite);

        return validPieces!;
    }

    //Should this really needed to be a wrapper?
    public IEnumerable<Square> GetValidMovementSquare(Piece piece)
    {
        var movements = piece.AvailableMovements;
        return movements.Where(sqr => sqr.Piece?.GetType().Name != nameof(King));
    }

    public void MovePiece(Piece pieceToMove, Square squareToMove, Board board)
    {
        board.MovePiece(pieceToMove, squareToMove);
        board.UpdatePaths();
        CheckForCheckmate(board); //this can become a bool returning method
    }

    private void CheckForCheckmate(Board board)
    {
        var kingSquares = board.GetKingSquares();
        foreach (var ksqr in kingSquares)
        {
            if (!ksqr.Threats.Any(p => p.Color != ksqr.Piece!.Color)) continue;
            if (ksqr.Piece!.AvailableMovements.Any()) continue;

            var threat = ksqr.Threats.Single(p => p.Color != ksqr.Piece!.Color);
            if (!board.Squares.Any(sqr => sqr.Threats.Any(p => p.Id == threat.Id)))
                throw new NotImplementedException("Checkmate");
        }
    }
}