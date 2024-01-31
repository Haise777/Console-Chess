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
        var movements = piece.GetAvailableMovements();
        return movements.Where(sqr => sqr.Piece?.GetType().Name != nameof(King));
    }

    public void MovePiece(Piece pieceToMove, Square squareToMove, Board board)
    {
        board.MovePiece(pieceToMove, squareToMove);
        UpdateBoard(board);
    }

    public void UpdateBoard(Board board)
    {
        board.ClearAllThreats();
        var pieces = board.GetAllPieces();

        foreach (var piece in pieces)
        {
            piece.PinnedBy.Clear();
            piece.FlushAvailableMovements();
            if (piece.GetType().GetInterface(nameof(ITracePiece)) == typeof(ITracePiece))
            {
                (piece as ITracePiece).ClearTraces();
            }
        }

        foreach (var piece in pieces)
        {
            piece.ScanAvailableMovements(board);
        }

        foreach (var piece in pieces)
        {
            piece.ValidateMovements();
        }

        CheckForCheckmate(board);
    }

    private void CheckForCheckmate(Board board)
    {
        var kingSquares = board.GetKingSquares();
        foreach (var ksqr in kingSquares)
        {
            if (!ksqr.Threats.Any(p => p.Color != ksqr.Piece!.Color)) continue;
            if (ksqr.Piece!.GetAvailableMovements().Any()) continue;

            var threat = ksqr.Threats.Single(p => p.Color != ksqr.Piece!.Color);
            if (!board.Squares.Any(sqr => sqr.Threats.Any(p => p.Id == threat.Id)))
                throw new NotImplementedException("Checkmate");
        }
    }
}