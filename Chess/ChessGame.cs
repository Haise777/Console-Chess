using Chess.Pieces;

namespace Chess;

public class ChessGame(ConsoleDisplay display, Engine engine, Board board)
{
    private bool _isWhite = true;
    private List<Piece> _captured = [];

    public void Start()
    {
        Match();
    }

    private void Match()
    {
        while (true)
        {
            _isWhite = !_isWhite;
            Console.Clear();

            //Render the board
            display.DisplayBoard(board.Squares);

            //Give the player control options
            MoveControl();
        }
    }

    private void MoveControl()
    {
        var piece = SelectPiece(); //Select the piece you want to move
        var square = SelectSquare(piece); //Show the available squares that this piece can move or capture
        
        if (square.Piece is not null) //Process the movement
            _captured.Add(square.Piece);

        engine.MovePiece(piece, square, board);
    }
    
    private Piece SelectPiece()
    {
        var validPieces = engine.GetValidPieces(board, _isWhite);
        while (true)
        {
            var selectedPiece = display.SelectPiece();
            if (validPieces.All(p => p.Id != selectedPiece))
            {
                //Invalid piece
                continue;
            }
            
            return validPieces.Single(p => p.Id == selectedPiece);
        }
    }
    
    private Square SelectSquare(Piece piece)
    {
        var validSquares = engine.GetValidMovementSquare(piece, board);
        while (true)
        {
            var selectedSquare = display.SelectSquareToMove(validSquares);
            if (validSquares.All(s => s.Id != selectedSquare))
            {
                //Invalid square
                continue;   
            }

            return validSquares.Single(s => s.Id == selectedSquare);
        }
    }
}