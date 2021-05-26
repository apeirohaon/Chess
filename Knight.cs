using System;

public class Knight : Piece {

    public Knight(PieceColor color) : base(color) {
        /* UnicodeWhite = '\u2658';
        UnicodeBlack = '\u265E'; */
        CharWhite = 'N';
        CharBlack = 'n';
    }
}