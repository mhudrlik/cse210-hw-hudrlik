public class ScriptureReference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int VerseStart { get; private set; }
    public int VerseEnd { get; private set; }

    public ScriptureReference(string reference)
    {
        ParseReference(reference);
    }

    private void ParseReference(string reference)
    {
        Console.WriteLine($"Parsing reference: {reference}");
        // Split the reference into parts using spaces and colon
        string[] parts = reference.Split(' ');

        // Extract book, chapter, and verse information
        if (parts.Length >= 2)
        {
            Book = parts[0];

            // Use a temporary variable for parsing
            int tempChapter;
            if (int.TryParse(parts[1], out tempChapter))
            {
                Chapter = tempChapter;
            }
            else
            {
                Console.WriteLine("Invalid chapter format.");
                Environment.Exit(0);
            }

            // Check for verse range
            if (parts.Length >= 4 && parts[2] == "-")
            {
                int tempEndVerse;
                if (int.TryParse(parts[3], out tempEndVerse))
                {
                    VerseEnd = tempEndVerse;
                }
                else
                {
                    Console.WriteLine("Invalid verse end format.");
                    Environment.Exit(0);
                }
                Console.WriteLine($"Verse range detected: {VerseStart}-{VerseEnd}");
            }
            else if (parts.Length == 3)
            {
                int tempStartVerse;
                if (int.TryParse(parts[2], out tempStartVerse))
                {
                    VerseStart = tempStartVerse;
                    Console.WriteLine($"Single verse detected: {VerseStart}");
                }
                else
                {
                    Console.WriteLine("Invalid verse start format.");
                    Environment.Exit(0);
                }
            }

            Console.WriteLine($"Book: {Book}, Chapter: {Chapter}, VerseStart: {VerseStart}, VerseEnd: {VerseEnd}");
        }
        else
        {
            Console.WriteLine("Invalid scripture reference format.");
            Environment.Exit(0);
        }
    }

    public override string ToString()
    {
        return $"{Book} {Chapter}:{VerseStart}" + (VerseEnd > VerseStart ? $"-{VerseEnd}" : "");
    }
}
