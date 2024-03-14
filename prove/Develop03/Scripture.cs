using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private List<ScriptureWord> words;

    public ScriptureReference Reference { get; private set; }

    public Scripture(string reference, string text)
    {
        Reference = new ScriptureReference(reference);
        words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine($"{Reference}:");
        Console.WriteLine(string.Join(" ", words));
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, words.Count / 2);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(words.Count);
            words[index].IsHidden = true;
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }
}
