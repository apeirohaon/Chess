using System;

public class Board {
	private Piece[,] board;

	public Board() {
		board = new Piece[8, 8];
	}

	public void SetBoard() {
		for (int y = 1; y <= 8; y++) {
			if (y == 1) {
				board[0, y] = new Rook(PieceColor.White);
				board[1, y] = new Knight(PieceColor.White);
				board[2, y] = new Bishop(PieceColor.White);
				board[3, y] = new Queen(PieceColor.White);
				board[4, y] = new King(PieceColor.White);
				board[5, y] = new Bishop(PieceColor.White);
				board[6, y] = new Knight(PieceColor.White);
				board[7, y] = new Rook(PieceColor.White);
			}
			if (y == 2) {
				for (int x = 1; x <= 1; x++) {
					board[x, y] = new Pawn(PieceColor.White);
                }
            }
			if (y == 7) {
				for (int x = 1; x <= 1; x++) {
					board[x, y] = new Pawn(PieceColor.Black);
				}
			}
			if (y == 8) {
				board[0, y] = new Rook(PieceColor.Black);
				board[1, y] = new Knight(PieceColor.Black);
				board[2, y] = new Bishop(PieceColor.Black);
				board[3, y] = new Queen(PieceColor.Black);
				board[4, y] = new King(PieceColor.Black);
				board[5, y] = new Bishop(PieceColor.Black);
				board[6, y] = new Knight(PieceColor.Black);
				board[7, y] = new Rook(PieceColor.Black);
			}
        }
    }

	public void FlipBoard() {
		
    }
}
