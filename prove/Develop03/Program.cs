using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string jsonFilePath = "kjv-scriptures-json.txt";

        Console.WriteLine("Do you want to enter a specific reference or get a random reference? (enter/random)");
        string userInput = Console.ReadLine().ToLower();

        Scripture scripture;

        if (userInput == "enter")
        {
            Console.WriteLine("Enter the scripture reference (e.g., 'Genesis 1:1'): ");
            string referenceInput = Console.ReadLine();
            scripture = LoadScriptureByReference(referenceInput, jsonFilePath);
        }
        else if (userInput == "random")
        {
            scripture = LoadRandomScripture(jsonFilePath);
        }
        else
        {
            Console.WriteLine("Invalid input. Exiting program.");
            return;
        }

        while (!scripture.AllWordsHidden())
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                break;

            scripture.HideRandomWords();
            Console.Clear();
            scripture.Display();
        }
    }

    static Scripture LoadScriptureByReference(string referenceInput, string jsonFilePath)
    {
        string json = LoadJsonFromFile(jsonFilePath);

        var scriptureData = JsonConvert.DeserializeObject<List<Scripture>>(json);

        var heading = scriptureData.FirstOrDefault(h => h.Reference.ToString().Equals(referenceInput, StringComparison.OrdinalIgnoreCase));


        if (heading != null)
        {
            return heading;
        }
        else
        {
            Console.WriteLine("Reference not found. Exiting program.");
            Environment.Exit(0);
            return null;
        }
    }

    static Scripture LoadRandomScripture(string jsonFilePath)
    {
        string json = LoadJsonFromFile(jsonFilePath);

        var scriptureData = JsonConvert.DeserializeObject<List<Scripture>>(json);

        var randomHeading = scriptureData[new Random().Next(scriptureData.Count)];

        return randomHeading;
    }

    static string LoadJsonFromFile(string filePath)
    {
        try
        {
            return File.ReadAllText(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading JSON from file: {ex.Message}");
            Environment.Exit(0);
            return null;
        }
    }
}
