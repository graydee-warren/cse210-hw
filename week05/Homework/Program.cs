using System;

class Program
{
    static void Main(string[] args)
    {
        
        Assignment a1 = new Assignment("GrayDee Warren", "Math1");
        Console.WriteLine(a1.GetSummary());

        
        MathAssignment a2 = new MathAssignment("Ashley Arnold", "Math", "1", "2");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Johnny Joe", "Essay", "The Great Gatsby");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}