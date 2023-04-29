using System;
using System.Linq;

namespace SnowballFight
{
    class Program
    {
        static void Main(string[] args)
        {
        
            string[] input = Console.ReadLine().Split();
            int numParticipants = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            int[][] participants = new int[numParticipants][];
            for (int i = 0; i < numParticipants; i++)
            {
                participants[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }


            int numRounds40Snowballs = 0;
            for (int i = 0; i < numParticipants; i++)
            {
                if (participants[i].Sum() == 40)
                    numRounds40Snowballs++;
            }
            Console.WriteLine(numRounds40Snowballs);


            int maxSnowballs = 0;
            int maxParticipantIndex = -1;
            for (int i = 0; i < numParticipants; i++)
            {
                int totalSnowballs = participants[i].Sum();
                if (totalSnowballs > maxSnowballs)
                {
                    maxSnowballs = totalSnowballs;
                    maxParticipantIndex = i;
                }
            }
            Console.WriteLine(maxParticipantIndex + 1); 

           
            int numParticipantsOverM = 0;
            for (int i = 0; i < numParticipants; i++)
            {
                int totalSnowballs = participants[i].Sum();
                if (totalSnowballs > m)
                {
                    numParticipantsOverM++;
                }
            }
            Console.Write(numParticipantsOverM + " ");
            for (int i = 0; i < numParticipants; i++)
            {
                int totalSnowballs = participants[i].Sum();
                if (totalSnowballs > m)
                {
                    Console.Write(i + 1 + " "); 
                }
            }
            Console.WriteLine();

            
            bool someoneThrewLess = false;
            for (int i = 0; i < numParticipants; i++)
            {
                int minSnowballs = participants[i].Min();
                for (int j = 0; j < numParticipants; j++)
                {
                    if (i == j) continue; 
                    if (minSnowballs > participants[j].Min())
                    {
                        someoneThrewLess = true;
                        break;
                    }
                }
                if (someoneThrewLess) break;
            }
            Console.WriteLine(someoneThrewLess ? "YES" : "NO");
        }
    }
}
