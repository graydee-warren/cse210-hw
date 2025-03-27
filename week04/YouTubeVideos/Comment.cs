using System;
using System.Collections.Generic;

// Store commenter name and comment text
class Comment 
{
    private string commenterName;
    private string commentText;

    public Comment (string commenterName, string commentText)
    {
        this.commenterName = commenterName;
        this.commentText = commentText;
    }

    public string GetCommentDetails()
    {
        return $"{commenterName}: {commentText}";
    }
}