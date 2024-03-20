using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Write("Enter the duration in seconds (default is 30): ");
        int.TryParse(Console.ReadLine(), out _duration);
        if (_duration <= 0) _duration = 30;
        string randomPrompt = GetRandomPrompt();
        Console.WriteLine(randomPrompt);
        Console.WriteLine("Starting in 5 seconds...");
        ShowCountDown(5);
        _count = GetListFromUser();
        Console.WriteLine($"You listed {_count} items.");
        DisplayEndingMessage(_duration);
    }

    private string GetRandomPrompt()
    {
        Random rnd = new Random();
        int index = rnd.Next(_prompts.Count);
        return _prompts[index];
    }

    private int GetListFromUser()
    {
        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (input != "")
                count++;
        }
        return count;
    }
}
