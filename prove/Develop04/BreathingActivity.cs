// Breathing activity class
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration) : base(duration) { }

    protected override void DisplayStartingMessage()
    {
        Console.WriteLine("Welcome to the Breathing Activity!");
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine("This activity will help you relax by guiding you through deep breathing.");
        Console.WriteLine("Clear your mind and focus on your breathing.");
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(3000);
        Console.WriteLine();
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Starting breathing exercise...");

        for (int i = 5; i < duration; i++)
        {
            Console.WriteLine((i % 2 == 0) ? "Breathe in..." : "Breathe out...");
            DisplayCountdown(5);
            Thread.Sleep(1000);
        }
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
        Console.WriteLine("Great job! You have completed the breathing exercise.");
        Console.WriteLine($"Activity duration: {duration} seconds");
        Thread.Sleep(3000);
    }
}