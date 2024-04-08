using System;
class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2024, 4, 6), 60, 8.0));
        activities.Add(new Cycling(new DateTime(2024, 4, 8), 45, 13.0));
        activities.Add(new Swimming(new DateTime(2024, 4, 10), 30, 27));

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
