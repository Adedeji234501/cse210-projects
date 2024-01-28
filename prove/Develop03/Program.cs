using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("John 16:4", "But these things have i told you, that when the time shall come, ye may remember that i told you of them. And these things i said not unto you at the beginning, because i was with you. ");
        //Randomly select a scripture from the library
        MemorizationProgram memorizationProgram = new MemorizationProgram(scripture);
        memorizationProgram.Run();
    }
}

class MemorizationProgram
{
    private readonly Scripture scripture;

    public MemorizationProgram(Scripture scripture)
    {
        this.scripture = scripture;
    }

    public void Run()
    {
        Console.WriteLine("Welcome to the Scripture Memorization Program!");
        
        while (!scripture.AllWordsHidden)
        {
            Console.WriteLine("Press Enter to hide words, type 'quit' to end.");
            string userInput = Console.ReadLine();

            if (scripture.HideRandomWords())
            {
                Console.Clear();
                Console.WriteLine(scripture);
            }
            else if (userInput.ToLower() == "quit")
                break;
            else
            {
                Console.WriteLine("All words in the scripture are now hidden. Memorization complete!");
                break;
            }
        }
    }
}