using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        // Call PromptUserName function and store the returned value
        string userName = PromptUserName();

        // Call PromptUserNumber function and store the returned value
        int userNumber = PromptUserNumber();

        // Call SquareNumber function with the userNumber and store the squared value
        int squaredNumber = SquareNumber(userNumber);

        // Call DisplayResult function with userName and squaredNumber
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        // Use int.Parse to convert the input to an integer
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        // Calculate the square of the given number
        return number * number;
    }

    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }

}