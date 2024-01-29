namespace Chess.Pieces;

public static class PieceMovementRay
{
    public static Square[] GetPlusSquares(this IRayPiece piece, int position, Square[] squares)
    {
        var rays = piece.SquaresInSight.Keys.Take(4).ToArray();

        var squaresToMove = new List<Square>();

        var up = position + 8;
        var down = position - 8;
        var left = position - 1;
        var right = position + 1;

        var keepUp = true;
        var keepDown = true;
        var keepLeft = true;
        var keepRight = true;

        Piece? upPiece = null;
        Piece? downPiece = null;
        Piece? leftPiece = null;
        Piece? rightPiece = null;

        int n;
        do
        {
            n = 0;
            if (up < 64)
            {
                CheckSquare(0, piece, squaresToMove, squares[up], ref keepUp, ref upPiece);

                piece.SquaresInSight[rays[0]].Add(squares[up]);
                up += 8;
                n++;
            }

            if (down >= 0)
            {
                CheckSquare(1, piece, squaresToMove, squares[down], ref keepDown, ref downPiece);

                piece.SquaresInSight[rays[1]].Add(squares[down]);
                down -= 8;
                n++;
            }

            if ((left + 1) % 8 != 0)
            {
                CheckSquare(2, piece, squaresToMove, squares[left], ref keepLeft, ref leftPiece);

                piece.SquaresInSight[rays[2]].Add(squares[left]);
                left--;
                n++;
            }

            if (right % 8 != 0)
            {
                CheckSquare(3, piece, squaresToMove, squares[right], ref keepRight, ref rightPiece);

                piece.SquaresInSight[rays[3]].Add(squares[right]);
                right++;
                n++;
            }
        } while (n != 0);

        return squaresToMove.ToArray();
    }

    private static void CheckSquare(
        int rayNum, IRayPiece piece, List<Square> squaresToMove, Square currentSquare, ref bool keep, ref Piece? foundPiece)
    {
        if (currentSquare.Piece is not null && currentSquare.Piece.Color == piece.Color)
            keep = false;

        if (foundPiece is null && keep)
        {
            if (currentSquare.Piece is null || currentSquare.Piece.GetType().Name != nameof(King))
            {
                foundPiece = currentSquare.Piece;
                squaresToMove.Add(currentSquare);
            }
            
        }
        else if (keep)
        {
            if (currentSquare.Piece is null) return;
            if (currentSquare.Piece.GetType().Name == nameof(King) && currentSquare.Piece.Color != piece.Color)
            {
                foundPiece.PinnedBy.TryAdd(piece, rayNum);
            }
            else keep = false;
        }
    }

    public static Square[] GetCrossSquares(this IRayPiece piece, int position, Square[] squares)
    {
        var rays = piece.SquaresInSight.Count == 4
            ? piece.SquaresInSight.Keys.Take(4).ToArray()
            : piece.SquaresInSight.Keys.TakeLast(4).ToArray();

        var squaresToMove = new List<Square>();

        var upperRight = position + 9;
        var upperLeft = position + 7;
        var lowerRight = position - 9;
        var lowerLeft = position - 7;

        var keepLowerLeft = true;
        var keepLowerRight = true;
        var keepUpperLeft = true;
        var keepUpperRight = true;
        
        Piece? upperRightPiece = null;
        Piece? upperLeftPiece = null;
        Piece? lowerRightPiece = null;
        Piece? lowerLeftPiece = null;

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
                    CheckSquare(0, piece, squaresToMove, squares[upperRight], ref keepUpperRight, ref upperRightPiece);

                    piece.SquaresInSight[rays[0]].Add(squares[upperRight]);
                    upperRight += 9;
                    n++;
                }

                if ((upperLeft + 1) % 8 != 0)
                {
                    CheckSquare(1, piece, squaresToMove, squares[upperLeft], ref keepUpperLeft, ref upperLeftPiece);

                    piece.SquaresInSight[rays[1]].Add(squares[upperLeft]);
                    upperLeft += 7;
                    n++;
                }
            }

            if (lowerRight >= 0 || lowerLeft >= 0)
            {
                //Checks the lateral limits
                if (lowerRight % 8 != 0)
                {
                    CheckSquare(2, piece, squaresToMove, squares[lowerRight], ref keepLowerRight, ref lowerRightPiece);

                    piece.SquaresInSight[rays[2]].Add(squares[lowerRight]);
                    lowerRight -= 9;
                    n++;
                }

                if ((lowerLeft + 1) % 8 != 0)
                {
                    CheckSquare(3, piece, squaresToMove, squares[lowerLeft], ref keepLowerLeft, ref lowerLeftPiece);

                    piece.SquaresInSight[rays[3]].Add(squares[lowerLeft]);
                    lowerLeft -= 7;
                    n++;
                }
            }
        } while (n != 0);

        return squaresToMove.ToArray();
    }
}