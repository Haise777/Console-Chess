using Chess.Pieces;

namespace Chess;

public class ConsoleDisplay
{
    public void DisplayBoard(Square[] board)
    {
        for (var i = 0; i < 64; i++)
        {
            if (i % 8 == 0)
            {
                Console.Write("\n");
            }
            Console.Write(
                $"{board[i].Id:00}:{PieceTranslator(board[i].Piece?.Id) ?? "   "}{board[i].Piece?.Color.ToString().ToLower()[0] ?? ' '} | ");
        }
    }

    public int SelectPiece()
    {
        return int.Parse(Console.ReadLine());
    }

    public int SelectSquareToMove(Piece piece, Square[] board)
    {
        for (var i = 0; i < board.Length; i++)
        {
            Console.Write(
                $"{board[i].Id:00}:{PieceTranslator(board[i].Piece?.Id) ?? "   "}{board[i].Piece?.Color.ToString().ToLower()[0] ?? ' '} | ");
        }

        Console.Write($"\n({piece.Id}){piece.GetType().Name} > ");
        var input = int.Parse(Console.ReadLine());
        Console.Write("\n");
        return input;
    }

    //TODO: Hmm
    private string? PieceTranslator(int? id)
    {
        if (id is null) return null;

        switch (id)
        {
            //Rook
            case 1:
            case 8:
            case 25:
            case 32:
                return $"{id:00}R";

            //Knight
            case 2:
            case 7:
            case 26:
            case 31:
                return $"{id:00}k";

            //Bishop
            case 3:
            case 6:
            case 27:
            case 30:
                return $"{id:00}B";

            //Queen
            case 4:
            case 28:
                return $"{id:00}Q";

            //King    
            case 5:
            case 29:
                return $"{id:00}K";

            //Pawn
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
                return $"{id:00}P";

            default: throw new IndexOutOfRangeException($"{id} Is not a valid piece id");
        }

        ;
    }
}