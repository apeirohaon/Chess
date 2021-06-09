using System;

public class Knight : Piece {
    public Knight(Board board, PieceColor color, int xcoord, int ycoord) : base(board, color, xcoord, ycoord) {
        CharWhite = 'N';
        CharBlack = 'n';
    }

    protected override bool IsObstructed(Square move) {
        return false;
    }

    protected override bool IsValid(Square move) {
        return true;
    }
}