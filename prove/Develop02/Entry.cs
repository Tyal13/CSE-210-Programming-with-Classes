using System;

class Entry
{
    private string _date;
    private string _prompt;
    private string _response;
    private string _mood;

    public Entry(string date, string prompt, string response, string mood)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine(_response);
        Console.WriteLine();
    }

    public override string ToString()
    {
        return $"{_date}|{_prompt}|{_mood}|{_response}";
    }

    public static Entry FromString(string line)
    {
        string[] parts = line.Split('|');
        string date = parts[0];
        string prompt = parts[1];
        string mood = parts[2];
        string response = parts.Length > 3 ? string.Join("|", parts, 3, parts.Length - 3) : "";

        return new Entry(date, prompt, response, mood);
    }
}
