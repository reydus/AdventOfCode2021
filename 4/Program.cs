namespace AdventCalendar4
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string line;
            // int[] InputArray;
            List<string> InputList = new List<string>();

            
            while ((line = sr.ReadLine()) != null) {
                Console.WriteLine(line);
                InputList.Add((line));

            }

            // First line is numbers being called in order.
            int[] NumberCalls = Array.ConvertAll(InputList[0].Split(","), s => int.Parse(s));


            List<List<int[]>> Boards = new List<List<int[]>>();
            List<int[]> BoardsMatrix = new List<int[]>();

            int CurrentBoard = 0;
            List<int[]> BoardConstructor = new List<int[]>();
            int CurrentRow = 0;

            for (int i = 2; i<=InputList.Count()-1;i++) {

                if (InputList[i] == "") {
                    Boards.Add(new List<int[]>(BoardConstructor));
                    BoardConstructor.Clear();
                    CurrentBoard++;
                }else{
                    BoardConstructor.Add(Array.ConvertAll(InputList[i].Split(new char[0], StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s)));
                }
                if (i+1 == InputList.Count()) {
                    Boards.Add(new List<int[]>(BoardConstructor));
                    BoardConstructor.Clear();
                    CurrentBoard++;
                }
            }
            int[][] BoardCompletions = new int[Boards.Count()][];

            for (int i = 0; i <= Boards.Count()-1; i++) {
                BoardCompletions[i] = new int[3];
            }

            for (int i = 0; i<=Boards.Count()-1; i++) {
                int EarliestCompletionIndex = NumberCalls.Count();
                string CompletionItem = "";
                int IndexOfItem = new int();

                // check for rows
                for (int j= 0; j<=4; j++) {
                    int CompletionOfRow = getCompletition(getRow(Boards[i], j), NumberCalls);
                    if (EarliestCompletionIndex > CompletionOfRow) {
                        EarliestCompletionIndex = CompletionOfRow;
                        CompletionItem = "row";
                        IndexOfItem = j;
                    }

                }

                // check for columns
                for (int k = 0; k<=4; k++){
                    int CompletionOfColumn = getCompletition(getColumn(Boards[i], k), NumberCalls);
                    if (EarliestCompletionIndex > CompletionOfColumn) {
                        EarliestCompletionIndex = CompletionOfColumn;
                        CompletionItem = "column";
                        IndexOfItem = k;
                    }

                }

                int CompletionItemNo = new int();
                if (CompletionItem == "row"){
                    CompletionItemNo = 0;
                }else{
                    CompletionItemNo = 1;
                }
                BoardCompletions[i][0] = EarliestCompletionIndex;
                BoardCompletions[i][1] = CompletionItemNo;
                BoardCompletions[i][2] = IndexOfItem;



                }
                int[] WinningBoard = new int[4];
                WinningBoard[0] = Boards.Count(); // Number of Board
                WinningBoard[1] = 500; // Index at which it won
                WinningBoard[2] = 0; // Row 0 Column 1
                WinningBoard[3] = 0; // Index of row/column

                for (int i = 0; i <= BoardCompletions.Count()-1; i++ ) {
                    if (BoardCompletions[i][0] < WinningBoard[1]) {
                        WinningBoard[0] = i;
                        WinningBoard[1] = BoardCompletions[i][0];
                        WinningBoard[2] = BoardCompletions[i][1];
                        WinningBoard[3] = BoardCompletions[i][2];

                    }
                }

                List<int> NumbersOnBoard = new List<int>();

                for (int i = 0 ; i <= Boards[0].Count()-1 ; i++) {
                    foreach (int number in getRow(Boards[WinningBoard[0]], i)) {
                    NumbersOnBoard.Add(number);
                    }
                }

                for (int i = 0; i <= WinningBoard[1] ; i++) {
                    NumbersOnBoard.Remove(NumberCalls[i]);
                }

                int TotalScore = NumbersOnBoard.Sum() * NumberCalls[WinningBoard[1]];
            
            Console.WriteLine($"Winning board is board number {WinningBoard[0]+1} at the call {NumberCalls[WinningBoard[1]]} with a score of {TotalScore}");

            Console.WriteLine("--------------Part two");

            int[] LosingBoard = new int[4];
            LosingBoard[0] = Boards.Count(); // Number of Board
            LosingBoard[1] = 0; // Index at which it won
            LosingBoard[2] = 0; // Row 0 Column 1
            LosingBoard[3] = 0; // Index of row/column

            for (int i = 0; i <= BoardCompletions.Count()-1; i++ ) {
                if (BoardCompletions[i][0] > LosingBoard[1]) {
                    LosingBoard[0] = i;
                    LosingBoard[1] = BoardCompletions[i][0];
                    LosingBoard[2] = BoardCompletions[i][1];
                    LosingBoard[3] = BoardCompletions[i][2];

                }
            }

            NumbersOnBoard.Clear();

            for (int i = 0 ; i <= Boards[0].Count()-1 ; i++) {
                foreach (int number in getRow(Boards[LosingBoard[0]], i)) {
                NumbersOnBoard.Add(number);
                }
            }

            for (int i = 0; i <= LosingBoard[1] ; i++) {
                NumbersOnBoard.Remove(NumberCalls[i]);
            }

            TotalScore = NumbersOnBoard.Sum() * NumberCalls[LosingBoard[1]];
            Console.WriteLine($"Losing board is board number {LosingBoard[0]+1} at the call {NumberCalls[LosingBoard[1]]} with a score of {TotalScore}");

            int[] getColumn(List<int[]> board, int ColumnIndex) {
                
                int[] Column = new int[5];

                for (int i = 0; i <= board.Count()-1; i++) {
                    Column[i] = board[i][ColumnIndex];
                }
                
                return Column;
            }

            int[] getRow(List<int[]> board, int RowIndex) {
                int[] Row = new int[5];

                for (int i = 0; i<= board[0].Count()-1; i++) {
                    Row[i] = board[RowIndex][i];
                }
                return Row;
            }

            int getCompletition(int[] NumberLine, int[] NumberCalls) {
                int CompletitionIndex = -1;
                int Completed = 0;

                for (int i = 0; i <= NumberCalls.Count()-1 ; i++){
                    if (NumberLine.Contains(NumberCalls[i])) {
                        Completed++;
                    }
                    if (Completed == 5) {
                        CompletitionIndex = i;
                        break;
                    }
                }
                return CompletitionIndex;
            }

        }
    }
}
