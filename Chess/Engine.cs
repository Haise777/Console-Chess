using Chess.Pieces;

namespace Chess;

public class Engine
{
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
        return piece.GetAvailableMovements();
    }

    public void MovePiece(Piece pieceToMove, Square squareToMove, Board board)
    {
        board.Squares
            .Single(sqr => sqr.Piece?.Id == pieceToMove.Id)
            .Piece = null;
        squareToMove.Piece = pieceToMove;
        
        UpdatePaths(board);
    }

    public void UpdatePaths(Board board)
    {
        var pieces = board.Squares
            .Where(sqr => sqr.Piece is not null)
            .Select(p => p.Piece);

        foreach (var piece in pieces)
        {
            piece.PinnedBy.Clear();
            piece.FlushAvailableMovements();
            if (piece.GetType().GetInterface(nameof(IRayPiece)) == typeof(IRayPiece))
            {
                (piece as IRayPiece).ClearRays();
            }
        }
        foreach (var piece in pieces)
        {
            piece.ScanAvailableMovements(board);
        }
    }
}