namespace program3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Amount of petrol consumed (liters): ");
            double l = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Length of the trip (km): ");
            double L = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("The consumption of the car is {0} (liters / 100km)",l/(L/100));
            Console.ReadKey();
        }
    }
}