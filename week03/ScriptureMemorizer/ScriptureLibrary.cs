using System;

class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _random;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();
    }
    
    public void AddScripture(Reference reference, string text)
    {
        _scriptures.Add(new Scripture(reference, text));
    }

    public Scripture GetRandomScripture()
    {
        if(_scriptures.Count == 0)
        {
            throw new InvalidOperationException("Scripture Library is empty");
        }
        return _scriptures[_random.Next(_scriptures.Count)];
    }

}