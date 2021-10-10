using System;

public class King : Piece {

    public King(Board board, PieceColor color, int xcoord, int ycoord) : base(board, color, xcoord, ycoord) {
        type = PieceType.King;
        CharWhite = 'K';
        CharBlack = 'k';
    }

    protected override bool IsObstructed(Square move) {
        if (containingBoard.IsPopulated(move)) {
            if (containingBoard.GetPieceAt(move).color == this.color) {
                return true;
            }
        }
        return false;
    }

    protected override bool IsValid(Square move) {
        return ((Math.Abs(move.X - square.X) <= 1) && (Math.Abs(move.Y - square.Y) <= 1) && !move.Equals(square));
    }

    public bool InCheck() {
        Piece currentPiece;
        Square currentSquare;
        for (int i = 1; i <= 8; i++) {
            currentSquare.X = i;
            for (int j = 1; j <= 8; j++) {
                currentSquare.Y = j;
                currentPiece = this.containingBoard.GetPieceAt(currentSquare);
                if (currentPiece != null && currentPiece.color != this.color) {
                    if (currentPiece.IsAttacking(this.square))
                        return true;
                }
            }
        }
        return false;
    }
}