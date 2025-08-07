using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        Video video1 = new Video("How to Tie a Tie", "John Doe", 300);
        Video video2 = new Video("Learning to Code", "Jane Smith", 600);
        Video video3 = new Video("How to change a tire", "John Doe", 120);

        video1.AddComment(new Comment("Great video!", "Alice"));
        video1.AddComment(new Comment("Very helpful, thanks!", "Bob"));
        video1.AddComment(new Comment("I love this tutorial!", "Alice"));

        video2.AddComment(new Comment("I learned a lot!", "Charlie"));
        video2.AddComment(new Comment("This is exactly what I needed.", "Bob"));
        video2.AddComment(new Comment("Awesome explanation!", "Alice"));

        video3.AddComment(new Comment("Nice tutorial!", "David"));
        video3.AddComment(new Comment("This saved me a lot of time.", "Eve"));
        video3.AddComment(new Comment("Thanks for the tips!", "Frank"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine($"Comments ({video.GetCommentCount()}):");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}