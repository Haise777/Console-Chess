namespace Chess.Pieces;

public class Knight(int id, Color color) : Piece(id, color)
{
    public override void ScanAvailableMovements(Board board)
    {
        //TODO The horse is still unhappy
        Console.WriteLine("horse is not happy");
    }
}