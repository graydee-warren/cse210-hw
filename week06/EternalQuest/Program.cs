// Program.cs
using System;

class Program
{
    // Exceeding Requirements:
    // To exceed the core requirements, I added a gamification feature: a leveling system.
    // The player starts at Level 1 and levels up by accumulating points. Each level requires
    // 100 * level points to achieve (e.g., Level 2 requires 200 points, Level 3 requires 300 points).

    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}