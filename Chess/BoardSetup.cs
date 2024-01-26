namespace Chess;


//TODO: Set the pieces properly
//TODO: Is this madness actually the best way to do it?
public partial class Board
{
    private Square SquareFactory(int y, int x)
    {
        switch (y)
        {
            case 0:
                switch (x)
                {
                    case 0: return new Square(new Piece(Color.White, PieceType.Tower));
                    case 1: return new Square(new Piece(Color.White, PieceType.Tower));
                    case 2: return new Square(new Piece(Color.White, PieceType.Tower));
                    case 3: return new Square(new Piece(Color.White, PieceType.Tower));
                    case 4: return new Square(new Piece(Color.White, PieceType.Tower));
                    case 5: return new Square(new Piece(Color.White, PieceType.Tower));
                    case 6: return new Square(new Piece(Color.White, PieceType.Tower));
                    case 7: return new Square(new Piece(Color.White, PieceType.Tower));
                    default: throw new IndexOutOfRangeException($"{x} Is not a valid square position");
                }
            case 1:
                switch (x)
                {
                    case 0: return new Square(new Piece(Color.White, PieceType.Tower));
                    case 1: return new Square(new Piece(Color.White, PieceType.Tower));
                    case 2: return new Square(new Piece(Color.White, PieceType.Tower));
                    case 3: return new Square(new Piece(Color.White, PieceType.Tower));
                    case 4: return new Square(new Piece(Color.White, PieceType.Tower));
                    case 5: return new Square(new Piece(Color.White, PieceType.Tower));
                    case 6: return new Square(new Piece(Color.White, PieceType.Tower));
                    case 7: return new Square(new Piece(Color.White, PieceType.Tower));
                    default: throw new IndexOutOfRangeException($"{x} Is not a valid square position");
                }
            case 6:
                switch (x)
                {
                    case 0: return new Square(new Piece(Color.Black, PieceType.Tower));
                    case 1: return new Square(new Piece(Color.Black, PieceType.Tower));
                    case 2: return new Square(new Piece(Color.Black, PieceType.Tower));
                    case 3: return new Square(new Piece(Color.Black, PieceType.Tower));
                    case 4: return new Square(new Piece(Color.Black, PieceType.Tower));
                    case 5: return new Square(new Piece(Color.Black, PieceType.Tower));
                    case 6: return new Square(new Piece(Color.Black, PieceType.Tower));
                    case 7: return new Square(new Piece(Color.Black, PieceType.Tower));
                    default: throw new IndexOutOfRangeException($"{x} Is not a valid square position");
                }
            case 7:
                switch (x)
                {
                    case 0: return new Square(new Piece(Color.Black, PieceType.Tower));
                    case 1: return new Square(new Piece(Color.Black, PieceType.Tower));
                    case 2: return new Square(new Piece(Color.Black, PieceType.Tower));
                    case 3: return new Square(new Piece(Color.Black, PieceType.Tower));
                    case 4: return new Square(new Piece(Color.Black, PieceType.Tower));
                    case 5: return new Square(new Piece(Color.Black, PieceType.Tower));
                    case 6: return new Square(new Piece(Color.Black, PieceType.Tower));
                    case 7: return new Square(new Piece(Color.Black, PieceType.Tower));
                    default: throw new IndexOutOfRangeException($"{x} Is not a valid square position");
                }
            default: return new Square();
        }
    }
}