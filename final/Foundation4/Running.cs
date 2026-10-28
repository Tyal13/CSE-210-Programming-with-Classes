using System;

class Running : Activity
{
    private double _distance;


    public Running(DateTime date, int lengthMinutes, double distance) : base(date, lengthMinutes)
    {
        _distance = distance;
    }


    public override double GetDistance()
    {
        return _distance;
    }
}
