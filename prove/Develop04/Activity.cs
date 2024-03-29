using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "";
        _description = "";
        _duration = 30;
    }

    public virtual void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine(_description);
    }

    public virtual void DisplayEndingMessage(int duration)
    {
        Console.WriteLine($"You have completed {duration} seconds of the {_name} Activity.");
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = new string[] { "- ", "\\ ", "| ", "/ " };
        for (int i = 0; i < seconds * 2; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(500);
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
        }
    }

    protected void ShowCountDown(int seconds)
    {
        Console.Write("Starting in ");
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
        }
        Console.WriteLine();
    }
}
