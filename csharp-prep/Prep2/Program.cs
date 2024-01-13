using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");
        
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }

        // Stretch Challenge: Determine the sign
        int lastDigit = percent % 10;
        string sign = (lastDigit >= 7) ? "+" : (lastDigit < 3) ? "-" : "";

        // Handle exceptional cases
        if (letter == "A" && sign == "+")
        {
            letter = "A-"; // No A+
        }
        else if (letter == "F" && (sign == "+" || sign == "-"))
        {
            sign = ""; // No F+ or F-
        }

        // Display the final grade with sign
        Console.WriteLine($"Your final grade is {letter}{sign}.");
    }
}