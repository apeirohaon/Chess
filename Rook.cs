using System;

public class Rook : Piece {

    public Rook(PieceColor color) : base(color) {
        /* UnicodeWhite = '\u2656';
        UnicodeBlack = '\u265C'; */
        CharWhite = 'R';
        CharBlack = 'r';

    }
}