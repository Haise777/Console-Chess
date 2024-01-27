namespace Chess;

public class ChessGame(ConsoleDisplay display, Engine engine)
{
    private readonly Board _board;
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
            Console.Clear();

            //Render the board
            display.DisplayBoard(_board);

            //Give the player control options
            MoveControl();
        }
    }

    private void MoveControl()
    {
        //Select the piece you want to move
        var piece = SelectPiece();
        //Show the available squares that this piece can move or capture
        var square = SelectSquare(piece);

        //Process the movement
        if (square.Piece is not null)
            _captured.Add(square.Piece);

        engine.MovePiece(piece, square, _board);
                
        //Repeat the cycle
    }
    
    private Piece SelectPiece()
    {
        var validPieces = engine.GetValidPieces(_board, _isWhite);
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
        var validSquares = engine.GetValidMovementSquare(piece, _board);
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