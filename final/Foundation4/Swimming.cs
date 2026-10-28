using System;

class Swimming : Activity
{
    private int _laps;


    public Swimming(DateTime date, int lengthMinutes, int laps) : base(date, lengthMinutes)
    {
        _laps = laps;
    }


    public override double GetDistance()
    {
        return _laps * 50 / 1000.0 * 0.62;
    }
}
