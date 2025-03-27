using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create Video 1
        Video video1 = new Video("Top 10 Gadgets", "TechGuru", 600);
        video1.AddComment(new Comment("Alice", "Great video, very informative!"));
        video1.AddComment(new Comment("Bob", "I love the gadgets."));
        video1.AddComment(new Comment("Charlie", "Can you review more phones?"));
        videos.Add(video1);

        // Create Video 2
        Video video2 = new Video("Cooking Basics", "Chef Mila", 900);
        video2.AddComment(new Comment("Dana", "This helped me a lot!"));
        video2.AddComment(new Comment("Eve", "The recipe was delicious."));
        video2.AddComment(new Comment("Frank", "Please make a dessert video."));
        video2.AddComment(new Comment("Grace", "So easy to follow!"));
        videos.Add(video2);

        // Create Video 3
        Video video3 = new Video("Yoga for Beginners", "FitLife", 1200);
        video3.AddComment(new Comment("Hank", "Really relaxing session."));
        video3.AddComment(new Comment("Ivy", "My back feels better already."));
        video3.AddComment(new Comment("Jon", "Thanks for the tips!"));
        videos.Add(video3);

        // Create Video 4
        Video video4 = new Video("DIY Home Decor", "CraftyKate", 450);
        video4.AddComment(new Comment("Kim", "Love these ideas!"));
        video4.AddComment(new Comment("Leo", "The lamp project was fun."));
        video4.AddComment(new Comment("Mia", "Can’t wait to try this."));
        video4.AddComment(new Comment("Ned", "Super creative!"));
        videos.Add(video4);

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine(video.GetVideoDetails());
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (string comment in video.GetAllComments())
            {
                Console.WriteLine($"- {comment}");
            }
            Console.WriteLine(); // Blank line between videos
        }
    }
}