//Reference: Keeps track of the book,chapter, and verse information

using System;

public class Reference
{
    private string _book; //Name of the book
    private int _chapter; //Chapter number
    private int _verse; //Starting Verse
    private int _endVerse; //Ending Verse

    //Constructor for a single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    //Conbstructor for multi-verse
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;  
        _chapter = chapter; 
        _verse = startVerse; 
        _endVerse = endVerse; 
    }
    
    //Returns the reference as a strong
    public string GetDisplayText()
    {
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}