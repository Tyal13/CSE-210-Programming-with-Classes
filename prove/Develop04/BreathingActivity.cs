using System;
using System.Threading;
class BreathingActivity : Activity
{
    private int _breatheInSeconds;
    private int _breatheOutSeconds;

    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _breatheInSeconds = 4;
        _breatheOutSeconds = 6;
    }
    public void RunActivity()
    {
        DisplayStartingMessage();

        DateTime endTime = GetEndTime();
        while (DateTime.Now < endTime)
        {
            ShowBreath("Breathe in... ", _breatheInSeconds, true);
            ShowBreath("Breathe out...", _breatheOutSeconds, false);
        }
        DisplayEndingMessage();
    }
    private void ShowBreath(string message, int seconds, bool isGrowing)
    {
        for (int second = 0; second < seconds; second++)
        {
            int filled = isGrowing ? second + 1 : seconds - second;
            int remaining = seconds - second;
            string bar = new string('#', filled) + new string(' ', seconds - filled);

            Console.Write($"\r{message} [{bar}] {remaining} ");
            Thread.Sleep(1000);
        }

        Console.WriteLine();
    }
}