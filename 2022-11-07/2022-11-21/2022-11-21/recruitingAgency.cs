namespace recruitingAgency
{
    internal class Program
    {//recruting agency
     // this is a sample structure that contains arrays
        public struct Data
        {
            public int[] salary;
            public int[] month;
            public string[] name;
        }

        public struct TaskB
        {
            public int cnt;
            public string[] name;
            public int[] salary;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            string input = Console.ReadLine();
            int lineLength = Convert.ToInt32(input.Split(' ')[0]);
            int C = Convert.ToInt32(input.Split(' ')[1]);

            // precondition input checking
            while (lineLength < 1 || lineLength > 50 || C < 1 || C > 10)
            {
                Console.WriteLine("Give the count of data and C again, the previous line was wrong!");
                input = Console.ReadLine();
                lineLength = Convert.ToInt32(input.Split(' ')[0]);
                C = Convert.ToInt32(input.Split(' ')[1]);
            }

            Data data = new Data(); //Initializing the Data structure
            data.salary = new int[lineLength]; //setting the length of the array from the Data struct
            data.month = new int[lineLength];
            data.name = new string[lineLength];

            // reads the data from console to the structure with precondition input checking and returns the structure
            data = readData(lineLength, data);

            //prints out the data from the Data structure
            //print(lineLength, data);

            //TaskA
            Console.WriteLine("#\n" + highestIncome(lineLength, data));
            //TaskB
            printTaskB(solveTaskB(lineLength, data));
            //TaskC
            Console.WriteLine("#\n" + solveTaskC(data));
            //TaskD
            List<string> resultD = new List<string>();
            resultD = solveTaskD(C, data);
            Console.WriteLine("#\n" + resultD.Count);
            for (int i = 0; i < resultD.Count; i++)
            {
                Console.WriteLine(resultD[i]);
            }
        }

        // reads the data from console to the structure with precondition input checking and returns the structure
        public static Data readData(int length, Data data)
        {
            for (int i = 0; i < length; i++)
            {
                string input = Console.ReadLine();
                data.salary[i] = Convert.ToInt32(input.Split(' ')[0]);
                data.month[i] = Convert.ToInt32(input.Split(' ')[1]);
                data.name[i] = getNameFromConsole(input);

                while (data.salary[i] < 1 || data.salary[i] > 10 || data.month[i] < 1 || data.name[i].Length < 1)
                {
                    Console.WriteLine("Give the salary, month, and name again, the previous line was wrong!");
                    input = Console.ReadLine();
                    data.salary[i] = Convert.ToInt32(input.Split(' ')[0]);
                    data.month[i] = Convert.ToInt32(input.Split(' ')[1]);
                    data.name[i] = getNameFromConsole(input);
                }
            }

            return data;
        }

        //returns the name of the person that is separated by an unknown number of spaces
        public static string getNameFromConsole(string input)
        {
            string result = "";
            for (int j = 2; j < input.Split(' ').Length; j++)
            {
                result += input.Split(' ')[j];
                if (j != input.Split(' ').Length - 1)
                    result += " ";
            }
            return result;
        }

        //prints out the data from the Data structure
        public static void print(int length, Data data)
        {
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(data.salary[i] + " - " + data.month[i] + " - " + data.name[i]);
            }
        }

        //finds the person with the highest income and returns the name of the person
        public static string highestIncome(int length, Data data)
        {
            int maxInd = 0;
            for (int i = 0; i < length; i++)
            {
                if (data.salary[i] > data.salary[maxInd])
                {
                    maxInd = i;
                }
            }
            return data.name[maxInd];
        }

        //creates a list of the people and their overall sallary 
        public static TaskB solveTaskB(int length, Data data)
        {
            int cnt = 0;
            List<string> helperList = new List<string>();
            //creating a list that has every person once
            for (int i = 0; i < length; i++)
            {
                if (!helperList.Contains(data.name[i]))
                    helperList.Add(data.name[i]);
            }
            cnt = helperList.Count;

            int sum = 0;
            TaskB taskB = new TaskB();
            taskB.cnt = cnt;
            taskB.name = new string[cnt];
            taskB.salary = new int[cnt];
            for (int i = 0; i < cnt; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    //counting the overall salary of the people from the list                
                    if (helperList[i] == data.name[j])
                        sum = sum + data.salary[j] * data.month[j];
                }
                //adding their names and salary to the TaskB struct
                taskB.name[i] = helperList[i];
                taskB.salary[i] = sum * 100000;
                sum = 0;
            }

            //printTaskB(taskB);

            return taskB;
        }

        //prints out the TaskB types structure
        public static void printTaskB(TaskB taskB)
        {
            Console.WriteLine("#");
            for (int i = 0; i < taskB.cnt; i++)
                Console.WriteLine(taskB.name[i] + " " + taskB.salary[i]);
        }

        //finds the person who managed to get each job for a higher salary than the previous salary
        //if there is no such person, outputs “NONE”
        public static string solveTaskC(Data data)
        {
            List<string> namesCovered = new List<string>();
            for (int i = 0; i < data.name.Length; i++)
            {
                bool isHigher = true;
                if (!namesCovered.Contains(data.name[i]))
                {
                    namesCovered.Add(data.name[i]);
                    for (int j = i + 1; j < data.name.Length; j++)
                    {
                        if (data.name[i] == data.name[j] && data.salary[i] >= data.salary[j])
                        {
                            Console.WriteLine("-> " + i + " " + data.name[i]);
                            isHigher = false;
                        }
                    }
                    if (isHigher)
                    {
                        return data.name[i];
                    }
                    isHigher = true;
                }
            }
            return "NONE";
        }

        //list all the people whose salary was more than C (people get on this list only once!)
        public static List<string> solveTaskD(int limit, Data data)
        {
            List<string> hadMoreThanC_Salary = new List<string>();
            for (int i = 0; i < data.name.Length; i++)
            {
                if (data.salary[i] > limit)
                    if (!hadMoreThanC_Salary.Contains(data.name[i]))
                        hadMoreThanC_Salary.Add(data.name[i]);
            }
            return hadMoreThanC_Salary;
        }
    }
}