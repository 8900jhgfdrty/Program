using System;
using System.Linq;
namespace SnowballFight
{
    class Program
    {
        static void Main(string[] args)
        {
//            //
//<lu Yingjie>, <AF35AN>
//This solution was prepared and submitted by the student stated above for the 
//assignment of the Programming course. I declare that this solution is my own 
//work. I have not copied or used third party solutions. I have not passed my 
//solution to my classmates, neither made it public.
//Students’ regulation of Eötvös Loránd University (ELTE Regulations Vol. II. 
//74/C.§) states that as long as a student presents another student’s work -
//or at least the significant part of it - as his/her own performance, it will 
//count as a disciplinary fault. The most serious consequence of a disciplinary 
//fault can be dismissal of the student from the University.
////
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
                numRounds40Snowballs += participants[i].Count(x => x == 40);
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
