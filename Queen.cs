using System;

public class Queen : Piece {
    public Queen(Board board, PieceColor color, int xcoord, int ycoord) : base(board, color, xcoord, ycoord) {
        CharWhite = 'Q';
        CharBlack = 'q';
    }

    protected override bool IsObstructed(Square move) {
        return false;
    }

    protected override bool IsValid(Square move) {
        return true;
    }
}