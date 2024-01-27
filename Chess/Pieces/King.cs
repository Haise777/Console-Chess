namespace Chess.Pieces;

public class King(int id, Color color) : Piece(id, color)
{
    public override Square[] GetValidMovements(Board board)
    {
        var squares = board.Squares;
        var position = squares.Single(sqr => sqr.Piece?.Id == Id).Id - 1;
        var validSquares = new List<Square>();
        
        var up = position + 8;
        var upperRight = position + 9;
        var upperLeft = position + 7;
        var right = position + 1;
        var lowerRight = position - 9;
        var down = position - 8;
        var lowerLeft = position - 7;
        var left = position - 1;

        if (up < 64)
        {
            AddSquareIfValid(squares, validSquares, up);
            
            if (right % 8 != 0)
            {
                AddSquareIfValid(squares, validSquares, upperRight);
                AddSquareIfValid(squares, validSquares, right);
            }

            if ((left + 1) % 8 != 0)
            {
                AddSquareIfValid(squares, validSquares, upperLeft);
                AddSquareIfValid(squares, validSquares, left);
            }
        }

        if (down >= 0)
        {
            AddSquareIfValid(squares, validSquares, down);
            
            if (right % 8 != 0)
            {
                AddSquareIfValid(squares, validSquares, lowerRight);
            }

            if ((left + 1) % 8 != 0)
            {
                AddSquareIfValid(squares, validSquares, lowerLeft);
            }
        }

        return validSquares.ToArray();
    }
}