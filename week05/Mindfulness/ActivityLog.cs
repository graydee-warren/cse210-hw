using System;

static class ActivityLog
{
    private static int _breathingCount = 0;
    private static int _reflectionCount = 0;
    private static int _listingCount = 0;

    public static void IncrementBreathing() => _breathingCount++;
    public static void IncrementReflection() => _reflectionCount++;
    public static void IncrementListing() => _listingCount++;

    public static void DisplayLog()
    {
        Console.Clear();
        Console.WriteLine("Activity Log Summary:");
        Console.WriteLine($"Breathing Activity: {_breathingCount} times");
        Console.WriteLine($"Reflection Activity: {_reflectionCount} times");
        Console.WriteLine($"Listing Activity: {_listingCount} times");
        Console.WriteLine();
        Console.WriteLine("Thank you for using the Mindfulness App! Goodbye.");
    }
}