using Chess.Pieces;

namespace Chess;

public partial class Board
{
    public Board()
    {
        Squares = InitializeBoard();
    }

    public Square[] Squares { get; }

    public void MovePiece(Piece pieceToMove, Square squareToMove)
    {
        Squares
            .Single(sqr => sqr.Piece?.Id == pieceToMove.Id)
            .Piece = null;
        squareToMove.Piece = pieceToMove;
    }

    public int GetPositionNum(Piece piece)
        => Squares.Single(sqr => sqr.Piece?.Id == piece.Id).Id - 1;


    public IEnumerable<Square> GetKingSquares()
        => Squares.Where(sqr => sqr.Piece?.GetType().Name == nameof(King));


    public void UpdatePaths()
    {
        ClearAllThreats();
        var pieces = GetAllPieces();

        foreach (var piece in pieces)
        {
            piece.PinnedBy.Clear();
            piece.FlushAvailableMovements();
            if (piece.GetType().GetInterface(nameof(ITracePiece)) == typeof(ITracePiece))
                (piece as ITracePiece).ClearTraces();
        }

        foreach (var piece in pieces) piece.ScanAvailableMovements(this);

        foreach (var piece in pieces) piece.ValidateMovements();
    }

    private IEnumerable<Piece> GetAllPieces()
        => Squares
            .Where(sqr => sqr.Piece is not null)
            .Select(p => p.Piece)!;


    private void ClearAllThreats()
    {
        foreach (var square in Squares) 
            square.Threats.Clear();
    }
}