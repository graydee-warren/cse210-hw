using System;
using System.Globalization;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squareNumber = SquareNumber(userNumber);

        DisplayResult(userName, squareNumber);
    }


    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program");
    }


    static string PromptUserName()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        return name; 
    }


    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }


    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }


    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}.");
    }

}