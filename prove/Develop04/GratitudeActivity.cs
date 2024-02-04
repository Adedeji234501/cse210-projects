// Add a new kind of activity
public class GratitudeActivity : MindfulnessActivity
{
    private List<string> listedItems;
    public GratitudeActivity(int duration) : base(duration)
    {
        listedItems = new List<string>();
    }

    protected override void DisplayStartingMessage()
    {
        Console.WriteLine("Welcome to the Gratitude Activity!");
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine("This activity will help you express gratitude by listing things you are thankful for.");
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(3000);
        Console.WriteLine();
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Starting gratitude exercise...");

        Console.WriteLine($"You have {duration} seconds to express gratitude:");

        // Allow the user to express gratitude for the specified duration
        for (int i = 0; i < duration; i++)
        {
            Console.Write("Thankful for: ");
            string item = Console.ReadLine();
            listedItems.Add(item);
            Thread.Sleep(1000);
        }
    }
    

    protected override void DisplayEndingMessage()
    {Console.WriteLine();
        Console.WriteLine("Great job! You have completed the gratitude exercise.");
        Console.WriteLine($"Activity duration: {duration} seconds");
        Thread.Sleep(3000);
        Console.WriteLine();
    }
}