using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        
        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        
        int squaredNumber = SquareNumber(favoriteNumber);
        
        DisplayResult(userName, squaredNumber);
    }

    // Function to display welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function to prompt for the user's name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();

        return userName;
    }

    // Function to prompt for the user's favorite number and return it as an integer
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favoriteNumber = int.Parse(Console.ReadLine());
       
        return favoriteNumber;
    }

    // Function to return the square of a number
    static int SquareNumber(int number)
    {
        int squareNumber = number * number;
       
        return squareNumber;
    }

    // Function to display the result with the user's name and the squared number
    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }
}