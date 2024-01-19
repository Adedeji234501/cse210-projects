using System;

public class Journal
{
    public List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void WriteNewEntry()
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What unexpected joy did I experience today?",
            "In what ways did I challenge myself today?",
            "How did I practice self-care or self-love today?",
            "Share a quote or saying that resonated with you today.",
            "Write about a place you visited or wish to visit and why."
        };

        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.Write("Response: ");
        string response = Console.ReadLine();
        string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        Console.Write("Rate your day (1-5): ");
        int rating;
        if (int.TryParse(Console.ReadLine(), out rating) && rating >= 1 && rating <= 5)
        {
            entries.Add(new Entry { PromptText = randomPrompt, EntryText = response, Date = currentDate, Rating = rating });
        }
        else
        {
            Console.WriteLine("Invalid rating. Entry not saved.");
        }
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.PromptText}");
            Console.WriteLine($"Response: {entry.EntryText}");
            Console.WriteLine($"Rating: {entry.Rating}\n");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.PromptText},{entry.EntryText},{entry.Rating}");
            }
        }

        Console.WriteLine("Journal saved successfully!");
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);

            foreach (var line in lines)
            {
                string[] parts = line.Split(",");
                if (parts.Length == 3)
                {
                    entries.Add(new Entry
                    {
                        Date = parts[0],
                        PromptText = parts[1],
                        EntryText = parts[2]
                        
                    });
                }
            }

            Console.WriteLine("Journal loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found. No entries loaded.");
        }
    }
}

