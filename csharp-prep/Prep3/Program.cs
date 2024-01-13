using System;

class Program
{
    static void Main(string[] args)
    {
        do
        {
            //Core Requirement 1: Ask for the  magic number
            Console.WriteLine("Welcome to Guess My Number! ");

            Console.Write("What is the magic number? ");
            int magicNumber = int.Parse(Console.ReadLine());

            //Core Requirement 2: Add a loop for the game
            int guess;
            int guessCount = 0;
        
            do
            {
                //Core Requirement 3: Ask for a guess
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                //Core Requirement 4: Check if the guess is higher, lower, or correct
                if (guess < magicNumber)
                    Console.WriteLine("Higher");
                else if (guess > magicNumber)
                    Console.WriteLine("Lower");
                else
                    Console.WriteLine("Correct! You guessed right. ");

            } while (guess != magicNumber);

            //Stretch Chaallenge: Inform the user of the number of guesses
            Console.WriteLine($"You guessed the correct number in {guessCount} {(guessCount == 1 ? "guess" : "guesses")}.");
            
            //Stretch Challenge: Ask if the user want to play again
            Console.Write("Do you want to play again? (yes/no): ");

        } while (Console.ReadLine().ToLower() == "yes");
    }
}