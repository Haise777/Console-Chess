namespace Chess.Pieces;

public class TracingData(int currentPosition)
{
    public int CurrentPosition = currentPosition;
    public bool ShouldKeepGoing = true;
    public Piece? FoundPiece = null;
}