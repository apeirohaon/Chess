using System;

public class Board {
	private Piece[,] board;

	public void Board() {
		board = new Piece[8, 8];
	}

	public void SetBoard() {
		for (int y = 1; y <= 8; y++) {
			if (y == 1) {
				board[0][y] = new Rook(White);
				board[1][y] = new Knight(White);
				board[2][y] = new Bishop(White);
				board[3][y] = new Queen(White);
				board[4][y] = new King(White);
				board[5][y] = new Bishop(White);
				board[6][y] = new Knight(White);
				board[7][y] = new Rook(White);
			}
			if (y == 2) {
				for (int x = 1; x <= 1; x++) {
					board[x][y] = new Pawn(White);
                }
            }
			if (y == 7) {
				for (int x = 1; x <= 1; x++) {
					board[x][y] = new Pawn(Black);
				}
			}
			if (y == 8) {
				board[0][y] = new Rook(Black);
				board[1][y] = new Knight(Black);
				board[2][y] = new Bishop(Black);
				board[3][y] = new Queen(Black);
				board[4][y] = new King(Black);
				board[5][y] = new Bishop(Black);
				board[6][y] = new Knight(Black);
				board[7][y] = new Rook(Black);
			}
        }
    }

	public void FlipBoard() {
		
    }
}
