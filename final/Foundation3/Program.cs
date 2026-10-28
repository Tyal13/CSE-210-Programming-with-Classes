using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Event> events = new List<Event>();

        Address lectureAddress = new Address("200 University Blvd", "Rexburg", "ID", "USA");
        events.Add(new Lecture(
            "The Future of Cloud Computing",
            "A talk on where cloud technology is heading over the next decade.",
            "November 5, 2026",
            "7:00 PM",
            lectureAddress,
            "Dr. Elena Ruiz",
            150));

        Address receptionAddress = new Address("88 Harbor Way", "Vancouver", "BC", "Canada");
        events.Add(new Reception(
            "Alumni Networking Reception",
            "An evening to meet fellow graduates over appetizers and music.",
            "November 12, 2026",
            "6:30 PM",
            receptionAddress,
            "rsvp@alumnievents.example.com"));

        Address gatheringAddress = new Address("1 Riverside Park", "Idaho Falls", "ID", "USA");
        events.Add(new OutdoorGathering(
            "Community Picnic and Games",
            "A family friendly afternoon of food, lawn games and live music.",
            "November 20, 2026",
            "12:00 PM",
            gatheringAddress,
            "Sunny, high of 62 degrees F"));

        foreach (Event eventItem in events)
        {
            Console.WriteLine("--- Standard Details ---");
            Console.WriteLine(eventItem.GetStandardDetails());
            Console.WriteLine();

            Console.WriteLine("--- Full Details ---");
            Console.WriteLine(eventItem.GetFullDetails());
            Console.WriteLine();

            Console.WriteLine("--- Short Description ---");
            Console.WriteLine(eventItem.GetShortDescription());
            Console.WriteLine();
            Console.WriteLine("==============================");
            Console.WriteLine();
        }
    }
}
