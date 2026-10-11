using System;

class Program
{
    static void Main(string[] args)
    {
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;
        bool keepRunning = true;

        while (keepRunning)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().RunActivity();
                    breathingCount++;
                    break;
                case "2":
                    new ReflectingActivity().RunActivity();
                    reflectingCount++;
                    break;
                case "3":
                    new ListingActivity().RunActivity();
                    listingCount++;
                    break;
                case "4":
                case null:
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("That is not a valid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Session summary:");
        Console.WriteLine($"  Breathing activities completed: {breathingCount}");
        Console.WriteLine($"  Reflecting activities completed: {reflectingCount}");
        Console.WriteLine($"  Listing activities completed: {listingCount}");
    }

    static void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Quit");
        Console.Write("Select a choice from the menu: ");
    }
}
