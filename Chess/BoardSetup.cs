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
            //1 => new Square(i, new Rook(1, Color.White)),
            2 => new Square(i, new Knight(2, Color.White)),
            3 => new Square(i, new Bishop(3, Color.White)),
            4 => new Square(i, new Queen(4, Color.White)),
            5 => new Square(i, new King(5, Color.White)),
            6 => new Square(i, new Bishop(6, Color.White)),
            7 => new Square(i, new Knight(7, Color.White)),
            8 => new Square(i, new Rook(8, Color.White)),

            9 => new Square(i, new Pawn(9, Color.White)),
            10 => new Square(i, new Pawn(10, Color.White)),
            11 => new Square(i, new Pawn(11, Color.White)),
            12 => new Square(i, new Pawn(12, Color.White)),
            //13 => new Square(i, new Pawn(13, Color.White)),
            13 => new Square(i, new Rook(1, Color.White)),
            14 => new Square(i, new Pawn(14, Color.White)),
            15 => new Square(i, new Pawn(15, Color.White)),
            16 => new Square(i, new Pawn(16, Color.White)),

            //Black pieces
            49 => new Square(i, new Pawn(17, Color.Black)),
            50 => new Square(i, new Pawn(18, Color.Black)),
            51 => new Square(i, new Pawn(19, Color.Black)),
            52 => new Square(i, new Pawn(20, Color.Black)),
            //53 => new Square(i, new Pawn(21, Color.Black)),
            53 => new Square(i, new Queen(28, Color.Black)),
            54 => new Square(i, new Pawn(22, Color.Black)),
            55 => new Square(i, new Pawn(23, Color.Black)),
            56 => new Square(i, new Pawn(24, Color.Black)),

            57 => new Square(i, new Rook(25, Color.Black)),
            58 => new Square(i, new Knight(26, Color.Black)),
            59 => new Square(i, new Bishop(27, Color.Black)),
            //60 => new Square(i, new Queen(28, Color.Black)),
            61 => new Square(i, new King(29, Color.Black)),
            62 => new Square(i, new Bishop(30, Color.Black)),
            63 => new Square(i, new Knight(31, Color.Black)),
            64 => new Square(i, new Rook(32, Color.Black)),

            //Empty squares
            _ => new Square(i)
        };
    }
}