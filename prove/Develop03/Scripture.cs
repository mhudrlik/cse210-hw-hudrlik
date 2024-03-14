using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public string Category { get; }
    public string Book { get; }
    public int Chapter { get; }
    public List<Verse> Verses { get; }

    public Scripture(string category, string book, int chapter, List<Verse> verses)
    {
        Category = category;
        Book = book;
        Chapter = chapter;
        Verses = verses;
    }

    public bool AllWordsHidden()
    {
        return Verses.All(verse => verse.AllWordsHidden());
    }

    public void HideRandomWords()
    {
        foreach (Verse verse in Verses)
        {
            verse.HideRandomWord();
        }
    }

    public string GetHiddenText()
    {
        string scriptureText = $"{Category}\n{Book} {Chapter}:\n";
        foreach (Verse verse in Verses)
        {
            scriptureText += $"{verse.GetHiddenText()}\n";
        }
        return scriptureText;
    }

    public string GetFullText()
    {
        string scriptureText = $"{Category}\n{Book} {Chapter}:\n";
        foreach (Verse verse in Verses)
        {
            scriptureText += $"{verse.GetFullText()}\n";
        }
        return scriptureText;
    }
}
