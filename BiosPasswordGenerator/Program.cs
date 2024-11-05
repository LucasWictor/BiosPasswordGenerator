using BiosPasswordGenerator.Vendors;

namespace BiosPasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter year:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter month:");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter day:");
            int day = int.Parse(Console.ReadLine());

            string password = AsusGenerator.GeneratePassword(year, month, day);
            Console.WriteLine($"Generated ASUS BIOS Password: {password}");
        }
    }
}