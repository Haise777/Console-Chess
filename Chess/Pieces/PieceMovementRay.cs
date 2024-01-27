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
        
        int n;
        do
        {
            n = 0;
            if (up < 64)
            {
                if (squares[up].Piece is null || squares[up].Piece.Color != pieceColor)
                    squaresToMove.Add(squares[up]);
                
                up += 8;
                n++;
            }

            if (down >= 0)
            {
                if (squares[down].Piece is null || squares[down].Piece.Color != pieceColor)
                    squaresToMove.Add(squares[down]);
                down -= 8;
                n++;
            }

            if ((left + 1) % 8 != 0)
            {
                if (squares[left].Piece is null || squares[left].Piece.Color != pieceColor)
                    squaresToMove.Add(squares[left]);
                left--;
                n++;
            }

            if (right % 8 != 0)
            {
                if (squares[right].Piece is null || squares[right].Piece.Color != pieceColor)
                    squaresToMove.Add(squares[right]);
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
        
        int n;
        do
        {
            n = 0;
            //Checks the upper limit
            if (upperRight < 64 || upperLeft < 64)
            {
                //Checks the lateral limits
                if (upperRight % 8 != 0)
                {
                    if (squares[upperRight].Piece is null || squares[upperRight].Piece.Color != pieceColor)
                        squaresToMove.Add(squares[upperRight]);
                
                    upperRight += 9;
                }

                if ((upperLeft + 1) % 8 != 0)
                {
                    if (squares[upperLeft].Piece is null || squares[upperLeft].Piece.Color != pieceColor)
                        squaresToMove.Add(squares[upperLeft]);
                
                    upperLeft += 7;
                }
                
                n++;
            }

            if (lowerRight >= 0 || lowerLeft >= 0)
            {
                //Checks the lateral limits
                if (lowerRight % 8 != 0)
                {
                    if (squares[upperRight].Piece is null || squares[upperRight].Piece.Color != pieceColor)
                        squaresToMove.Add(squares[upperRight]);
                
                    lowerRight -= 9;
                }

                if ((lowerLeft + 1) % 8 != 0)
                {
                    if (squares[upperLeft].Piece is null || squares[upperLeft].Piece.Color != pieceColor)
                        squaresToMove.Add(squares[upperLeft]);
                
                    lowerLeft -= 7;
                }

                n++;
            }
        } while (n != 0);

        return squaresToMove.ToArray();
    }
}