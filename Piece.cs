using System;

enum PieceColor {
	Black,
	White
}

public struct Square {
	public readonly int X Y;

	public Square(int x, int y) {
		this.X = x;
		this.Y = y;
	}
}

public abstract class Piece {
	Square Square = new Square;

	public void Piece() {
	}
}
