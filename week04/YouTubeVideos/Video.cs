using System;
using System.Collections.Generic;

//Store video details and manage comments
class Video
{
    private string title;
    private string author;
    private int lengthInSeconds;
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        this.title = title;
        this.author = author;
        this.lengthInSeconds = lengthInSeconds;
        this.comments = new List<Comment>();
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    // Method to return the number of comments
    public int GetCommentCount()
    {
        return comments.Count;
    }

    // Method to get all comments as a list of strings
    public List<string> GetAllComments()
    {
        List<string> commentDetails = new List<string>();
        foreach (Comment comment in comments)
        {
            commentDetails.Add(comment.GetCommentDetails());
        }
        return commentDetails;
    }

    // Method to get video details as a formatted string
    public string GetVideoDetails()
    {
        return $"Title: {title}\nAuthor: {author}\nLength: {lengthInSeconds} seconds";
    }
}