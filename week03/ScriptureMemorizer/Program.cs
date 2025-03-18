/* 
    1. Added a ScriptureLibrary class that stores multiple scriptures
    2. Randomly selects a scripture from the library for each run
    3. Includes a diverse set of scriptures with both single verses and verse ranges
    4. Maintains all original functionality while adding this new feature
*/
using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();
        library.AddScripture(new Reference("John", 3, 16), 
            "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life");
        library.AddScripture(new Reference("Proverbs", 3, 5, 6), 
            "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight");
        library.AddScripture(new Reference("Psalm", 23, 1), 
            "The Lord is my shepherd, I shall not want");
        library.AddScripture(new Reference("Matthew", 5, 3, 4), 
            "Blessed are the poor in spirit, for theirs is the kingdom of heaven. Blessed are those who mourn, for they will be comforted");
        Scripture scripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            
            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.Write("\nPress Enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(2); // Hide 2 words at a time
        }
    }
}