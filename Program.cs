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
        PieceColor toPlay = PieceColor.White;
        bool gameEnded = false;

        sampleBoard.PopulateAttackingLists();
        sampleBoard.PopulateLegalMoveLists();

        while (!gameEnded) {
            display = sampleBoard.BoardDisplay();
            Console.WriteLine(display);

            input = Turn.GetInput();
            orig = Turn.ParseInput(input.orig);
            dest = Turn.ParseInput(input.dest);

            pieceToMove = sampleBoard.GetPieceAt(orig);
            if (pieceToMove == null) {
                Console.WriteLine("There is no piece at that location.");
                success = false;
            }
            else if (pieceToMove.color != toPlay) {
                Console.WriteLine("It's the other player's turn!");
                success = false;
            }
            else {
                success = pieceToMove.MovePiece(dest);
            }
            if (!success) {
                Console.WriteLine("Move is illegal. Please enter a legal move.");
            }
            else {
                toPlay = toPlay == PieceColor.White ? PieceColor.Black : PieceColor.White;
                if (sampleBoard.OutOfMoves(toPlay)) {
                    King king = (King)sampleBoard.GetPiece(PieceType.King, toPlay);
                    if (king.InCheck())
                        Console.WriteLine("Checkmate");
                    else
                        Console.WriteLine("Stalemate");
                    gameEnded = true;
                }
            }
        }

        Console.ReadLine();
    }
}