using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
class Activity
{
    protected string _name;
    protected string _description;
    protected int _durationSeconds;
    private Random _random;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _durationSeconds = 0;
        _random = new Random();
    }
    public void DisplayStartingMessage()
    {
        ClearScreen();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _durationSeconds = ReadDuration();

        ClearScreen();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_durationSeconds} seconds of the {_name} Activity.");
        ShowSpinner(5);
        Console.WriteLine();
    }
    protected void ShowSpinner(int seconds)
    {
        List<string> frames = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[index]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            index = (index + 1) % frames.Count;
        }
    }
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string text = i.ToString();
            Console.Write(text);
            Thread.Sleep(1000);
            Console.Write(new string('\b', text.Length) + new string(' ', text.Length) + new string('\b', text.Length));
        }
    }
    protected DateTime GetEndTime()
    {
        return DateTime.Now.AddSeconds(_durationSeconds);
    }

    protected string GetRandomUnused(List<string> allItems, List<string> unusedItems)
    {
        if (unusedItems.Count == 0)
        {
            unusedItems.AddRange(allItems);
        }
        int index = _random.Next(unusedItems.Count);
        string item = unusedItems[index];
        unusedItems.RemoveAt(index);
        return item;
    }
    private int ReadDuration()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (input == null)
            {
                return 30;
            }
            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                return seconds;
            }
            Console.Write("Please enter a whole number of seconds greater than 0: ");
        }
    }
    private void ClearScreen()
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
