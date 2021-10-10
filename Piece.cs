using System;
using System.Collections.Generic;

public enum PieceColor {
	Black,
    White
}

public enum PieceType {
	King,
	Queen,
	Rook,
	Bishop,
	Knight,
	Pawn
}

public enum IllegalMoves {
	Illegal,
	Obstruction,
	Check
}

public struct Square {
    public int X, Y;

    public Square(int x, int y) {
        this.X = x;
        this.Y = y;
    }

    public override string ToString() {
		return $"{X}, {Y}";
    }

    public override bool Equals(object obj) {
		if (!(obj is Square))
			return false;

		Square sq = (Square) obj;
		return (this.X == sq.X) && (this.Y == sq.Y);
    }

    public override int GetHashCode() {
		return X ^ Y;
    }
}

public abstract class Piece {
	protected char CharWhite;
	protected char CharBlack;
	public PieceColor color;
	public PieceType type;
	protected Board containingBoard;
	protected Square square = new Square();
	public List<Square> legalMoveList = new List<Square>();
	protected List<Square> squaresAttacking = new List<Square>();

	public Piece(Board board, PieceColor color, int xcoord, int ycoord) {
		this.color = color;
		containingBoard = board;
		square.X = xcoord;
		square.Y = ycoord;
	}

    public override string ToString() {
		return char.ToString(color == PieceColor.White ? CharWhite : CharBlack);
    }

	public bool MovePiece(Square dest) {
		if (!legalMoveList.Contains(dest))
			return false;
		containingBoard.RemovePieceAt(this.square);
		square = new Square(dest.X, dest.Y);
		containingBoard.SetPieceAt(dest, this);
		containingBoard.PopulateLists();
		return true;
    }

	public bool IsAttacking(Square sq) {
		return IsValid(sq) && !IsObstructed(sq);
    }

	public void PopulateLegalMoves() {
		legalMoveList = new List<Square>();
		Square testingSquare = new Square(-1, -1);
		for (int y = 1; y <= 8; y++) {
			testingSquare.Y = y;
			for (int x = 1; x <= 8; x++) {
				testingSquare.X = x;
				if (IsLegal(testingSquare))
					legalMoveList.Add(testingSquare);
            }
        }
    }

	public void PopulateSquaresAttacking() {
		foreach (Square sq in legalMoveList) {
			if (containingBoard.IsPopulated(sq) && (containingBoard.GetPieceAt(sq).color != this.color))
				squaresAttacking.Add(sq);
        }
    }

	public bool IsLegal(Square move) {
		if (IsValid(move))
			return (!IsObstructed(move) && !CreatesCheck(move));
		return false;
    }

	protected virtual bool IsObstructed(Square move) {
		return false;
    }

	protected virtual bool IsValid(Square move) {
		return false;
    }

	protected bool CreatesCheck(Square move) {
		bool createsCheck = false;

		Piece replacedPiece = containingBoard.GetPieceAt(move);
		containingBoard.RemovePieceAt(square);
		containingBoard.SetPieceAt(move, this);
		King king = (King) containingBoard.GetPiece(PieceType.King, this.color);
		if (king.InCheck())
			createsCheck = true;
		containingBoard.RemovePieceAt(move);
		containingBoard.SetPieceAt(square, this);
		containingBoard.SetPieceAt(move, replacedPiece);

		return createsCheck;
	}
}
