namespace Chess.Pieces;

public class Queen(int id, Color color) : Piece(id, color), IRayPiece
{
    public override void ScanAvailableMovements(Board board)
    {
        var position = board.Squares.Single(sqr => sqr.Piece?.Id == Id).Id - 1;
        var availableSquares = new List<Square>();
        availableSquares.AddRange(this.GetPlusSquares(position, board.Squares));
        availableSquares.AddRange(this.GetCrossSquares(position, board.Squares));
        
        if (PinnedBy.Count > 0)
            availableSquares = RemoveIllegalSquares(availableSquares).ToList();
        
        AvailableMovements.AddRange(availableSquares);
    }

    public void ClearRays()
    {
        for (var i = 0; i < SquaresInSight.Count; i++)
        {
            SquaresInSight[i].Clear();
        }
    }

    public Dictionary<int, List<Square>> SquaresInSight { get; set; } = new()
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
}