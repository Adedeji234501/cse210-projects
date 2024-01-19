using System;

class Program
{
    static void Main(string[] args)
    {
        do
        {
            PlayGame();
        } while (PlayAgain());
    }
    static void PlayGame()
    
    {
        // Generate a random number between 1 and 100
        Random random = new Random();
        int magicNumber = random.Next(1, 101);

        int guess;
        int attempts = 0;

        Console.WriteLine("Welcome to the Guess My Number game!");
        Console.WriteLine("I've picked a magic number between 1 and 100. Try to guess it.");

        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            attempts++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        } while (guess != magicNumber);

        Console.WriteLine($"It took you {attempts} attempts to guess the magic number.");
    }
    static bool PlayAgain()
    {
        Console.Write("Do you want to play again? (yes/no): ");
        string playAgain = Console.ReadLine().ToLower();

        return playAgain == "yes";
    }
}