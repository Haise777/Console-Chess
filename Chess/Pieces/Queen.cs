namespace Chess.Pieces;

public class Queen(int id, Color color) : Piece(id, color), ITracePiece
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
        [3] = [],
        [4] = [],
        [5] = [],
        [6] = [],
        [7] = []
    };

    protected override List<Square> GetAvailableMovements(Board board)
    {
        var position = board.GetPositionNum(this);
        var availableSquares = this.GetPlusSquares(position, board.Squares);
        availableSquares.AddRange(this.GetCrossSquares(position, board.Squares));

        return availableSquares;
    }
}