using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C# in 10 Minutes", "CodeWithMia", 612);
        video1.AddComment(new Comment("Jordan", "This finally made classes click for me."));
        video1.AddComment(new Comment("Priya", "Great pacing, thank you!"));
        video1.AddComment(new Comment("Sam", "Could you do one on inheritance next?"));
        videos.Add(video1);

        Video video2 = new Video("Top 5 Camping Gadgets", "TrailTested", 845);
        video2.AddComment(new Comment("Alex", "The folding stove looks amazing."));
        video2.AddComment(new Comment("Dana", "I bought the headlamp and love it."));
        video2.AddComment(new Comment("Lee", "Which one would you skip?"));
        video2.AddComment(new Comment("Morgan", "Subscribed for more gear reviews."));
        videos.Add(video2);

        Video video3 = new Video("Sourdough for Beginners", "BakeWithRosa", 1230);
        video3.AddComment(new Comment("Chris", "My starter finally rose!"));
        video3.AddComment(new Comment("Taylor", "What flour do you recommend?"));
        video3.AddComment(new Comment("Jamie", "Loved the scoring tips."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthSeconds()} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
