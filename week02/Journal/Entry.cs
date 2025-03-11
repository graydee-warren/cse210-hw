public class Entry
{
    public string _prompt;
    public string _response;
    public string _date;

    public Entry (string prompt, string response, string date)
    {
        //Initialize member variables
        string _prompt = prompt;
        string _response = response;
        string _date = date;

    }

    public string GetDisplayString()
    {
        //Return formatted string.
        return $"Date: {_date}\nPrompt: {_prompt}\nResponse: {_response}";
    }

    public string GetFileString()
    {
        //Return the journal entry as a string
        string safePrompt = _prompt.Replace("|", "\\|");
        string safeResponse = _response.Replace("|", "\\|");
        return $"{_date} | {safePrompt} | {safeResponse}";
    }

}