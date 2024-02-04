public class ListingActivity : MindfulnessActivity
{
    private List<string> listingPrompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
        // Add more listing prompts
    };

    private List<string> listedItems;

    public ListingActivity(int duration) : base(duration)
    {
        listedItems = new List<string>();
    }

    protected override void DisplayStartingMessage()
    {
        Console.WriteLine("Welcome to the Listing Activity!");
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(3000);
        Console.WriteLine();
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Starting listing exercise...");

        for (int i = 5; i < duration;)
        {
            string prompt = GetRandomPrompt();
            Console.WriteLine(prompt);
            DisplayCountdown(5); // Display countdown for 5 seconds
            

            Console.WriteLine("Start listing items:");
            Thread.Sleep(3000); // Pause before listing

            
            Console.Write($"Item: ");
            string item = Console.ReadLine();
            listedItems.Add(item);
            
            i += 5;

            Console.WriteLine($"You listed {listedItems.Count} items.");
            listedItems.Clear(); // Clear the list for the next round
        }
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return listingPrompts[random.Next(listingPrompts.Count)];
    }

    private void DisplayCountdown(int seconds)
    {
        Console.Write("Countdown: ");
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);
        }
        Console.WriteLine();
    }

    protected override void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Great job! You have completed the listing exercise.");
        Console.WriteLine($"Activity duration: {duration} seconds");
        Thread.Sleep(3000);
    }
}