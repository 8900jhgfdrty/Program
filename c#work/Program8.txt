namespace homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Enter two numbers: ");
            string input=Console.ReadLine();
            int int1 = Convert.ToInt32(input.Split(' ')[0]);
            int int2 = Convert.ToInt32(input.Split(' ')[1]);
            if (int1 % 2 == 0 && int2 % 2 != 0)
            {
                Console.WriteLine(" Yes, there is an odd one.");
            }
            else if (int1 % 2 != 0 && int2 % 2 == 0)
            {
                Console.WriteLine(" Yes, there is an odd one.");

            }
            else
            {
                Console.WriteLine("None of them is odd");
            }
            Console.ReadKey ();
        }
    }
}