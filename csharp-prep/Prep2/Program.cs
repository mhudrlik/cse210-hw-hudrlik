using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";

        if (percent >= 90)
            {
                letter = "A";
            }
        else if (percent >= 80)
            {
                letter = "B";
            }
        else if (percent >= 70)
            {
                letter = "C";
            }
        else if (percent >= 60)
            {
                letter = "D";
            }
        else
            {
                letter = "F";
            }
        
        int plusminus = percent % 10;
        string sign;

        if (plusminus >= 7)
            {
                sign = "+";
            }
        else if (plusminus <=3)
            {
                sign = "-";
            }
        else
            {
                sign = "";
            }
        
        if (percent > 93 || percent < 60)
            {
                Console.WriteLine($"Your grade is: {letter}");
            }
        else
            {
                Console.WriteLine($"Your grade is: {letter}{sign}");
            }
        if (percent >= 70)
            {
                Console.WriteLine("Woohoo!!! You passed!");
            }
        else
            {
                Console.WriteLine("You probably should retake the course.");
            }
    }
}