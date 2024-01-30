using Chess.Pieces;
// ReSharper disable PossibleMultipleEnumeration

namespace Chess;

public class ChessGame(ConsoleDisplay display, Engine engine, Board board)
{
    private bool _isWhite;
    private List<Piece> _captured = [];

    public void Start()
    {
        display.DisplayBoard(board);
        engine.UpdatePaths(board);
        while (true)
        {
            _isWhite = !_isWhite;
            MoveControl();

            //TODO: Finish game logic
        }
    }

    private void MoveControl()
    {
        Piece? piece = null;
        Square? square;

        while (true)
        {
            Console.Clear();
            display.DisplayBoard(board);
            Console.WriteLine("Is white: " + _isWhite);
            
            if (piece is null)
                if ((piece = SelectPiece()) is null)
                    continue;

            if ((square = SelectSquare(piece)) is not null) break;
        }
        
        if (square.Piece is not null)
            _captured.Add(square.Piece);

        engine.MovePiece(piece, square, board);
    }

    private Piece? SelectPiece()
    {
        var validPieces = engine.GetValidPieces(board, _isWhite);

        var selectedPiece = display.SelectPiece();
        if (validPieces.All(p => p.Id != selectedPiece))
        {
            Console.WriteLine("Invalid Piece");
            return null;
        }

        return validPieces.Single(p => p.Id == selectedPiece);
    }

    private Square? SelectSquare(Piece piece)
    {
        var validSquares = engine.GetValidMovementSquare(piece);

        var selectedSquare = display.SelectSquareToMove(piece, validSquares.ToArray());
        if (validSquares.All(s => s.Id != selectedSquare))
        {
            //TODO: Invalid square
            Console.WriteLine("Invalid position to move");
            return null;
        }

        return validSquares.Single(s => s.Id == selectedSquare);
    }
}