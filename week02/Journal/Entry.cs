public class Entry
{
    public string _prompt;
    public string _response;
    public string _date;
    public string _mood;

    public Entry (string prompt, string response, string date, string mood)
    {
        //Initialize member variables
        _prompt = prompt;
        _response = response;
        _date = date;
        _mood = mood;

    }

    public string GetDisplayString()
    {
        //Return formatted string.
        return $"Date: {_date}\nPrompt: {_prompt}\nResponse: {_response}\nMood: {_mood}";
    }

    public string GetFileString()
    {
        //Return the journal entry as a string
        string safePrompt = _prompt.Replace("|", "\\|");
        string safeResponse = _response.Replace("|", "\\|");
        string safeMood = _mood.Replace("|", "\\|");
        return $"{_date} | {safePrompt} | {safeResponse} | {safeMood}";
    }

}