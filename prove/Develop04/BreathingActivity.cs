using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Write("Enter the duration in seconds (default is 30): ");
        int.TryParse(Console.ReadLine(), out _duration);
        if (_duration <= 0)
            _duration = 30;
        ShowCountDown(5);
        Console.WriteLine("Clear your mind and focus on your breathing.");

        int remainingDuration = _duration;
        while (remainingDuration > 0)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(6);
            remainingDuration -= 6;

            if (remainingDuration > 0)
            {
                Console.WriteLine("Breathe out...");
                ShowSpinner(6);
                remainingDuration -= 6;
            }
        }

        DisplayEndingMessage(_duration);
    }
}
