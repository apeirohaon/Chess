using System;

public class Turn {
    public static (string start, string end) GetInput() {
        string start, end;
        Console.WriteLine("ENTER THE CURRENT LOCATION OF THE PIECE YOU ARE MOVING: ");
        start = Console.ReadLine();
        Console.WriteLine("ENTER THE DESTINATION LOCATION OF THE PIECE YOU ARE MOVING: ");
        end = Console.ReadLine();

        return (start, end);
    }

    public static Square ParseInput(string rawString) {
        string row = rawString.Substring(1, 1);
        string col = rawString.Substring(0, 1);
        int colNum;
        int rowNum;
        Square square;

        switch (col) {
            case "a":
                colNum = 0;
                break;
            case "b":
                colNum = 1;
                break;
            case "c":
                colNum = 2;
                break;
            case "d":
                colNum = 3;
                break;
            case "e":
                colNum = 4;
                break;
            case "f":
                colNum = 5;
                break;
            case "g":
                colNum = 6;
                break;
            case "h":
                colNum = 7;
                break;
            default:
                throw new InvalidOperationException("Column letter not in range.");
        }

        rowNum = Int32.Parse(row);

        square.X = colNum;
        square.Y = rowNum;

        return square;
    }


}
