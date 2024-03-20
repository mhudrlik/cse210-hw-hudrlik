using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Write("Enter the duration in seconds (default is 30): ");
        int.TryParse(Console.ReadLine(), out _duration);
        if (_duration <= 0)
            _duration = 30;

        string randomPrompt = GetRandomPrompt();
        Console.WriteLine(randomPrompt);
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        DisplayQuestions(_duration);
        DisplayEndingMessage(_duration);
    }

    private void DisplayQuestions(int duration)
    {
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        foreach (var question in _questions)
        {
            if (DateTime.Now >= endTime)
                break;
            
            Console.WriteLine(question);
            ShowSpinner(7);
        }
    }

    private string GetRandomPrompt()
    {
        Random rnd = new Random();
        int index = rnd.Next(_prompts.Count);
        return _prompts[index];
    }


}
