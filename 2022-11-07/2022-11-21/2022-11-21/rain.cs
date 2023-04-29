namespace rain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give the number of the weeks!");
            int weeksLength = Convert.ToInt32(Console.ReadLine());
            int[,] data = new int[weeksLength, 7];
            data = readData(weeksLength);
            //printData(data);

            //TaskA
            int[] arrTaskA = new int[weeksLength];
            arrTaskA = taskA(weeksLength, data);
            for (int i = 0; i < arrTaskA.Length; i++)
                Console.Write(arrTaskA[i] + " ");

            //TaskB
            Console.WriteLine("\n" + taskB(weeksLength, arrTaskA));

            //TaskC
            List<int> listTaskC = new List<int>();
            listTaskC = taskC(weeksLength, data);
            Console.Write(listTaskC.Count);
            for (int i = 0; i < listTaskC.Count; i++)
                Console.Write(" " + listTaskC[i]);

            //TaskD
            Console.WriteLine("\n" + taskD(weeksLength, data));

            //TaskE
            int[] arrTaskE = new int[2];
            arrTaskE = taskE(weeksLength, arrTaskA);
            Console.WriteLine(arrTaskE[0] + " " + arrTaskE[1]);
        }

        public static int[,] readData(int length)
        {
            int[,] dataIn = new int[length, 7];
            for (int i = 0; i < length; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < 7; j++)
                    dataIn[i, j] = Convert.ToInt32(input.Split(" ")[j]);
            }
            return dataIn;
        }

        public static void printData(int[,] data)
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < 7; j++)
                    Console.Write(data[i, j] + " ");
                Console.WriteLine();
            }

        }

        //give the amount of rain for each week
        public static int[] taskA(int length, int[,] data)
        {
            int[] result = new int[length];
            for (int i = 0; i < length; i++)
            {
                int sum = 0;
                for(int j = 0; j < 7; j++) { 
                    sum += data[i, j];
                }
                result[i] = sum;
        }
            return result;
        }
        //give the week on which the most rain fell
        public static int taskB(int length, int[] dataFromTaskA)
        {
            int maxHelperInd = 0;
            for (int i = 0; i < length; i++)
            {
                if (dataFromTaskA[i] > dataFromTaskA[maxHelperInd])
                    maxHelperInd = i;
            }
            return maxHelperInd+1;
        }

        //give the list of those weeks when the amount of rain was increasing day by day
        public static List<int> taskC(int length, int[,] data)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < length; i++)
            {
                bool isIncreasing = true;
                for (int j = 0; j < 7 - 1; j++)
                {
                    if (data[i, j] >= data[i, j + 1])
                        isIncreasing = false;
                }
                if (isIncreasing)
                    result.Add(i+1);
            }
            return result;
        }

        //give that N/2 long period when rain fell the least count of days
        public static int taskD(int length, int[,] data)
        {
            int[] cntOfRain = new int[length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 7; j++) 
                { 
                    if (data[i,j] > 0)
                    { 
                        cntOfRain[i]++;//{7 1 2 6 4 0}
                    }
                }
            }
            int sumMin = 0;
            int minInd = 0;
            for (int i = 0; i < length / 2; i++)
            {
                sumMin += cntOfRain[i];
            }
            for (int i = 1; i < length/2+1; i++)
            {
                int sumOther = 0;
                for (int j = i; j < length/2+i; j++)
                {
                    sumOther += cntOfRain[j];
                }
                if (sumMin > sumOther)
                {
                    sumMin = sumOther;
                    minInd = i+1;
                }
            }
            return minInd;
        }

        //give the longest period of weeks when the amount of rain during a week was at most 10mm
        public static int[] taskE(int length, int[] dataFromTaskA)
        {
            int[] longestPeriod = new int[2];
            int cntMax = 0;
            for (int i = 0; i < length/2+1; i++)
            {
                if (dataFromTaskA[i] < 10)
                {
                    int cnt = 0;
                    bool exit = true;
                    for (int j = i; j < length && exit; j++)
                    {
                        if (dataFromTaskA[j] < 10)
                        {
                            cnt++;
                        }
                        else
                        {
                            exit = false;
                        }
                    }
                    if (cntMax < cnt)
                    {
                        cntMax = cnt;
                        longestPeriod[0] = i + 1;
                        longestPeriod[1] = i + cnt + 1;
                    }
                }
                    
            }
            return longestPeriod;
        }

    }
}