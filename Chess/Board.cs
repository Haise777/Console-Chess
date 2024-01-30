using Chess.Pieces;

namespace Chess;

public partial class Board
{
    public Square[] Squares { get; }
    
    public Board(Engine engine)
    {
        Squares = new Square[64];
        for (var i = 0; i < 64; i++)
        {
            Squares[i] = SquareFactory(i);
        }
    }

    public IEnumerable<Piece> GetAllPieces()
    {
        return Squares
            .Where(sqr => sqr.Piece is not null)
            .Select(p => p.Piece)!;
    }

    public void MovePiece(Piece pieceToMove, Square squareToMove)
    {
        Squares
            .Single(sqr => sqr.Piece?.Id == pieceToMove.Id)
            .Piece = null;
        squareToMove.Piece = pieceToMove;
    }

    public IEnumerable<Square> GetKingSquares()
    {
        return Squares.Where(sqr => sqr.Piece?.GetType().Name == nameof(King));
    }

    public void ClearAllThreats()
    {
        foreach (var square in Squares)
        {
            square.Threats.Clear();
        }
    }
}