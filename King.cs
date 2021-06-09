using System;

public class King : Piece {
    public bool IsInCheck;

    public King(Board board, PieceColor color, int xcoord, int ycoord) : base(board, color, xcoord, ycoord) {
        CharWhite = 'K';
        CharBlack = 'k';
        IsInCheck = false;
    }

    protected override bool IsObstructed(Square move) {
        if (containingBoard.IsPopulated(move)) {
            if (containingBoard.GetPiece(move).color == this.color) {
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
        bool isInCheck = false;
        Piece currentPiece;
        Square currentSquare;
        for (int i = 0; i < 8; i++) {
            currentSquare.X = i;
            for (int j = 0; j < 8; j++) {
                currentSquare.Y = j;
                currentPiece = this.containingBoard.GetPiece(currentSquare);
                if (currentPiece != null) {
                    if (currentPiece.IsAttacking(this.square)) isInCheck = true;
                }
            }
        }
        this.IsInCheck = isInCheck;
    }
}