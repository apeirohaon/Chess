using System;

public class Rook : Piece {
    public Rook(Board board, PieceColor color, int xcoord, int ycoord) : base(board, color, xcoord, ycoord) {
        CharWhite = 'R';
        CharBlack = 'r';
    }

    protected override bool IsObstructed(Square move) {
        return false;
    }

    protected override bool IsValid(Square move) {
        return true;
    }
}