namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string line;
            // int[] InputArray;
            List<int> InputList = new List<int>();

            
            while ((line = sr.ReadLine()) != null) {
                Console.WriteLine(line);
                InputList.Add(int.Parse(line));

            }

            ListDecreasesAndIncreases(InputList);


            int ListDecreasesAndIncreases(List<int> InputList) {
                var Increases = 0;
                var  Decreases = 0;

                for (int index = 1; index <= InputList.Count - 1; index++) {
                    if (InputList[index] - InputList[index-1] > 0) {
                        Increases++;
                    }
                    if (InputList[index] - InputList[index-1] < 0) {
                        Decreases = Decreases + 1;
                    }
                }
                Console.WriteLine($"There were {Increases} increases and {Decreases} decreases");
                return Increases;
            }



            Console.WriteLine("\n---------------- Now calculating 3-measurement sliding windows");
            List<int> ThreeWindowSum = new List<int>();
            int MaxCount = InputList.Count - 1;

            int GroupsOfThree = InputList.Count - (InputList.Count % 3);

            for (int index = 0; index+2 <= MaxCount; index++) {
                ThreeWindowSum.Add(InputList[index] + InputList[index+1] + InputList[index+2]);
            }

            ListDecreasesAndIncreases(ThreeWindowSum);
            
        }



    }
}
