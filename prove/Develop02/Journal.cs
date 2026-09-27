using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> _entries;
    private List<string> _prompts;
    private Random _random;

    public Journal()
    {
        _entries = new List<Entry>();
        _random = new Random();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What am I most grateful for today?",
            "What is one thing I learned today?"
        };
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty. Write an entry first!");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void Save(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToString());
            }
        }

        Console.WriteLine($"Journal saved to {filename}.");
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"Could not find file {filename}.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        List<Entry> loadedEntries = new List<Entry>();

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            loadedEntries.Add(Entry.FromString(line));
        }

        _entries = loadedEntries;
        Console.WriteLine($"Journal loaded from {filename}.");
    }
}
