namespace Chess.Pieces;

public class Queen(int id, Color color) : Piece(id, color), IRayPiece
{
    public override Square[] GetValidMovements(Board board)
    {
        var position = board.Squares.Single(sqr => sqr.Piece?.Id == Id).Id - 1;
        var validSquares = new List<Square>();
        validSquares.AddRange(this.GetPlusSquares(position, board.Squares));
        validSquares.AddRange(this.GetCrossSquares(position, board.Squares));
        
        if (PinnedBy.Count > 0)
            validSquares = RemoveIllegalSquares(validSquares).ToList();
        
        return validSquares.ToArray();
    }

    public void ClearRays()
    {
        for (var i = 0; i < 8; i++)
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