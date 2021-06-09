using System;

public class Pawn : Piece {
    public Pawn(Board board, PieceColor color, int xcoord, int ycoord) : base(board, color, xcoord, ycoord) {
        CharWhite = 'P';
        CharBlack = 'p';
    }

    protected override bool IsObstructed(Square move) {
        return false;
    }

    protected override bool IsValid(Square move) {
        return true;
    }
}