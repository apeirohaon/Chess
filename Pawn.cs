using System;

public class Pawn : Piece {
    public Pawn(Board board, PieceColor color, int xcoord, int ycoord) : base(board, color, xcoord, ycoord) {
        type = PieceType.Pawn;
        CharWhite = 'P';
        CharBlack = 'p';
    }

    protected override bool IsObstructed(Square move) {
        if (containingBoard.IsPopulated(move)) {
            return true;
        }
        else if (move.Y - square.Y == 2) {
            Square testSquare = new Square(square.X, square.Y + 1);
            if (containingBoard.IsPopulated(testSquare))
                return true;
        }
        return false;
    }

    protected override bool IsValid(Square move) {
        bool valid = false;

        if (color == PieceColor.White) {
            if ((move.Y - square.Y == 1 && move.X - square.X == 1) || (move.Y - square.Y == 1 && move.X - square.X == -1)) {
                if (containingBoard.IsPopulated(move)) {
                    if (containingBoard.GetPieceAt(move).color == PieceColor.Black)
                        valid = true;
                }
            }
            if (square.Y == 2 && (move.Y - square.Y == 2 && move.X == square.X))
                valid = true;
            if (move.Y - square.Y == 1 && move.X == square.X)
                valid = true;
        }

        if (color == PieceColor.Black) {
            if ((move.Y - square.Y == -1 && move.X - square.X == 1) || (move.Y - square.Y == -1 && move.X - square.X == -1)) {
                if (containingBoard.IsPopulated(move)) {
                    if (containingBoard.GetPieceAt(move).color == PieceColor.White)
                        valid = true;
                }
            }
            if (square.Y == 7 && (move.Y - square.Y == -2 && move.X == square.X))
                valid = true;
            if (move.Y - square.Y == -1 && move.X == square.X)
                valid = true;
        }

        return valid;
    }
}