using System;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }
    public void AddComment(string commenterName, string text)
    {
        comments.Add(new Comment(commenterName, text));
    }
    public int GetNumberOfComments()
    {
        return comments.Count;
    }
    public void DisplayVideoDetails()
    {
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("Length (seconds): " + LengthInSeconds);
        Console.WriteLine("Number of Comments: " + GetNumberOfComments());
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine("- " + comment.CommenterName + ": " + comment.Text);
        }
        Console.WriteLine();
    }
}