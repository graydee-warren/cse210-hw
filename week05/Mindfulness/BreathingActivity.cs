using System;

class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public new void Start()
    {
        base.Start();
        ActivityLog.IncrementBreathing(); 
    }

    protected override void RunActivity()
    {
        int timeElapsed = 0;
        while (timeElapsed < _duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);
            timeElapsed += 4;
            
            if (timeElapsed >= _duration) break;
            
            Console.WriteLine("Breathe out...");
            ShowCountdown(4);
            timeElapsed += 4;
        }
    }
}