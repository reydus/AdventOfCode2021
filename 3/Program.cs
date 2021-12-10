namespace AdventCalendar3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] OrganiseByTrend(int[] numbers) {

                // var l1 = new List<int>() { 1,2,3,4,5,2,2,2,4,4,4,1 };

                var g = numbers.GroupBy( i => i ).OrderByDescending(g => g.Count());
                int[][] incidences = new int[2][];
                for (int m = 0 ; m <= incidences.Count()-1; m++) {
                    incidences[m] = new int[2];
                }
                int indexer = 0;

                foreach( var grp in g )
                {
                incidences[indexer][0] = grp.Key;
                incidences[indexer][1] = grp.Count();
                indexer++;
                //Console.WriteLine( "{0} {1}", grp.Key, grp.Count() );
                }
                return incidences;

            }

            StreamReader sr = new StreamReader("input.txt");
            string line;
            // int[] InputArray;
            List<string> InputList = new List<string>();

            
            while ((line = sr.ReadLine()) != null) {
                //Console.WriteLine(line);
                InputList.Add((line));

            }
            // Idea, do all of this directly in binary operations to make it more efficient?

            string GammaRate = "";
            
            int[] column = new int[InputList.Count];

            for (int i = 0; i <= InputList.Count - 1; i++){
                for (int j =  0; j <= InputList[i].Length - 1; j++) {
                    
                }
            }

            for (int i =  0; i <= InputList[i].Length - 1; i++) {
                int mode = 0;
                for (int j = 0; j <= InputList.Count -1; j++) {
                    column[j] = InputList[j][i] - 48; // ASCII offset                 
                }

                var tendencies = OrganiseByTrend(column);
                if (tendencies[0][1] == tendencies[1][1]) {
                    Console.WriteLine("Warning: No concrete mode was found!");
                } else {
                    mode = tendencies[0][0];
                }

/*                 Console.WriteLine(tendencies);


                var trends = column.GroupBy(v => v)
                    .OrderByDescending(g => g.Count());

                int mode = column.GroupBy(v => v)
                    .OrderByDescending(g => g.Count()).First().Key;  */
                Console.WriteLine($"Bit for column no {i} is {mode}");
                GammaRate = GammaRate + mode.ToString();
            }

            int GammaRateDec = Convert.ToInt32(GammaRate, 2);
            int EpsilonRateDec = ~Convert.ToInt32(GammaRate, 2) & 0x00000FFF; // INVERT WHOLE 32-BIT INTEGER, CUT TO THE LAST 12 BITS. BINARY MAGIC. (0x00000FFF)
            Console.WriteLine($"Gamma Rate is {GammaRateDec} and epsilon rate {EpsilonRateDec}, its multiplication is {GammaRateDec * EpsilonRateDec}");
        
            Console.WriteLine("-------- PART TWO");

            List<string> PassingList = new List<string>();

            int Flag = 0;
            int CurrentIndex = 0;
            Array.Clear(column);

            while (Flag == 0) {
                    if (CurrentIndex > 0){
                        InputList.Clear();
                        InputList = new List<string>(PassingList);
                        PassingList.Clear();
                    }
                    //Array.Clear(tendencies);

                    for (int j = 0; j <= InputList.Count -1; j++) {
                        column[j] = InputList[j][CurrentIndex] - 48; // ASCII offset                 
                    }
                    int mode = 1; // IF NO MODE, USE 1.

                    var tendencies = OrganiseByTrend(column);
                    if (tendencies[0][1] == tendencies[1][1]) {
                        Console.WriteLine("Warning: No concrete mode was found!");
                    } else {
                        mode = tendencies[0][0];
                    }                    
/*                     int mode = column.GroupBy(v => v)
                        .OrderByDescending(g => g.Count())
                        .First()
                        .Key; */
                    Console.WriteLine($"Mode bit for column no {CurrentIndex} is {mode}");

                    for (int i = 0; i <= InputList.Count-1; i++) {
                        if (InputList[i][CurrentIndex]-48 == mode) {
                            PassingList.Add(InputList[i]);
                        }
                    }
                    CurrentIndex++;
                    if (PassingList.Count() == 1) {
                        Flag = 1;
                    }
                    Array.Clear(tendencies);
                    column = new int[PassingList.Count()];
            }

            string OxygenGeneratorRating = PassingList[0];
            int DecOxygenGeneratorRating = Convert.ToInt32(OxygenGeneratorRating, 2);
            Console.WriteLine("The Oxygen generator rating is rate with the mode is "+OxygenGeneratorRating+" or "+DecOxygenGeneratorRating+" in decimal.");


            // Restore input, since I am not working with functions here, the original got trimmed heavily.
            sr = new StreamReader("input.txt");
            line = "";
            InputList = new List<string>();

            
            while ((line = sr.ReadLine()) != null) {
                //Console.WriteLine(line);
                InputList.Add((line));

            }

            PassingList = new List<string>();

            Flag = 0;
            CurrentIndex = 0;
            column = new int[InputList.Count()];

            while (Flag == 0) {
                    if (CurrentIndex > 0){
                        InputList.Clear();
                        InputList = new List<string>(PassingList);
                        PassingList.Clear();
                    }
                    //Array.Clear(tendencies);

                    for (int j = 0; j <= InputList.Count -1; j++) {
                        column[j] = InputList[j][CurrentIndex] - 48; // ASCII offset                 
                    }
                    int mode = 0; // IF NO MODE, USE 0.

                    var tendencies = OrganiseByTrend(column);
                    if (tendencies[tendencies.Count()-1][1] == tendencies[tendencies.Count()-2][1]) {
                        Console.WriteLine("Warning: No concrete mode was found!");
                    } else {
                        mode = tendencies[tendencies.Count()-1][0];
                    }                    
/*                     int mode = column.GroupBy(v => v)
                        .OrderByDescending(g => g.Count())
                        .First()
                        .Key; */
                    Console.WriteLine($"Mode bit for column no {CurrentIndex} is {mode}");

                    for (int i = 0; i <= InputList.Count-1; i++) {
                        if (InputList[i][CurrentIndex]-48 == mode) {
                            PassingList.Add(InputList[i]);
                        }
                    }
                    CurrentIndex++;
                    if (PassingList.Count() == 1) {
                        Flag = 1;
                    }
                    Array.Clear(tendencies);
                    column = new int[PassingList.Count()];
            }

            string CO2ScrubberRating = PassingList[0];
            int DecCO2ScrubberRating = Convert.ToInt32(CO2ScrubberRating, 2);
            Console.WriteLine("The CO2 Scrubber rate with the mode is "+CO2ScrubberRating+" or "+DecCO2ScrubberRating+" in decimal.");
            Console.WriteLine("The total multiplication is "+(DecCO2ScrubberRating*DecOxygenGeneratorRating));
            
        }
    }
}
