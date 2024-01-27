namespace Chess.Pieces;

public class PieceMovementRay
{
    public static Square[] GetPlusSquares(int position, Square[] squares, Color pieceColor)
    {
        var squaresToMove = new List<Square>();
        
        var up = position + 8;
        var down = position - 8;
        var left = position - 1;
        var right = position + 1;

        var keepUp= true;
        var keepDown= true;
        var keepLeft= true;
        var keepRight= true;
        
        int n;
        do
        {
            n = 0;
            if (up < 64 && keepUp)
            {
                if (squares[up].Piece is null || squares[up].Piece.Color != pieceColor)
                    squaresToMove.Add(squares[up]);
                else keepUp = false;
                
                up += 8;
                n++;
            }

            if (down >= 0 && keepDown)
            {
                if (squares[down].Piece is null || squares[down].Piece.Color != pieceColor)
                    squaresToMove.Add(squares[down]);
                else keepDown = false;
                
                down -= 8;
                n++;
            }

            if ((left + 1) % 8 != 0 && keepLeft)
            {
                if (squares[left].Piece is null || squares[left].Piece.Color != pieceColor)
                    squaresToMove.Add(squares[left]);
                else keepLeft = false;
                
                left--;
                n++;
            }

            if (right % 8 != 0 && keepRight)
            {
                if (squares[right].Piece is null || squares[right].Piece.Color != pieceColor)
                    squaresToMove.Add(squares[right]);
                else keepRight = false;
                
                right++;
                n++;
            }
        } while (n != 0);

        return squaresToMove.ToArray();
    }

    public static Square[] GetCrossSquares(int position, Square[] squares, Color pieceColor)
    {
        var squaresToMove = new List<Square>();
        
        var upperRight = position + 9;
        var upperLeft = position + 7;
        var lowerRight = position - 9;
        var lowerLeft = position - 7;
        
        var keepLowerLeft = true;
        var keepLowerRight= true;
        var keepUpperLeft= true;
        var keepUpperRight= true;
        
        int n;
        do
        {
            n = 0;
            //Checks the upper limit
            if (upperRight < 64 || upperLeft < 64)
            {
                //Checks the lateral limits
                if (upperRight % 8 != 0 && keepUpperRight)
                {
                    if (squares[upperRight].Piece is null || squares[upperRight].Piece.Color != pieceColor)
                        squaresToMove.Add(squares[upperRight]);
                    else keepUpperRight = false;
                
                    upperRight += 9;
                    n++;
                }

                if ((upperLeft + 1) % 8 != 0 && keepUpperLeft)
                {
                    if (squares[upperLeft].Piece is null || squares[upperLeft].Piece.Color != pieceColor)
                        squaresToMove.Add(squares[upperLeft]);
                    else keepUpperLeft = false;
                
                    upperLeft += 7;
                    n++;
                }
            }

            if (lowerRight >= 0 || lowerLeft >= 0)
            {
                //Checks the lateral limits
                if (lowerRight % 8 != 0 && keepLowerRight)
                {
                    if (squares[lowerRight].Piece is null || squares[lowerRight].Piece.Color != pieceColor)
                        squaresToMove.Add(squares[lowerRight]);
                    else keepLowerRight = false;
                
                    lowerRight -= 9;
                    n++;
                }

                if ((lowerLeft + 1) % 8 != 0 && keepLowerLeft)
                {
                    if (squares[lowerLeft].Piece is null || squares[lowerLeft].Piece.Color != pieceColor)
                        squaresToMove.Add(squares[lowerLeft]);
                    else keepLowerLeft = false;
                
                    lowerLeft -= 7;
                    n++;
                }
            }
        } while (n != 0);
        return squaresToMove.ToArray();
    }
}