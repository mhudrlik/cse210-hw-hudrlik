using System;

class Program
{
    static void Main(string[] args)
    {

        List<int> numbers = new List<int>();

        // Populate the list
        Console.WriteLine("Enter a list of numbers, type 0 when finished):");
        while (true)
        {   
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            if (input == "0")
                break;
            if (int.TryParse(input, out int number))
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }

        // Sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine("The sum is: " + sum);

        // Average
        double average = numbers.Count > 0 ? (double)sum / numbers.Count : 0;
        Console.WriteLine("The average is: " + average);

        // Largest
        int max = int.MinValue;
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine("The largest number is: " + max);

        // Smallest Positive
        int smallestPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }
        Console.WriteLine("The smallest positive number is: " + smallestPositive);

        // Sorted list
        numbers.Sort();
        Console.WriteLine("Sorted list of numbers:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();
    }
}