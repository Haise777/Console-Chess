using LineDataTuple = ( //Alias for tuple
    Chess.Pieces.IRayPiece currentPiece,
    System.Collections.Generic.List<Chess.Square> validatedSquares,
    Chess.Square[] allSquares);

namespace Chess.Pieces;

public static class PieceMovementTracer
{
    public static IEnumerable<Square> GetPlusSquares(this IRayPiece currentPiece, int startingPosition, Square[] allSquares)
    {
        var tracesIndex = currentPiece.SquaresInSight.Keys.Take(4).ToArray();
        var validatedSquares = new List<Square>();

        var up = new TracingData(startingPosition + 8);
        var down = new TracingData(startingPosition - 8);
        var left = new TracingData(startingPosition - 1);
        var right = new TracingData(startingPosition + 1);

        var lineData = (currentPiece, validatedSquares, allSquares);

        bool keepChecking;
        do
        {
            keepChecking = false;

            CheckTraceLine(tracesIndex[0], up.CurrentPosition < 64, num => num + 8, up, lineData, ref keepChecking);
            CheckTraceLine(tracesIndex[1], down.CurrentPosition >= 0, num => num - 8, down, lineData, ref keepChecking);
            CheckTraceLine(tracesIndex[2], (left.CurrentPosition + 1) % 8 != 0, num => --num, left, lineData,
                ref keepChecking);
            CheckTraceLine(tracesIndex[3], right.CurrentPosition % 8 != 0, num => ++num, right, lineData,
                ref keepChecking);
        } while (keepChecking);

        return validatedSquares.ToArray();
    }

    public static IEnumerable<Square> GetCrossSquares(this IRayPiece currentPiece, int startingPosition, Square[] allSquares)
    {
        var tracesIndex = currentPiece.SquaresInSight.Count == 4
            ? currentPiece.SquaresInSight.Keys.Take(4).ToArray()
            : currentPiece.SquaresInSight.Keys.TakeLast(4).ToArray();

        var validatedSquares = new List<Square>();

        var upperRight = new TracingData(startingPosition + 9);
        var upperLeft = new TracingData(startingPosition + 7);
        var lowerRight = new TracingData(startingPosition - 9);
        var lowerLeft = new TracingData(startingPosition - 7);

        var lineData = (currentPiece, validatedSquares, allSquares);

        bool keepChecking;
        do
        {
            keepChecking = false;

            if (upperRight.CurrentPosition < 64 && upperLeft.CurrentPosition < 64)
            {
                CheckTraceLine(tracesIndex[0], upperRight.CurrentPosition % 8 != 0, num => num + 9, upperRight,
                    lineData,
                    ref keepChecking);
                CheckTraceLine(tracesIndex[1], (upperLeft.CurrentPosition + 1) % 8 != 0, num => num + 7, upperLeft,
                    lineData,
                    ref keepChecking);
            }

            if (lowerRight.CurrentPosition >= 0 && lowerLeft.CurrentPosition >= 0)
            {
                CheckTraceLine(tracesIndex[2], lowerRight.CurrentPosition % 8 != 0, num => num - 9, lowerRight,
                    lineData,
                    ref keepChecking);
                CheckTraceLine(tracesIndex[3], (lowerLeft.CurrentPosition + 1) % 8 != 0, num => num - 7, lowerLeft,
                    lineData,
                    ref keepChecking);
            }
        } while (keepChecking);

        return validatedSquares.ToArray();
    }

    private static void CheckTraceLine(int traceIndex, bool condition, Func<int, int> operation,
        TracingData tracingData, LineDataTuple ldt, ref bool keepChecking)
    {
        if (!condition) return;
        CheckSquare(traceIndex, ldt.currentPiece, ldt.validatedSquares, ldt.allSquares[tracingData.CurrentPosition],
            ref tracingData.ShouldKeepGoing,
            ref tracingData.FoundPiece);

        ldt.currentPiece.SquaresInSight[traceIndex].Add(ldt.allSquares[tracingData.CurrentPosition]);
        tracingData.CurrentPosition = operation(tracingData.CurrentPosition);

        keepChecking = true;
    }

    private static void CheckSquare(
        int rayNum, IRayPiece piece, List<Square> squaresToMove, Square currentSquare, ref bool shouldKeepGoing,
        ref Piece? foundPiece)
    {
        if (currentSquare.Piece?.Color == piece.Color)
            shouldKeepGoing = false;

        if (foundPiece is null && shouldKeepGoing)
        {
            if (currentSquare.Piece is not null && currentSquare.Piece.GetType().Name == nameof(King)) return;
            foundPiece = currentSquare.Piece;
            squaresToMove.Add(currentSquare);
        }
        else if (shouldKeepGoing)
        {
            if (currentSquare.Piece is null) return;
            if (currentSquare.Piece.GetType().Name == nameof(King) && currentSquare.Piece.Color != piece.Color)
                foundPiece!.PinnedBy.TryAdd(piece, rayNum);

            else shouldKeepGoing = false;
        }
    }
}