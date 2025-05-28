using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }

    public void DisplayComment()
    {
        Console.WriteLine($"- {CommenterName}: {CommentText}");
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"\nTitle: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            comment.DisplayComment();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videoList = new List<Video>();

        // Video 1
        Video video1 = new Video("Gadget Review: SmartWatch X10", "TechGuru", 315);
        video1.AddComment(new Comment("Alice", "Thanks for the detailed review!"));
        video1.AddComment(new Comment("Bob", "Is the battery life really 7 days?"));
        video1.AddComment(new Comment("Charlie", "Great editing and visuals."));
        videoList.Add(video1);

        // Video 2
        Video video2 = new Video("Travel Vlog: Ghana Adventure", "WanderWithMe", 540);
        video2.AddComment(new Comment("Debbie", "What a beautiful country!"));
        video2.AddComment(new Comment("Eli", "Now Ghana is on my bucket list."));
        video2.AddComment(new Comment("Frank", "Loved the drone shots."));
        videoList.Add(video2);

        // Video 3
        Video video3 = new Video("Fitness Challenge - 30 Days", "FitLifeWithSam", 675);
        video3.AddComment(new Comment("Grace", "Day 1 done!"));
        video3.AddComment(new Comment("Hank", "This is exactly what I needed."));
        video3.AddComment(new Comment("Ivy", "Subbed! Let’s do this!"));
        videoList.Add(video3);

        // Video 4
        Video video4 = new Video("Cooking Quick Meals", "ChefLinda", 420);
        video4.AddComment(new Comment("Jake", "So easy and tasty!"));
        video4.AddComment(new Comment("Kim", "My kids loved the pasta recipe."));
        video4.AddComment(new Comment("Liam", "Finally, a chef who explains things clearly."));
        videoList.Add(video4);

        // Display video info
        foreach (Video video in videoList)
        {
            video.DisplayVideoInfo();
        }
    }
}

