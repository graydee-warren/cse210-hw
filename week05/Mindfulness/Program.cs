using System;

// Exceeding Requirements:
// To exceed the core requirements, I added an activity tracking feature through the ActivityLog class.
// This feature keeps a count of how many times each activity (Breathing, Reflection, and Listing) is completed
// during the session. The counts are stored in a static ActivityLog class and incremented after each activity finishes in their respective Start() methods. 

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Start();
                    break;
                case "2":
                    new ReflectionActivity().Start();
                    break;
                case "3":
                    new ListingActivity().Start();
                    break;
                case "4":
                    ActivityLog.DisplayLog(); 
                    Thread.Sleep(3000); 
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}