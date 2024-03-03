public class Entry
{
    public DateTime Date;
    public string Prompt;
    public string Text;

    public void Display()
    {
        Console.WriteLine("Date: " + Date.ToString("yyyy-MM-dd"));
        Console.WriteLine("Prompt: " + Prompt);
        Console.WriteLine("Text: " + Text);
    }
}