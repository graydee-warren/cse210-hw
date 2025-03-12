using System;

class Program
{
    // Exceeding Requirements:
    // Added a '_mood' field to the Entry class to store the user's emotional state with each entry.
    // This enhances the journal by capturing more context about the user's day, making it more reflective
    // and addressing a potential barrier to journaling (lack of emotional insight). Updated WriteNewEntry()
    // to prompt for mood, and adjusted Entry and Journal classes to handle this new field in display,
    // save, and load operations.

    static void Main(string[] args)
    {

        //Create a journal instance. 
        Journal journal = new Journal();
        
        //Variable to track user choice
        int choice; 

        do
        {
            choice = DisplayMenu();
            Console.WriteLine(); // blank for readability.

            if (choice == 1) //Write new entry.
            {
                WriteNewEntry(journal);
            }
            else if (choice == 2) //Display Journal.
            {
                journal.DisplayEntries();
            }
            else if (choice == 3) //Save Journal to file.
            {
                Console.Write("Enter filename to save: ");
                string saveFileName = Console.ReadLine();
                journal.SaveToFile(saveFileName);
            }
            else if (choice == 4) //Load journal from file
            {
                Console.Write("Enter filename to load: ");
                string loadFileName = Console.ReadLine();
                journal.LoadFromFile(loadFileName);
            }
            else if (choice == 5) // Exit.
            {
                Console.WriteLine("Goodbye!");
            }
            else //Invalid Choice.
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
            }
            
            Console.WriteLine(); //Blank line 
        }while(choice != 5);
    }

    //Used to display menu for user.
    public static int DisplayMenu()
    {
        Console.WriteLine("Journal Menu:");
        Console.WriteLine("1. Write new entry.");
        Console.WriteLine("2. Display Journal.");
        Console.WriteLine("3. Save journal to file.");
        Console.WriteLine("4. Load journal from file.");
        Console.WriteLine("5. Exit.");
        Console.Write("Enter your choice (1-5): ");

        //Get user input and conver to int then return it as choice.
        string input = Console.ReadLine();
        int choice = int.Parse(input);
        return choice;
        
    }
    
    //Mether to handle writing a new entry.
    public static void WriteNewEntry(Journal journal)
    {
        //Get random prompt from journal.
        string prompt = journal.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");

        //Get user response.
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        //See how the user is feeling.
        Console.Write("How were you feeling? (e.g.. happy, sad, tired): "); 
        string mood = Console.ReadLine();

        //Use current date.
        string date = DateTime.Now.ToString("MMMM dd, yyyy");

        //Create new entry and add to journal. 
        Entry entry = new Entry(prompt, response, date, mood);
        journal.AddEntry(entry);
        Console.WriteLine("Entry added!");
    }
}