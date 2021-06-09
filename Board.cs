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
				board[0, y] = new Rook(this, PieceColor.White, 0, y);
				board[1, y] = new Knight(this, PieceColor.White, 1, y);
				board[2, y] = new Bishop(this, PieceColor.White, 2, y);
				board[3, y] = new Queen(this, PieceColor.White, 3, y);
				board[4, y] = new King(this, PieceColor.White, 4, y);
				board[5, y] = new Bishop(this, PieceColor.White, 5, y);
				board[6, y] = new Knight(this, PieceColor.White, 6, y);
				board[7, y] = new Rook(this, PieceColor.White, 7, y);
			}
			if (y == 1) {
				for (int x = 0; x < 8; x++) {
					board[x, y] = new Pawn(this, PieceColor.White, x, y);
                }
            }
			if (y == 6) {
				for (int x = 0; x < 8; x++) {
					board[x, y] = new Pawn(this, PieceColor.Black, x, y);
				}
			}
			if (y == 7) {
				board[0, y] = new Rook(this, PieceColor.Black, 0, y);
				board[1, y] = new Knight(this, PieceColor.Black, 1, y);
				board[2, y] = new Bishop(this, PieceColor.Black, 2, y);
				board[3, y] = new Queen(this, PieceColor.Black, 3, y);
				board[4, y] = new King(this, PieceColor.Black, 4, y);
				board[5, y] = new Bishop(this, PieceColor.Black, 5, y);
				board[6, y] = new Knight(this, PieceColor.Black, 6, y);
				board[7, y] = new Rook(this, PieceColor.Black, 7, y);
			}
        }
    }

	public bool IsPopulated(Square sq) {
		int x = sq.X;
		int y = sq.Y;
		bool pop = (board[x, y] is King ||
					board[x, y] is Queen ||
					board[x, y] is Rook ||
					board[x, y] is Bishop ||
					board[x, y] is Knight ||
					board[x, y] is Pawn
					);
		return pop;
    }

	public Piece GetPiece(Square sq) {
		return board[sq.X, sq.Y];
    }

	public void SetPiece(Square sq, Piece piece) {
		board[sq.X, sq.Y] = piece;
    }

	public void RemovePiece(Square sq) {
		board[sq.X, sq.Y] = null;
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
