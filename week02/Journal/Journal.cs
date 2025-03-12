public class Journal
{
    public List<Entry> _entries;
    public List<string> _prompts;
    
    public Journal()
    {
        //initialze the entry and string list
        _entries = new List<Entry>();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "If I had one thing I could do over today, what would it be?",
            "What's one small victory I achieved today that I'm proud of?",        
            "How did I handle a challenge or setback today?",                     
            "What's something I noticed about the world around me today?",        
            "Who or what inspired me today, and why?",                           
            "What's one question I'd love to have answered by the end of tomorrow?" 
        };
    }

    public void AddEntry(Entry entry)
    {
        //Add entry to list
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        //Iterate through entries and display each one
        if (_entries.Count == 0)
        {
            Console.WriteLine("The Journal is emply.");
        }
        //Display each entry
        foreach (Entry entry in _entries)
        {
            Console.WriteLine("-------------------------------"); //Seperator for readability
            Console.WriteLine(entry.GetDisplayString());
            Console.WriteLine("-------------------------------"); //Seperator for readability
        }
    }

    public void SaveToFile(string filename)
    {
        //Save to file with error handling.
        try 
        {
            File.WriteAllLines(filename, _entries.Select(entry => entry.GetFileString()));
            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }

    }
    
    public void LoadFromFile(string filename)
    {
        //Load filename with error handling.
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File {filename} not found.");
                return;
            }

            // Clear current entries
            _entries.Clear();

            // Read all lines from the file
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    //Assign each part of the entry to a part.
                    string _date = parts[0];
                    string _prompt = parts[1].Replace("\\|", "|");
                    string _response = parts[2].Replace("\\|", "|");
                    string _mood = parts[3].Replace("\\|", "|");

                    // Create and add the entry
                    Entry entry = new Entry(_prompt, _response, _date, _mood);
                    _entries.Add(entry);
                }
                else
                {
                    Console.WriteLine($"Skipping invalid line: {line}");
                }
            }
            Console.WriteLine($"Journal loaded from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }

    public string GetRandomPrompt()
    {
        //Return a random prompt from the prompts list
        Random random = new Random();
        int index = random.Next(0, _prompts.Count);
        return _prompts[index];
    }
}