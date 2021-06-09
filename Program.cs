using System;

public class Program {
    static public void Main() {
        Board sampleBoard = new Board();
        sampleBoard.SetBoard();
        (string orig, string dest) input;

        Square orig;
        Square dest;
        string display;
        bool success;
        Piece pieceToMove;

        while (!sampleBoard.GameEnded) {
            Turn.PopulateLists(sampleBoard);

            display = sampleBoard.BoardDisplay();
            Console.WriteLine(display);

            input = Turn.GetInput();
            orig = Turn.ParseInput(input.orig);
            dest = Turn.ParseInput(input.dest);

            pieceToMove = sampleBoard.GetPiece(orig);

            success = pieceToMove.MovePiece(orig, dest);

            if (!success) {
                Console.WriteLine("Move is illegal. Please enter a legal move.");
            }
        }
    }
}