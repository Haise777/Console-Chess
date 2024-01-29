using Chess.Pieces;

namespace Chess;

public class ChessGame(ConsoleDisplay display, Engine engine, Board board)
{
    private bool _isWhite;
    private List<Piece> _captured = [];

    public void Start()
    {
        engine.UpdatePaths(board);
        while (true)
        {
            _isWhite = !_isWhite;
            Console.Clear();
            Console.WriteLine("Is white: " + _isWhite);
            
            display.DisplayBoard(board);
            
            MoveControl();
            
            //TODO: Finish game logic
        }
    }
    
    private void MoveControl()
    {
        var piece = SelectPiece(); 
        var square = SelectSquare(piece); 
        
        if (square.Piece is not null) 
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
                //TODO: Invalid piece
                Console.WriteLine("Invalid Piece");
                continue;
            }
            
            return validPieces.Single(p => p.Id == selectedPiece);
        }
    }
    
    private Square SelectSquare(Piece piece)
    {
        var validSquares = engine.GetValidMovementSquare(piece);
        while (true)
        {
            var selectedSquare = display.SelectSquareToMove(piece, validSquares.ToArray());
            if (validSquares.All(s => s.Id != selectedSquare))
            {
                //TODO: Invalid square
                Console.WriteLine("Invalid position to move");
                continue;   
            }

            return validSquares.Single(s => s.Id == selectedSquare);
        }
    }
}