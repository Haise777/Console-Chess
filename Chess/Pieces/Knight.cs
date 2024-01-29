namespace Chess.Pieces;

public class Knight(int id, Color color) : Piece(id, color)
{
    public override Square[] GetValidMovements(Board board)
    {
        Console.WriteLine("horse is not happy");
        return [];
    }
}