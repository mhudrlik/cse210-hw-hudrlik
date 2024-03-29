using System;

class Program
{
    static void Main(string[] args)
    {
        DateTime startTime = DateTime.Now;
        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                case "4":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
        TimeSpan totalTimeSpent = DateTime.Now - startTime;
        Console.WriteLine($"You have spent {totalTimeSpent.TotalMinutes:N0} minute(s) and {totalTimeSpent.Seconds} seconds in the Mindfulness app this session.");
        Console.WriteLine("Thank you for using the program today!");
    }
}
