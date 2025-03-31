using System;

abstract class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.Write("Get ready");
        ShowSpinner(3);
        Console.WriteLine();
        RunActivity();
        End();
    }

    protected abstract void RunActivity();

    protected void End()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed the {_name} Activity for {_duration} seconds!");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        char[] spinner = new char[] { '|', '/', '-', '\\' };
        int iterations = seconds * 2; 

        for (int i = 0; i < iterations; i++)
        {
            Console.Write(spinner[i % 4]);
            Thread.Sleep(500); 
            Console.Write("\b \b"); 
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}