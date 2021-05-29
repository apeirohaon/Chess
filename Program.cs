public class Program {
    static public void Main() {
        /* Board sampleBoard = new Board();
        sampleBoard.SetBoard();
        System.Console.WriteLine(sampleBoard.BoardDisplay()); */

        Board sampleBoard = new Board();
        sampleBoard.SetBoard();
        while (!sampleBoard.GameEnded) {
            Turn.GetInput()
        }
    }
}