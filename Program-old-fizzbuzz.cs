namespace HelloWorldold
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What number do you want to FizzBuzz?");
            int nu = int.Parse(Console.ReadLine()); 

            for (int index = 1; index <= nu; index++) {
                string result = "";

/*                 if (index % 3 == 0)  {
                    result = result + "Fizz";
                }; */

                if (IsDivisibleByThree(index)) {
                    result = result + "Fizz";
                }
/* 
                if (index % 5 == 0)  {
                    result = result + "Buzz";
                }; */

                if (IsDivisibleByFive(index)) {
                    result = result + "Buzz";
                }

                if (result.Length == 0) {
                    result = index.ToString();
                };


                Console.WriteLine($"{Environment.NewLine}{result}");
            }

            bool IsDivisibleByThree(int number) {
                if (number % 3 == 0) {
                    return true;
                } else{
                    return false;
                }
            }

            bool IsDivisibleByFive(int number) {
                if (number % 5 == 0) {
                    return true;
                } else{
                    return false;
                }
            }
        }
    }
}