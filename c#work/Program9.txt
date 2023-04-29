namespace program9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Enter three words:");
            string words=Console.ReadLine();
            string word1 = words.Split(' ')[0];
            string word2 = words.Split(' ')[1];
            string word3 = words.Split(' ')[2];
            if (word1.Length> word2.Length && word1.Length > word3.Length)
            {
                Console.WriteLine("The longest word is:{word1}");
            }
            else if (word2.Length > word1.Length && word2.Length > word3.Length)
            {
                Console.WriteLine("The longest word is:{ word2}");
            }
            else if (word3.Length > word1.Length && word3.Length > word2.Length)
            {
                Console.WriteLine("The longest word is:{ word3}");
            }
            Console.ReadKey();
        }

    }
}