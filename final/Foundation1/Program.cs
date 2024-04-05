using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Minecraft Let's Play", "Some random person", 600);
        video1.AddComment("MinecraftFan", "This is a great video!");
        video1.AddComment("Original Poster", "Thank you, I appreciate it.");
        video1.AddComment("MinecraftFan", "No problem!");
        videos.Add(video1);

        Video video2 = new Video("Another popular video", "Another Random Individual", 3000);
        video2.AddComment("Interested User", "This was a longer video.");
        video2.AddComment("Another Random Individual", "Thanks, I'm trying to put more content into them.");
        video2.AddComment("Interested User", "You're doing good!");
        videos.Add(video2);

        Video video3 = new Video("10 tips every wood worker should know!", "Pinewood Sam", 120);
        video3.AddComment("Beginner Woodworker", "This is a great list!  I couldn't believe number 7!");
        video3.AddComment("Pinewood Sam", "If you think 7 is great, number 9 will blow your mind!");
        video3.AddComment("Beginner Woodworker", "I can't wait to get to that part of the video!  Cheers!");
        video3.AddComment("Pinewood Sam", "Cheers mate!");
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
