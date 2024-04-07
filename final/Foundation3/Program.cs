using System;

class Program
{
    static void Main(string[] args)
    {
        Address eventAddress = new Address("155 North Corner Ave.", "Idaho Falls", "Idaho", "83401");

        Event[] events = new Event[]
        {
            new EventLecture("Volleyball For Coaches", "This is the first meeting in a series for coaches to prepare them for this season", new DateTime(2024, 5, 1), new TimeSpan(19, 30, 0), eventAddress, "Amanda Szabo", 122),
            new EventReception("Volleyball Meetup", "Meet and greet for all the players.", new DateTime(2024, 5, 4), new TimeSpan(12, 0, 0), eventAddress, "matthudrlik@gmail.com"),
            new EventOutdoorGathering("Volleyball Tournament", "Volleyball Tournament to take place in the gym.", new DateTime(2024, 5, 18), new TimeSpan(8, 0, 0), eventAddress, "Cloudy with a chance of meatballs")
        };
        
        foreach (Event evt in events)
        {
            Console.WriteLine($"Event Type: {evt.GetType().Name}\n");
            Console.WriteLine("-----Standard Details-----");
            Console.WriteLine(evt.GetStandardDetails());

            Console.WriteLine("\n-----Full Details-----");
            Console.WriteLine(evt.GetFullDetails());

            Console.WriteLine("\n-----Short Description-----");
            Console.WriteLine(evt.GetShortDetails());

            Console.WriteLine("\n--------------------------------------------\n");
        }
    }
}