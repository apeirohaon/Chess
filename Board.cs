using System;

public class Board {
	private Piece[,] board;
	public bool GameEnded;

	public Board() {
		board = new Piece[8, 8];
	}

	public void SetBoard() {
		for (int y = 0; y < 8; y++) {
			if (y == 0) {
				board[0, y] = new Rook(PieceColor.White);
				board[1, y] = new Knight(PieceColor.White);
				board[2, y] = new Bishop(PieceColor.White);
				board[3, y] = new Queen(PieceColor.White);
				board[4, y] = new King(PieceColor.White, this);
				board[5, y] = new Bishop(PieceColor.White);
				board[6, y] = new Knight(PieceColor.White);
				board[7, y] = new Rook(PieceColor.White);
			}
			if (y == 1) {
				for (int x = 0; x < 8; x++) {
					board[x, y] = new Pawn(PieceColor.White);
                }
            }
			if (y == 6) {
				for (int x = 0; x < 8; x++) {
					board[x, y] = new Pawn(PieceColor.Black);
				}
			}
			if (y == 7) {
				board[0, y] = new Rook(PieceColor.Black);
				board[1, y] = new Knight(PieceColor.Black);
				board[2, y] = new Bishop(PieceColor.Black);
				board[3, y] = new Queen(PieceColor.Black);
				board[4, y] = new King(PieceColor.Black, this);
				board[5, y] = new Bishop(PieceColor.Black);
				board[6, y] = new Knight(PieceColor.Black);
				board[7, y] = new Rook(PieceColor.Black);
			}
        }
    }

	public bool IsPopulated(int x, int y) {
		bool pop = (board[x, y] is King ||
					board[x, y] is Queen ||
					board[x, y] is Rook ||
					board[x, y] is Bishop ||
					board[x, y] is Knight ||
					board[x, y] is Pawn
					);
		return pop;
    }

	public Piece GetPiece(int x, int y) {
		return board[x, y];
    }

	public string BoardDisplay() {
		string display = "";
		for (int y = 7; y >= 0; y--) {
			for (int x = 0; x < 8; x++) {
				if (board[x, y] is Piece) display += board[x, y].ToString();
				else display += "_";
				display += " ";
			}
			display += "\n";
        }
		return display;
    }

	public void FlipBoard() {
		
    }
}
