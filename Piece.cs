using System;

public enum PieceColor {
	Black,
	White
}

public struct Square {
	public readonly int X, Y;

	public Square(int x, int y) {
		this.X = x;
		this.Y = y;
	}
}

public abstract class Piece {
	public PieceColor color;
	protected char CharWhite;
	protected char CharBlack;
	private Square Square = new Square();

	public Piece(PieceColor color) {
		this.color = color;
	}

    public override string ToString() {
		return char.ToString(color == PieceColor.White ? CharWhite : CharBlack);
    }
}
