namespace Practise1Smaple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This is a single line comment
            /*
                This is a multiple line comment.
            */
            // Program 1
            Console.WriteLine("--Program 1--"); // WriteLine prints a whole line and puts the cursor into the next line 
            Console.Write("Enter the length of the rectangle: "); // Write leaves the cursor in the same line, if we use \n between the "" we get the equivalent of WriteLine
            int l = 0; // declaration of an integer which is a type of number with the value of 0
            string tmp = Console.ReadLine(); // declaration of a string which is a type of text, it gets the value that the Console.ReadLine(); reads from the console
            l = Convert.ToInt32(tmp); // l variable gets the value from the console, but the text read from the console needs to be converted into the type of the l variable
            Console.Write("Enter the width of the rectangle: "); 
            int w = Convert.ToInt32(Console.ReadLine()); // it is possible to use the previous example from line 14 to 16 as a one-liner, declaration of an integer that gets the converted value from the console
            Console.Write("The area of rectangle is (l x w) = {0}\n", l*w); // {0} is pointing to the first set of expression or variable; it is printing the values of variables and results of equations on the console
            Console.WriteLine("The perimeter of rectangle is 2(l + w) = {0}", 2*(l+w));
            Console.WriteLine("-----------------------------------\n"); // this format applies a double line break
            
            // Program 2
            Console.WriteLine("--Program 2--");
            Console.Write("Enter a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter b: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("({0} + {1})^2 ", a, b); // {0} points to the first variable (a); {1} points to the second variable (b)
            Console.WriteLine("= {0}^2 + 2*{0}*{1} + {1}^2", a, b);
            Console.WriteLine("= {0} + {1} + {2} ", Math.Pow(a, 2), 2 * a * b, b * b);
            Console.WriteLine("= {0}", Math.Pow(a, 2) + (2 * a * b) + (b * b));
            Console.WriteLine("-----------------------------------\n");
            
        }
    }
}