using System;
using System.Collections.Generic;

public class Board {
	private Piece[,] board;
	public List<Piece> PieceList = new List<Piece>();

	public Board() {
		board = new Piece[9, 9];
	}

	public void SetBoard() {
		for (int y = 1; y <= 8; y++) {
			if (y == 1) {
				board[1, y] = new Rook(this, PieceColor.White, 1, y);
				board[2, y] = new Knight(this, PieceColor.White, 2, y);
				board[3, y] = new Bishop(this, PieceColor.White, 3, y);
				board[4, y] = new Queen(this, PieceColor.White, 4, y);
				board[5, y] = new King(this, PieceColor.White, 5, y);
				board[6, y] = new Bishop(this, PieceColor.White, 6, y);
				board[7, y] = new Knight(this, PieceColor.White, 7, y);
				board[8, y] = new Rook(this, PieceColor.White, 8, y);
			}
			if (y == 2) {
				for (int x = 1; x <= 8; x++) {
					board[x, y] = new Pawn(this, PieceColor.White, x, y);
				}
			}
			if (y == 7) {
				for (int x = 1; x <= 8; x++) {
					board[x, y] = new Pawn(this, PieceColor.Black, x, y);
				}
			}
			if (y == 8) {
				board[1, y] = new Rook(this, PieceColor.Black, 1, y);
				board[2, y] = new Knight(this, PieceColor.Black, 2, y);
				board[3, y] = new Bishop(this, PieceColor.Black, 3, y);
				board[4, y] = new Queen(this, PieceColor.Black, 4, y);
				board[5, y] = new King(this, PieceColor.Black, 5, y);
				board[6, y] = new Bishop(this, PieceColor.Black, 6, y);
				board[7, y] = new Knight(this, PieceColor.Black, 7, y);
				board[8, y] = new Rook(this, PieceColor.Black, 8, y);
			}
		}
		this.RefreshPiecesList();
	}

	public Board CopyBoard() {
		return (Board)this.MemberwiseClone();
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

	public Piece GetPiece(PieceType type, PieceColor color) {
		for (int x = 0; x <= 8; x++) {
			for (int y = 0; y <= 8; y++) {
				Square testSq = new Square(x, y);
				Piece piece = GetPieceAt(testSq);
				if (piece != null)
					if (piece.type == type && piece.color == color)
						return piece;
			}
		}
		return null;
	}

	public Piece GetPieceAt(Square sq) {
		return board[sq.X, sq.Y];
	}

	public void SetPieceAt(Square sq, Piece piece) {
		board[sq.X, sq.Y] = piece;
		PieceList.Add(piece);
	}

	public void RemovePieceAt(Square sq) {
		Piece x = this.GetPieceAt(sq);
		if (!PieceList.Remove(this.GetPieceAt(sq)))
			Console.WriteLine("err");
		board[sq.X, sq.Y] = null;
	}

	public void PopulateLegalMoveLists() {
		Piece currentPiece;
		Square currentSquare;
		for (int i = 1; i <= 8; i++) {
			currentSquare.X = i;
			for (int j = 1; j <= 8; j++) {
				currentSquare.Y = j;
				currentPiece = this.GetPieceAt(currentSquare);

				if (currentPiece != null)
					currentPiece.PopulateLegalMoves();
			}
		}
	}

	public void PopulateAttackingLists() {
		Piece currentPiece;
		Square currentSquare;
		for (int i = 1; i <= 8; i++) {
			currentSquare.X = i;
			for (int j = 1; j <= 8; j++) {
				currentSquare.Y = j;
				currentPiece = this.GetPieceAt(currentSquare);

				if (currentPiece != null)
					currentPiece.PopulateSquaresAttacking();
			}
		}
	}

	public void PopulateLists() {
		this.PopulateLegalMoveLists();
		this.PopulateAttackingLists();
	}

	public bool OutOfMoves(PieceColor c) {
		PieceList.RemoveAll(item => item == null);
		foreach (Piece p in PieceList) {
			if (p.color == c && p.legalMoveList.Count > 0)
				return false;
		}
		return true;
	}

	public string BoardDisplay() {
		string display = "";
		for (int y = 8; y >= 1; y--) {
			for (int x = 1; x <= 8; x++) {
				if (board[x, y] is Piece)
					display += board[x, y].ToString();
				else display += "_";
				display += " ";
			}
			display += "\n";
		}
		return display;
	}

	private void RefreshPiecesList() {
		PieceList = new List<Piece>();
		Piece currentPiece;
		Square currentSquare;
		for (int i = 1; i <= 8; i++) {
			currentSquare.X = i;
			for (int j = 1; j <= 8; j++) {
				currentSquare.Y = j;
				currentPiece = this.GetPieceAt(currentSquare);

				if (currentPiece != null)
					PieceList.Add(currentPiece);
			}
		}
	}
}
