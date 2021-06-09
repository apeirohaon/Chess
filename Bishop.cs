using System;

public class Bishop : Piece {
    public Bishop(Board board, PieceColor color, int xcoord, int ycoord) : base(board, color, xcoord, ycoord) {
        CharWhite = 'B';
        CharBlack = 'b';
    }

    protected override bool IsObstructed(Square move) {
        return false;
    }

    protected override bool IsValid(Square move) {
        return true;
    }
}