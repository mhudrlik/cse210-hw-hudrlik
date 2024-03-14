using System;
using System.Collections.Generic;
using System.Linq;

public class Verse
{
    private List<Word> words;

    public Verse(int verseNumber, string text)
    {
        VerseNumber = verseNumber;
        InitializeWords(text);
    }

    public int VerseNumber { get; }
    
    public void InitializeWords(string text)
    {
        string[] wordArray = text.Split(' ');
        words = wordArray.Select(word => new Word(word)).ToList();
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.Hidden);
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        List<Word> visibleWords = words.Where(word => !word.Hidden).ToList();
        if (visibleWords.Count > 0)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
        }
    }


    public string GetHiddenText()
    {
        string verseText = $"{VerseNumber} ";
        foreach (Word word in words)
        {
            verseText += $"{word.GetHiddenText()} ";
        }
        return verseText.Trim();
    }

    public string GetFullText()
    {
        string verseText = $"{VerseNumber} ";
        foreach (Word word in words)
        {
            verseText += $"{word.GetText()} ";
        }
        return verseText.Trim();
    }
}
