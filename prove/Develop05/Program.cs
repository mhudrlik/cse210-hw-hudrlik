using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create a New Simple Goal");
            Console.WriteLine("2. Create a New Eternal Goal");
            Console.WriteLine("3. Create a New Checklist Goal");
            Console.WriteLine("4. List Goals");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Record Event");
            Console.WriteLine("8. Quit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine();
                    manager.CreateNewSimpleGoal();
                    break;
                case "2":
                    Console.WriteLine();
                    manager.CreateNewEternalGoal();
                    break;
                case "3":
                    Console.WriteLine();
                    manager.CreateNewChecklistGoal();
                    break;
                case "4":
                    Console.WriteLine();
                    manager.ListGoalDetails();
                    break;
                case "5":
                    Console.WriteLine();
                    manager.SaveGoals("goals.json");
                    break;
                case "6":
                    Console.WriteLine();
                    manager.LoadGoals("goals.json");
                    break;
                case "7":
                    Console.WriteLine();
                    manager.RecordEvent();
                    break;
                case "8":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 8.");
                    break;
            }
        }
    }
}
