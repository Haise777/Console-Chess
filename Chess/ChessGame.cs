using Chess.Pieces;

// ReSharper disable PossibleMultipleEnumeration

namespace Chess;

public class ChessGame(ConsoleDisplay display, Engine engine, Board board)
{
    private readonly List<Piece> _captured = [];
    private bool _isWhite;

    public void Start()
    {
        board.UpdatePaths();
        while (true)
        {
            _isWhite = !_isWhite;
            Move();

            //TODO: Finish game logic
        }
    }

    private void Move()
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

        if (square.Piece is not null) //
            _captured.Add(square.Piece); //Currently useless

        engine.MovePiece(piece, square, board);
    }

    private Piece? SelectPiece()
    {
        var validPieces = engine.GetValidPieces(board, _isWhite);
        var input = display.SelectPiece();
        var selectedPiece = validPieces.SingleOrDefault(p => p.Id == input);
        if (selectedPiece is null)
        {
            Console.WriteLine("Invalid Piece");
            Console.ReadKey();
        }

        return selectedPiece;
    }

    private Square? SelectSquare(Piece piece)
    {
        var validSquares = engine.GetValidMovementSquare(piece);
        var input = display.SelectSquareToMove(piece, validSquares.ToArray());
        var selectedSquare = validSquares
            .SingleOrDefault(s => s.Id == input);
        if (selectedSquare is null)
        {
            Console.WriteLine("Invalid position to move");
            Console.ReadKey();
        }

        return selectedSquare;
    }
}