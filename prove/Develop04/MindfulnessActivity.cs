// Base class for activities
public class MindfulnessActivity
{
    protected int duration;

    public MindfulnessActivity(int duration)
    {
        this.duration = duration;
    }

    public void StartActivity()
    {
        DisplayStartingMessage();
        PrepareForActivity();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected virtual void DisplayStartingMessage()
    {
        Console.WriteLine("Welcome to the Mindfulness Activity!");
        Console.WriteLine();
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(3000);
    }

    protected virtual void PrepareForActivity()
    {
        // Common preparation steps
    }

    protected virtual void PerformActivity()
    {
        // Common activity steps
    }

    protected virtual void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Great job! You have completed the activity.");
        Console.WriteLine($"Activity duration: {duration} seconds");
        Thread.Sleep(3000);
    }
}