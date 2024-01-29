namespace Chess.Pieces;

public class Rook(int id, Color color) : Piece(id, color), IRayPiece
{
    public override Square[] GetValidMovements(Board board)
    {
        var position = board.Squares.Single(s => s.Piece?.Id == Id).Id - 1;
        var validSquares = this.GetPlusSquares(position, board.Squares);

        if (PinnedBy.Count > 0)
            validSquares = RemoveIllegalSquares(validSquares.ToList());
        
        return validSquares;
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
        for (var i = 0; i < 4; i++)
        {
            SquaresInSight[i].Clear();
        }
    }
}