using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Prep3 World!");
        // Console.Write("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());
        Random randomNumber = new Random();
        int magicNumber = randomNumber.Next (1, 100);
        int guess = -1;
        int guessnumber = 0;
        string playagain = "yes";

        while (playagain == "yes")
        {
            guess = -1;
            guessnumber = 0;
            magicNumber = randomNumber.Next (1, 100);
            while (guess != magicNumber)
                {
                    Console.Write("What is your guess? ");
                    guess = int.Parse(Console.ReadLine());
                    
                    if (magicNumber < guess)
                    {
                        Console.WriteLine("Lower");
                        guessnumber++;
                    }
                    else if (magicNumber > guess)
                    {
                        Console.WriteLine("higher");
                        guessnumber++;
                    }
                    else
                    {
                        Console.WriteLine($"Correct!  You gessed the number in {guessnumber} guesses.");

                    }
                }
            Console.WriteLine("Do you want to play again?  yes/no");
            playagain = Console.ReadLine();
        }
    }
}