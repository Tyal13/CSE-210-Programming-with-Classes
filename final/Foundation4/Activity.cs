using System;

class Activity
{
    private DateTime _date;
    private int _lengthMinutes;

    public Activity(DateTime date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    public int GetLengthMinutes()
    {
        return _lengthMinutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return (GetDistance() / _lengthMinutes) * 60;
    }

    public virtual double GetPace()
    {
        return _lengthMinutes / GetDistance();
    }

    public string GetSummary()
    {
        string name = GetType().Name;
        string date = _date.ToString("dd MMM yyyy");

        return $"{date} {name} ({_lengthMinutes} min): Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}
