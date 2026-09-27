using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool keepRunning = true;

        while (keepRunning)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("That is not a valid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Save");
        Console.WriteLine("4. Load");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
    }

    static void WriteNewEntry(Journal journal)
    {
        string prompt = journal.GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        Console.Write("In one or two words, what is your mood right now? ");
        string mood = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();
        Entry entry = new Entry(date, prompt, response, mood);
        journal.AddEntry(entry);
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        journal.Save(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        journal.Load(filename);
    }
    
}
