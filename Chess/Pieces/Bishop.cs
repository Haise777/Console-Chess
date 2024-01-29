namespace Chess.Pieces;

public class Bishop(int id, Color color) : Piece(id, color), IRayPiece
{
    public override void ScanAvailableMovements(Board board)
    {
        var position = board.Squares.Single(sqr => sqr.Piece?.Id == Id).Id - 1;
        var availableSquares = this.GetCrossSquares(position, board.Squares);

        if (PinnedBy.Count > 0)
            availableSquares = RemoveIllegalSquares(availableSquares);
        
        AvailableMovements.AddRange(availableSquares);
    }

    public Dictionary<int, List<Square>> SquaresInSight { get; set; } = new()
    {
        [0] = [],
        [1] = [],
        [2] = [],
        [3] = []
    };

    public void ClearRays()
    {
        for (var i = 0; i < SquaresInSight.Count; i++)
        {
            SquaresInSight[i].Clear();
        }
    }
}