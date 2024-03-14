using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> allScriptures = Content.GetAllScriptures();
        
        bool restart = true;
        while (restart)
        {
            string category = GetUserSelection();

            List<Scripture> selectedScriptures = GenerateScriptures(category, allScriptures);

            foreach (Scripture scripture in selectedScriptures)
            {
                DisplayScripture(scripture);

                while (!scripture.AllWordsHidden())
                {
                    Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "quit")
                    {
                        restart = false;
                        break;
                    }

                    Console.Clear();
                    scripture.HideRandomWords();
                    Console.WriteLine(scripture.GetHiddenText());
                }

                if (!restart)
                    break;

                Console.WriteLine("All words are hidden. Press Enter to continue or type 'quit' to exit.");
                string quitOrRestart = Console.ReadLine();
                if (quitOrRestart.ToLower() == "quit")
                {
                    restart = false;
                    break;
                }
                else if (quitOrRestart != "")
                {
                    break;
                }
            }
        }

        Console.WriteLine("Memorization program ended. Press any key to exit...");
        Console.ReadKey();
    }

    static string GetUserSelection()
    {
        Console.WriteLine("Select a category:");
        Console.WriteLine("1. Old Testament");
        Console.WriteLine("2. New Testament");
        Console.WriteLine("3. Book of Mormon");
        Console.WriteLine("4. Doctrine and Covenants");
        Console.WriteLine("5. Random");
        Console.WriteLine("6. Quit");

        Console.Write("Enter the number of your choice: ");
        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 1:
                    return "Old Testament";
                case 2:
                    return "New Testament";
                case 3:
                    return "Book of Mormon";
                case 4:
                    return "Doctrine and Covenants";
                case 5:
                    return "Random";
                case 6:
                    Environment.Exit(0); // Quit the program
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return GetUserSelection();
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return GetUserSelection();
        }
        return ""; 
    }


    static List<Scripture> GenerateScriptures(string category, List<Scripture> allScriptures)
    {
        List<Scripture> selectedScriptures = new List<Scripture>();

        switch (category)
        {
            case "Old Testament":
            case "New Testament":
            case "Book of Mormon":
            case "Doctrine and Covenants":
                selectedScriptures = allScriptures.FindAll(s => s.Category == category);
                break;
            case "Random":
                Random random = new Random();
                selectedScriptures.Add(allScriptures[random.Next(0, allScriptures.Count)]);
                break;
            default:
                Console.WriteLine("Invalid category. Please try again.");
                break;
        }

        return selectedScriptures;
    }

    static void DisplayScripture(Scripture scripture)
    {
        Console.WriteLine(scripture.GetFullText());
    }
}
