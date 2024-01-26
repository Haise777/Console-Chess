namespace Chess;

public class ChessGame(ConsoleRender render, Engine engine)
{
    private readonly Board _board;
    private bool _isWhite = true;
    //Should have a play object
    
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
            render.DisplayBoard(_board);
            
            //Give the player control options
            MoveControl();
        }
    }

    private void MoveControl()
    {
        //Select the piece you want to move
        var selectedPiece = render.SelectPiece();
        if (!engine.ValidatePiece(selectedPiece, _board))
        {
            //Invalid Piece
            return;
        }
        
        //Show the available squares that this piece can move or capture
        var movement = render.SelectMovements(_board);
        if (!engine.ValidateMovement(movement, _board))
        {
            //Invalid movement
            //Should NOT return function
        }
        
        //Capture the user input and process the movement
        engine.MovePiece(movement, _board);

        //Repeat the cycle
    }
    
}