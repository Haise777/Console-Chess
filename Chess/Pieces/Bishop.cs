namespace Chess.Pieces;

public class Bishop(int id, Color color) : Piece(id, color), ITracePiece
{
    public void ClearTraces()
    {
        for (var i = 0; i < SquaresInSight.Count; i++) 
            SquaresInSight[i].Clear();
    }

    public Dictionary<int, List<Square>> SquaresInSight { get; } = new()
    {
        [0] = [],
        [1] = [],
        [2] = [],
        [3] = []
    };

    protected override List<Square> GetAvailableMovements(Board board)
    {
        var position = board.GetPositionNum(this);
        var availableSquares = this.GetCrossSquares(position, board.Squares);

        return availableSquares;
    }
}