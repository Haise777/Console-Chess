namespace Chess;

public class ConsoleDisplay
{
    public void DisplayBoard(Square[] board)
    {
        for (var i = 0; i < 64; i++)
        {
            if (i % 8 == 0) Console.Write("\n");
            Console.Write($"{board[i].Id}:{board[i].Piece?.Id} | ");
        }
    }

    public int SelectSquareToMove(Square[] board)
    {
        Console.ReadLine();
        throw new NotImplementedException();
    }

    public int SelectPiece()
    {
        Console.ReadLine();
        throw new NotImplementedException();
    }
}