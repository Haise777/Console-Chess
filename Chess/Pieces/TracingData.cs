namespace Chess.Pieces;

public class TracingData(int currentPosition)
{
    public int CurrentPosition = currentPosition;
    public Piece? FoundPiece = null;
    public bool ShouldKeepGoing = true;
}