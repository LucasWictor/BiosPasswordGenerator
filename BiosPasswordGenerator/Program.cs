using System;
using BiosPasswordGenerator.Utilities;
using BiosPasswordGenerator.Vendors;
using PhoenixGenerator;

namespace BiosPasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the BIOS Password Generator.");
            Console.WriteLine("Currently supported manufacturers:");
            Console.WriteLine("1. ASUS "); // Date-based
            Console.WriteLine("2. Dell "); // Service Tag-based
            Console.WriteLine("3. Phoenix "); // 5-digit hash
            Console.WriteLine("Enter the number to select your BIOS manufacturer:");

            string choice = Console.ReadLine();
            string password = null;

            switch (choice)
            {
                case "1":
                    password = GenerateAsusPassword();
                    break;
                case "2":
                    password = GenerateDellPassword(); 
                    break;
                case "3":
                    password = GeneratePhoenixPassword(); 
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please restart and select a valid option.");
                    return;
            }

            if (!string.IsNullOrEmpty(password))
            {
                Console.WriteLine($"Generated BIOS Password: {password}");
            }
        }

        private static string GenerateAsusPassword()
        {
            Console.WriteLine("ASUS Password Generator (Date-based)");
            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter day: ");
            int day = int.Parse(Console.ReadLine());

            return AsusGenerator.GeneratePassword(year, month, day);
        }

        private static string GenerateDellPassword()
        {
            Console.WriteLine("Dell Password Generator (Service Tag-based)");
            Console.Write("Enter Dell Service Tag (e.g., 1234567-595B): ");
            string serviceTag = Console.ReadLine();
            
            // Placeholder until DellGenerator is implemented
            return "Error not found";
        }

        private static string GeneratePhoenixPassword()
        {
            Console.WriteLine("Phoenix Password Generator (5-digit hash)");
            Console.Write("Enter 5-digit Phoenix hash code: ");
            string hashCode = Console.ReadLine();

            try
            {
                return HpPhoenixPasswordGenerator.GeneratePassword(hashCode);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
