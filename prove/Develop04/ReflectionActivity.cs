// Reflection activity class
public class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> reflectionQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base(duration) { }

    protected override void DisplayStartingMessage()
    {
        Console.WriteLine("Welcome to the Reflection Activity!");
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine("This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(3000);
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Starting reflection exercise...");

        for (int i = 0; i < duration;)
        {
            string prompt = GetRandomPrompt();
            Console.WriteLine(prompt);
            DisplaySpinner(5); // Display spinner for 5 seconds
            i += 5;

            foreach (var question in reflectionQuestions)
            {
                Console.WriteLine(question);
                Thread.Sleep(3000); // Pause for reflection
                DisplaySpinner(2); // Display spinner for 2 seconds
                i += 2;
            }
        }
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return prompts[random.Next(prompts.Count)];
    }

    private void DisplaySpinner(int seconds)
    {
        Console.Write("Reflecting: ");
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write("-");
            Thread.Sleep(250);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write("\\");
            Thread.Sleep(250);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write("|");
            Thread.Sleep(250);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
        Console.WriteLine();
    }

    protected override void DisplayEndingMessage()
    {
        Console.WriteLine("Great job! You have completed the reflection exercise.");
        Console.WriteLine($"Activity duration: {duration} seconds");
        Thread.Sleep(3000);
    }
}