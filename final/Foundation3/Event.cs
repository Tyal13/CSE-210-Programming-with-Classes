using System;

class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public string GetStandardDetails()
    {
        return $"{_title}\n{_description}\nDate: {_date}\nTime: {_time}\nAddress:\n{_address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return $"Type: {GetEventType()}\n{GetStandardDetails()}";
    }

    public string GetShortDescription()
    {
        return $"{GetEventType()}: {_title} on {_date}";
    }

    public virtual string GetEventType()
    {
        return "Event";
    }
}
