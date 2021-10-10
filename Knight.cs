using System;

public class Knight : Piece {
    public Knight(Board board, PieceColor color, int xcoord, int ycoord) : base(board, color, xcoord, ycoord) {
        type = PieceType.Knight;
        CharWhite = 'N';
        CharBlack = 'n';
    }

    protected override bool IsObstructed(Square move) {
        if (containingBoard.IsPopulated(move))
            return containingBoard.GetPieceAt(move).color == this.color;
        return false;
    }

    protected override bool IsValid(Square move) {
        int absXDiff = Math.Abs(move.X - square.X);
        int absYDdiff = Math.Abs(move.Y - square.Y);
        if (absXDiff == 2) {
            return absYDdiff == 1;
        }
        else if (absXDiff == 1) {
            return absYDdiff == 2;
        }
        else {
            return false;
        }
    }
}