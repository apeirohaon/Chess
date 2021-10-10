using System;

public class Rook : Piece {
    public Rook(Board board, PieceColor color, int xcoord, int ycoord) : base(board, color, xcoord, ycoord) {
        type = PieceType.Rook;
        CharWhite = 'R';
        CharBlack = 'r';
    }

    protected override bool IsObstructed(Square move) {
        int xdir, ydir, xdiff = move.X - square.X, ydiff = move.Y - square.Y;
        xdir = xdiff == 0 ? 0 : xdiff / Math.Abs(xdiff);
        ydir = ydiff == 0 ? 0 : ydiff / Math.Abs(ydiff);
        Square testSquare = new Square(square.X, square.Y);
        bool atLastSquare = false;

        while (!atLastSquare) {
            testSquare = new Square(testSquare.X + xdir, testSquare.Y + ydir);
            atLastSquare = (testSquare.X == move.X && testSquare.Y == move.Y);
            if (containingBoard.IsPopulated(testSquare)) {
                if (atLastSquare)
                    return containingBoard.GetPieceAt(testSquare).color == this.color;
                return true;
            }
        }
        return false;
    }

    protected override bool IsValid(Square move) {
        return (square.X == move.X) || (square.Y == move.Y);
    }
}