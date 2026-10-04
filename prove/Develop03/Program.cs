using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = BuildScriptureLibrary();
        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        while (true)
        {
            ClearConsole();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }

    static List<Scripture> BuildScriptureLibrary()
    {
        List<Scripture> library = new List<Scripture>();

        library.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths"));

        library.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"));

        library.Add(new Scripture(
            new Reference("Philippians", 4, 13),
            "I can do all things through Christ which strengtheneth me"));

        return library;
    }

    static void ClearConsole()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
        }
    }
}
