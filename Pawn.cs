using System;

public class Pawn : Piece {

    public Pawn(PieceColor color) : base(color) {
        /* UnicodeWhite = '\u2659';
        UnicodeBlack = '\u165F'; */
        CharWhite = 'P';
        CharBlack = 'p';
    }
}