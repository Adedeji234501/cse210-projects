using System;
using System.Collections.Generic;
using System.Threading;


public class Program
{
    static void Main()
    {
        Dictionary<string, int> activityLog = new Dictionary<string, int>();

        while (true)
        {
            Console.WriteLine("Mindfulness Program Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Start Gratitude Activity");
            Console.WriteLine("5. Display Activity Log");
            Console.WriteLine("6. Save Activity Log To File");
            Console.WriteLine("7. Load Activity Log From File");
            Console.WriteLine("8. Quit");
            Console.Write("Enter your choice (1-5): ");
            Console.WriteLine();

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        RunActivity(new BreathingActivity(GetDuration()), "Breathing", activityLog);
                        break;
                    case 2:
                        RunActivity(new ReflectionActivity(GetDuration()), "Reflection", activityLog);
                        break;
                    case 3:
                        RunActivity(new ListingActivity(GetDuration()), "Listing", activityLog);
                        break;
                    case 4:
                        RunActivity(new GratitudeActivity(GetDuration()), "Gratitude", activityLog);
                        break;
                    case 5:
                        DisplayActivityLog(activityLog);
                        break;
                    case 6:
                        SaveActivityLogToFile(activityLog);
                        break;
                    case 7:
                        LoadActivityLogFromFile(activityLog);
                        break;
                    case 8:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 9.");
                        break;
                    
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    static void RunActivity(MindfulnessActivity activity, string activityName, Dictionary<string, int> activityLog)
    {
        //Console.Clear(); // Clear console before starting the activity
        activity.StartActivity();

        // Log the activity
        if (activityLog.ContainsKey(activityName))
            activityLog[activityName]++;
        else
            activityLog.Add(activityName, 1);

        Console.WriteLine($"You have performed {activityName} activity {activityLog[activityName]} times.");

    }

    static int GetDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        if (!int.TryParse(Console.ReadLine(), out int duration) || duration <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer for duration.");
            Console.Write("Enter the duration of the activity in seconds: ");
        }
        return duration;
    }

    static void DisplayActivityLog(Dictionary<string, int> activityLog)
    {
        Console.WriteLine("Activity Log:");
        foreach (var entry in activityLog)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} times");
        }
        Console.WriteLine();
    }

    static void SaveActivityLogToFile(Dictionary<string, int> activityLog)
    {
        // Save the activity log to a file (you can modify the file path as needed)
        string filePath = "activity_log.txt";
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath))
        {
            foreach (var entry in activityLog)
            {
                file.WriteLine($"{entry.Key}:{entry.Value}");
            }
        }

        Console.WriteLine($"Activity log saved to {filePath}");
    }

    static void LoadActivityLogFromFile(Dictionary<string, int> activityLog)
    {
        // Load the activity log from a file (you can modify the file path as needed)
        string filePath = "activity_log.txt";
        if (System.IO.File.Exists(filePath))
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string activityName = parts[0];
                    int count;
                    if (int.TryParse(parts[1], out count))
                    {
                        activityLog[activityName] = count;
                    }
                }
            }

            Console.WriteLine($"Activity log loaded from {filePath}");
        }
        else
        {
            Console.WriteLine($"No activity log file found at {filePath}");
        }
    }
}