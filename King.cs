using System;

public class King : Piece {
    public bool IsInCheck;

    public King(Board board, PieceColor color, int xcoord, int ycoord) : base(board, color, xcoord, ycoord) {
        CharWhite = 'K';
        CharBlack = 'k';
        IsInCheck = false;
    }

    protected override bool IsObstructed(Square move) {
        if (containingBoard.IsPopulated(move.X, move.Y)) {
            if (containingBoard.GetPiece(move.X, move.Y).color == this.color) {
                return true;
            }
        }
        return false;
    }

    protected override bool IsValid(Square move) {
        if ((Math.Abs(move.X - square.X) <= 1) && (Math.Abs(move.Y - square.Y) <= 1)) return true;
        return false;
    }

    public void CheckIfChecked() {

    }
}