using System;

public class Bishop : Piece {

    public Bishop(PieceColor color) : base(color) {
        /* UnicodeWhite = '\u2657';
        UnicodeBlack = '\u265D'; */
        CharWhite = 'B';
        CharBlack = 'b';
    }
}