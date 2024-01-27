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
    
    public Square[] GetValidMovementSquare(Piece piece, Board board)
    {
        throw new NotImplementedException();
    }

    public void MovePiece(Piece pieceToMove, Square squareToMove, Board board)
    {
        board.Squares
            .Single(sqr => sqr.Piece?.Id == pieceToMove.Id)
            .Piece = null;
        squareToMove.Piece = pieceToMove;
    }
}