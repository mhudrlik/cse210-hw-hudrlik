using System;
using System.Collections.Generic;

public class Journal
{
    private Prompt prompts;
    public DateTime Created;
    public List<Entry> Entries;

    public Journal(Prompt prompt)
    {
        prompts = prompt;
        Entries = new List<Entry>();
        Created = DateTime.Today;
    }
    

    public void Write()
    {
        Entry newEntry = new Entry();

        Console.Write("Enter the date (yyyy-MM-dd) or leave blank for today: ");
        string dateInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(dateInput))
        {
            newEntry.Date = DateTime.Today;
        }
        else if (DateTime.TryParse(dateInput, out DateTime date))
        {
            newEntry.Date = date;
        }
        else
        {
            Console.WriteLine("Invalid date format.");
            return;
        }

        Console.Write("Enter the prompt or leave blank for a random prompt: ");
        string promptInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(promptInput))
        {
            newEntry.Prompt = prompts.Random();
            Console.WriteLine(prompts.Random());
        }
        else
        {
            newEntry.Prompt = promptInput;
        }

        Console.Write("Enter the text: ");
        newEntry.Text = Console.ReadLine();

        Entries.Add(newEntry);
        Console.WriteLine("Journal entry created successfully.");
    }

    public void Display()
    {
        Console.WriteLine("Created: " + Created.ToString("yyyy-MM-dd"));
        Console.WriteLine("Entries:");
        foreach (var entry in Entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }
}