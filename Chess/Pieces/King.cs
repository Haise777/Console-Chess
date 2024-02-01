namespace Chess.Pieces;

public class King(int id, Color color) : Piece(id, color)
{
    protected override List<Square> GetAvailableMovements(Board board)
    {
        var squares = board.Squares;
        var position = board.GetPositionNum(this);
        var availableSquares = new List<Square>();

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
            AddSquareIfValid(up, availableSquares, squares);
            if (right % 8 != 0)
                AddSquareIfValid(upperRight, availableSquares, squares);

            if ((left + 1) % 8 != 0)
                AddSquareIfValid(upperLeft, availableSquares, squares);
        }

        if (down >= 0)
        {
            AddSquareIfValid(down, availableSquares, squares);
            if (right % 8 != 0)
                AddSquareIfValid(lowerRight, availableSquares, squares);

            if ((left + 1) % 8 != 0)
                AddSquareIfValid(lowerLeft, availableSquares, squares);
        }

        AddSquareIfValid(right, availableSquares, squares);
        AddSquareIfValid(left, availableSquares, squares);

        return availableSquares;
    }

    protected override void RemoveIllegalSquares(List<Square> validSquares)
    {
        foreach (var sqr in validSquares)
            if (sqr.Threats.Any(p => p.Color != Color))
                validSquares.Remove(sqr);
    }
}