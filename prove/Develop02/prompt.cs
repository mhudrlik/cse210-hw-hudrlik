using System;
using System.Collections.Generic;

public class Prompt
{
    public List<string> prompts;

    public Prompt()
    {
        prompts = new List<string>();
        InitializePrompts();
    }

    private void InitializePrompts()
    {
        prompts.Add("What made you feel happy today?");
        prompts.Add("What goal did you work on today?");
        prompts.Add("Who did you meet today?");
        prompts.Add("How was your family?");
        prompts.Add("How did you help someone else today?");
    }


    public string Random()
    {
        if (prompts.Count == 0)
        {
            return "No prompts available.";
        }

        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }

    public void Add()
    {
        Console.Write("Enter a new prompt: ");
        string newPrompt = Console.ReadLine();
        prompts.Add(newPrompt);
        Console.WriteLine("Prompt added successfully.");
    }

    public void Remove()
    {
        Console.WriteLine("Entry List");
        for (int i = 0; i < prompts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {prompts[i]}");
        }

        Console.Write("Enter the number of the prompt to remove: ");
        if (int.TryParse(Console.ReadLine(), out int selectedPrompt))
        {
            if (selectedPrompt >= 1 && selectedPrompt <= prompts.Count)
            {
                string removedPrompt = prompts[selectedPrompt - 1];
                prompts.RemoveAt(selectedPrompt - 1);
                Console.WriteLine($"Prompt '{removedPrompt}' removed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid prompt number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}