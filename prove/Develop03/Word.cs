using System;

public class Word
{
    private string text;
    private bool hidden;

    public Word(string text)
    {
        this.text = text;
        this.hidden = false;
    }

    public bool Hidden => hidden;

    public void Hide()
    {
        this.hidden = true;
    }

    public string GetText()
    {
        if (hidden)
            return new string('_', text.Length);
        else
            return text;
    }

    public string GetHiddenText()
    {
        if (hidden)
            return new string('_', text.Length);
        else
            return text;
    }
}
