using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class Program
{
    private static Journal journal;
    private static Prompt prompt;
    private static FileAction fileAction;


    public static void Main(string[] args)
    {
        prompt = new Prompt();
        journal = new Journal(prompt);
        fileAction = new FileAction("default.json");

    // Load the default.json file if it exists

        fileAction.Load(journal, prompt);

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1. Create new journal entry");
            Console.WriteLine("2. Write a prompt");
            Console.WriteLine("3. Remove a prompt");
            Console.WriteLine("4. Display journal entries");
            Console.WriteLine("5. Load a Journal");
            Console.WriteLine("6. Save a Journal");
            Console.WriteLine("7. Quit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        journal.Write();
                        break;
                    case 2:
                        prompt.Add();
                        break;
                    case 3:
                        prompt.Remove();
                        break;
                    case 4:
                        journal.Display();
                        break;
                    case 5:
                        fileAction.Load(journal, prompt);
                        break;
                    case 6:
                        fileAction.Save(journal, prompt);
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Console.WriteLine();
            }
        }
    }
}