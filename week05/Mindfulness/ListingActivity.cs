using System;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public new void Start()
    {
        base.Start();
        ActivityLog.IncrementListing(); 
    }

    protected override void RunActivity()
    {
        Random rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("Get ready to list items");
        ShowCountdown(5);

        Console.WriteLine("Start listing items (press enter after each item, enter blank line when finished):");
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration - 5);
        
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item)) break;
            items.Add(item);
        }

        Console.WriteLine($"You listed {items.Count} items!");
    }
}