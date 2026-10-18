using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _pointsPerLevel;
    private List<string> _levelTitles;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _pointsPerLevel = 500;
        _levelTitles = new List<string>
        {
            "Novice",
            "Apprentice",
            "Adventurer",
            "Knight",
            "Champion",
            "Legend"
        };
    }

    public void Start()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.WriteLine();
            DisplayScore();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                case null:
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("That is not a valid choice. Please try again.");
                    break;
            }
        }
    }

    private void DisplayScore()
    {
        int level = GetLevel();
        int pointsToNext = (level * _pointsPerLevel) - _score;

        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level {level}: {GetLevelTitle()} ({pointsToNext} points to the next level)");
    }

    private int GetLevel()
    {
        return (_score / _pointsPerLevel) + 1;
    }

    private string GetLevelTitle()
    {
        int index = Math.Min(GetLevel() - 1, _levelTitles.Count - 1);
        return _levelTitles[index];
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (a bad habit that costs points)");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        if (type != "1" && type != "2" && type != "3" && type != "4")
        {
            Console.WriteLine("That is not a valid goal type.");
            return;
        }

        string name = ReadText("What is the name of your goal? ");
        string description = ReadText("What is a short description of it? ");

        string pointsQuestion = "What is the amount of points associated with this goal? ";
        if (type == "4")
        {
            pointsQuestion = "How many points do you lose each time you do this? ";
        }
        int points = ReadNumber(pointsQuestion);

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                int target = ReadNumber("How many times does this goal need to be accomplished for a bonus? ");
                int bonus = ReadNumber("What is the bonus for accomplishing it that many times? ");
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                break;
        }

        Console.WriteLine("Goal created.");
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record yet. Create one first.");
            return;
        }

        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int number) || number < 1 || number > _goals.Count)
        {
            Console.WriteLine("That is not a valid goal number.");
            return;
        }

        Goal goal = _goals[number - 1];
        bool wasComplete = goal.IsComplete();
        int oldLevel = GetLevel();

        int points = goal.RecordEvent();
        _score = Math.Max(0, _score + points);

        Console.WriteLine();
        if (points > 0)
        {
            Console.WriteLine($"Congratulations! You have earned {points} points!");
        }
        else if (points < 0)
        {
            Console.WriteLine($"Oh no! You lost {-points} points.");
        }
        else
        {
            Console.WriteLine("No points earned this time. That goal is already complete.");
        }

        if (!wasComplete && goal.IsComplete())
        {
            DisplayCelebration(goal.GetName());
        }

        if (GetLevel() > oldLevel)
        {
            Console.WriteLine($"LEVEL UP! You are now Level {GetLevel()}: {GetLevelTitle()}!");
        }
    }

    private void DisplayCelebration(string goalName)
    {
        Console.WriteLine();
        Console.WriteLine("*******************************************");
        Console.WriteLine($"   GOAL COMPLETE: {goalName}!");
        Console.WriteLine("*******************************************");
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("No filename given. Nothing was saved.");
            return;
        }

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine($"Saved {_goals.Count} goals to {filename}.");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename) || !File.Exists(filename))
        {
            Console.WriteLine("Could not find that file.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0 || !int.TryParse(lines[0], out int loadedScore))
        {
            Console.WriteLine("That file does not look like a goal file.");
            return;
        }

        List<Goal> loadedGoals = new List<Goal>();
        int skipped = 0;

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
            {
                continue;
            }

            Goal goal = CreateGoalFromLine(lines[i]);
            if (goal == null)
            {
                skipped++;
            }
            else
            {
                loadedGoals.Add(goal);
            }
        }

        _score = loadedScore;
        _goals = loadedGoals;

        Console.WriteLine($"Loaded {_goals.Count} goals from {filename}.");
        if (skipped > 0)
        {
            Console.WriteLine($"Skipped {skipped} lines that could not be read.");
        }
    }

    private Goal CreateGoalFromLine(string line)
    {
        string[] halves = line.Split(':', 2);
        if (halves.Length < 2)
        {
            return null;
        }

        string[] parts = halves[1].Split('|');

        try
        {
            switch (halves[0])
            {
                case "SimpleGoal":
                    return new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]), bool.Parse(parts[3]));
                case "EternalGoal":
                    return new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
                case "ChecklistGoal":
                    return new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                case "NegativeGoal":
                    return new NegativeGoal(parts[0], parts[1], int.Parse(parts[2]));
                default:
                    return null;
            }
        }
        catch (FormatException)
        {
            return null;
        }
        catch (IndexOutOfRangeException)
        {
            return null;
        }
    }

    private string ReadText(string question)
    {
        Console.Write(question);
        string text = Console.ReadLine();

        if (text == null)
        {
            return "Unnamed";
        }

        // The save file uses "|" as a separator, so keep it out of the text.
        return text.Replace("|", "/").Trim();
    }

    private int ReadNumber(string question)
    {
        while (true)
        {
            Console.Write(question);
            string input = Console.ReadLine();

            if (input == null)
            {
                return 0;
            }

            if (int.TryParse(input, out int number) && number >= 0)
            {
                return number;
            }

            Console.WriteLine("Please enter a whole number of 0 or more.");
        }
    }
}
