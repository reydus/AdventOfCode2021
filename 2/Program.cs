namespace AdventCalendar2
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

            var HorizontalPos= 0;
            var DepthPos = 0;

            for (int index = 0; index <= InputList.Count - 1; index++) {
                string[] CurrentCommand = InputList[index].Split(" ");

                int flag = 0;
                Console.WriteLine($"Moving {CurrentCommand[0]} by a quantity of {CurrentCommand[1]}");
                if (CurrentCommand[0] == "forward") {
                    
                    HorizontalPos = HorizontalPos + int.Parse(CurrentCommand[1]);
                    flag = 1;
                }
                if (CurrentCommand[0] == "up") {
                    DepthPos = DepthPos - int.Parse(CurrentCommand[1]);
                    flag = 1;
                }
                if (CurrentCommand[0] == "down") {
                    DepthPos = DepthPos + int.Parse(CurrentCommand[1]);
                    flag = 1;
                }
                if (flag == 0) {
                    Console.WriteLine("WARNING: Did not understand command "+CurrentCommand[0]);
                }

            }

            Console.WriteLine($"Total depth is {DepthPos} and total forward position is {HorizontalPos}, the multiplication of these two is {DepthPos * HorizontalPos}");
            Console.WriteLine("----------- PART TWO");

            // I will re-use these variables, don't mind me.
            HorizontalPos= 0;
            DepthPos = 0;
            var currentAim = 0;

            for (int index = 0; index <= InputList.Count - 1; index++) {
                string[] CurrentCommand = InputList[index].Split(" ");

                if (CurrentCommand[0] == "up") {
                    currentAim = currentAim - int.Parse(CurrentCommand[1]);
                }
                if (CurrentCommand[0] == "down") {
                    currentAim = currentAim + int.Parse(CurrentCommand[1]);
                }
                if (CurrentCommand[0] == "forward") {
                    HorizontalPos = HorizontalPos + int.Parse(CurrentCommand[1]);
                    DepthPos = DepthPos + int.Parse(CurrentCommand[1]) * currentAim;
                }
            }

            Console.WriteLine($"Total depth is {DepthPos} and total forward position is {HorizontalPos}, the multiplication of these two is {DepthPos * HorizontalPos}");

        }
    }
}