using System;

public class Queen : Piece {
    public Queen(PieceColor color) : base(color) {
        /*UnicodeWhite = '\u2655';
        UnicodeBlack = '\u265B';*/
        CharWhite = 'Q';
        CharBlack = 'q';
    }
}