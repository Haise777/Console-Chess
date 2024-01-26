namespace Chess;

public class ChessGame(ConsoleRender render, Engine engine)
{
    private readonly Board _board;
    private bool _isWhite = true;
    private Move _move;

    public void Start()
    {
        Match();
    }

    private void Match()
    {
        while (true)
        {
            _move = new();
            Console.Clear();

            //Render the board
            render.DisplayBoard(_board);

            //Give the player control options
            MoveControl();
        }
    }

    private void MoveControl()
    {
        //Select the piece you want to move
        string? piece;
        string? square;

        var validPieces = engine.GetValidPieces(_board, _isWhite);
        while (true)
        {
            piece = render.SelectPiece();
            if (validPieces.Contains(piece)) break;

            //Invalid piece
        }

        //Show the available squares that this piece can move or capture
        var validSquares = engine.GetValidMovementSquare(piece, _board);
        while (true)
        {
            square = render.SelectMovements(validSquares);
            if (validSquares.Contains(square)) break;
            
            //Invalid square
        }

        //Capture the user input and process the movement
        engine.MovePiece(piece, square, _board);
                
        //Repeat the cycle
    }
}