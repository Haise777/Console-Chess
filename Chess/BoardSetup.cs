using Chess.Pieces;

namespace Chess;

//TODO: Set the pieces properly
//TODO: Is this madness actually the best way to do it?
public partial class Board
{
    private Square SquareFactory(int i)
    {
        i++;
        return i switch
        {
            //White pieces
            1 => new Square(i, new Tower(1, Color.White)),
            2 => new Square(i, new Piece(2, Color.White, PieceType.Tower)),
            3 => new Square(i, new Piece(3, Color.White, PieceType.Tower)),
            4 => new Square(i, new Piece(4, Color.White, PieceType.Tower)),
            5 => new Square(i, new Piece(5, Color.White, PieceType.Tower)),
            6 => new Square(i, new Piece(6, Color.White, PieceType.Tower)),
            7 => new Square(i, new Piece(7, Color.White, PieceType.Tower)),
            8 => new Square(i, new Piece(8, Color.White, PieceType.Tower)),
            9 => new Square(i, new Piece(9, Color.White, PieceType.Tower)),
            10 => new Square(i, new Piece(10, Color.White, PieceType.Tower)),
            11 => new Square(i, new Piece(11, Color.White, PieceType.Tower)),
            12 => new Square(i, new Piece(12, Color.White, PieceType.Tower)),
            13 => new Square(i, new Piece(13, Color.White, PieceType.Tower)),
            14 => new Square(i, new Piece(14, Color.White, PieceType.Tower)),
            15 => new Square(i, new Piece(15, Color.White, PieceType.Tower)),
            16 => new Square(i, new Piece(16, Color.White, PieceType.Tower)),
            
            //Black pieces
            49 => new Square(i, new Piece(17, Color.White, PieceType.Tower)),
            50 => new Square(i, new Piece(18, Color.White, PieceType.Tower)),
            51 => new Square(i, new Piece(19, Color.White, PieceType.Tower)),
            52 => new Square(i, new Piece(20, Color.White, PieceType.Tower)),
            53 => new Square(i, new Piece(21, Color.White, PieceType.Tower)),
            54 => new Square(i, new Piece(22, Color.White, PieceType.Tower)),
            55 => new Square(i, new Piece(23, Color.White, PieceType.Tower)),
            56 => new Square(i, new Piece(24, Color.White, PieceType.Tower)),
            57 => new Square(i, new Piece(25, Color.White, PieceType.Tower)),
            58 => new Square(i, new Piece(26, Color.White, PieceType.Tower)),
            59 => new Square(i, new Piece(27, Color.White, PieceType.Tower)),
            60 => new Square(i, new Piece(28, Color.White, PieceType.Tower)),
            61 => new Square(i, new Piece(29, Color.White, PieceType.Tower)),
            62 => new Square(i, new Piece(30, Color.White, PieceType.Tower)),
            63 => new Square(i, new Piece(31, Color.White, PieceType.Tower)),
            64 => new Square(i, new Piece(32, Color.White, PieceType.Tower)),
            
            //Empty squares
            _ => new Square(i)
        };
    }
}