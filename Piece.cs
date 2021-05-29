using System;
using System.Collections.Generic;

public enum PieceColor {
	Black,
	White
}

public struct Square {
	public int X, Y;

	public Square(int x, int y) {
		this.X = x;
		this.Y = y;
	}
}

public abstract class Piece {
	protected char CharWhite;
	protected char CharBlack;
	public PieceColor color;
	protected Board containingBoard;
	protected Square square = new Square();
	protected List<Square> legalMoveList = new List<Square>();
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

	public void PopulateLegalMoves() {
		Square testingSquare = new Square(-1, -1);
		for (int y = 0; y < 8; y++) {
			for (int x = 0; x < 8; x++) {
				testingSquare.X = x;
				testingSquare.Y = y;
				if (IsLegal(testingSquare)) legalMoveList.Add(testingSquare);
            }
        }
    }

	public void PopulateSquaresAttacking() {
		foreach (Square sq in legalMoveList) {
			if (containingBoard.IsPopulated(sq.X, sq.Y) && (containingBoard.GetPiece(sq.X, sq.Y).color != this.color)) {
				squaresAttacking.Add(sq);
            }
        }
    }

	public bool IsLegal(Square move) {
		return (IsValid(move) && !IsObstructed(move) && !CreatesCheck(move));
    }

	protected virtual bool IsObstructed(Square move) {
		return false;
    }

	protected virtual bool IsValid(Square move) {
		return false;
    }

	protected virtual bool CreatesCheck(Square move) {
		return false;
    }
}
