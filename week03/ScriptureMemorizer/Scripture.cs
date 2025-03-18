//Scripture: Keeps track of both the reference and the text of the scripture. Can hide words and get the rendered display of the text.

using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture (Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        //Only hide as many words as are still visible
        numberToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < numberToHide; i++)
        {
            if (visibleWords.Count > 0)
            {
                int index = random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }
    }

    public string GetDisplayText()
    {
        string wordsText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n{wordsText}";
    }
    
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }    
}