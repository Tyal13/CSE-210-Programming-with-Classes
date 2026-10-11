using System;
using System.Collections.Generic;
class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _unusedPrompts;
    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _unusedPrompts = new List<string>();
    }
    public void RunActivity()
    {
        DisplayStartingMessage();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        int itemCount = 0;
        DateTime endTime = GetEndTime();
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();

            if (item == null)
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(item))
            {
                itemCount++;
            }
        }
        Console.WriteLine();
        Console.WriteLine($"You listed {itemCount} items!");

        DisplayEndingMessage();
    }
    private string GetRandomPrompt()
    {
        return GetRandomUnused(_prompts, _unusedPrompts);
    }
}
