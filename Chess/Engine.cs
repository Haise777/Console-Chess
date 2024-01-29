using Chess.Pieces;

namespace Chess;

public class Engine
{
    public Piece[] GetValidPieces(Board board, bool isWhite)
    {
        var validPieces = new List<Piece>();
        foreach (var square in board.Squares)
        {
            switch (isWhite)
            {
                case true when square.Piece?.Color == Color.White:
                case false when square.Piece?.Color == Color.Black:
                    validPieces.Add(square.Piece);
                    break;
            }
        }

        return validPieces.ToArray();
    }

    //Should this really needed to be a wrapper?
    public Square[] GetValidMovementSquare(Piece piece, Board board)
    {
        return piece.GetValidMovements(board);
    }

    public void MovePiece(Piece pieceToMove, Square squareToMove, Board board)
    {
        board.Squares
            .Single(sqr => sqr.Piece?.Id == pieceToMove.Id)
            .Piece = null;
        squareToMove.Piece = pieceToMove;
        
        UpdatePaths(board);
    }

    private void UpdatePaths(Board board)
    {
        var pieces = board.Squares
            .Where(sqr => sqr.Piece is not null)
            .Select(p => p.Piece);

        foreach (var piece in pieces)
        {
            piece.PinnedBy.Clear();
            if (piece.GetType().GetInterface(nameof(IRayPiece)) == typeof(IRayPiece))
            {
                (piece as IRayPiece).ClearRays();
            }
        }
        foreach (var piece in pieces)
        {
            piece.GetValidMovements(board);
        }
    }
}