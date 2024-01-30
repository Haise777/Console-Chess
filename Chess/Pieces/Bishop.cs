namespace Chess.Pieces;

public class Bishop(int id, Color color) : Piece(id, color), ITracePiece
{
    protected override List<Square> GetAvailableMovements(Board board)
    {
        var position = board.Squares.Single(sqr => sqr.Piece?.Id == Id).Id - 1;
        var availableSquares = this.GetCrossSquares(position, board.Squares);

        return availableSquares;
    }

    public Dictionary<int, List<Square>> SquaresInSight { get; set; } = new()
    {
        [0] = [],
        [1] = [],
        [2] = [],
        [3] = []
    };

    public void ClearTraces()
    {
        for (var i = 0; i < SquaresInSight.Count; i++)
        {
            SquaresInSight[i].Clear();
        }
    }
}