using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int userLevel = 1;
    private static int userExperience = 0;
    private static int experienceToNextLevel = 100;

    static void Main(string[] args)
    {
        LoadGoals(); // Load goals from file
        DisplayMenu();
    }

    static void DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine("\nEternal Quest Menu");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    DisplayGoals();
                    break;
                case "4":
                    DisplayScore();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    SaveGoals(); // Save before exiting
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddGoal()
    {
        Console.WriteLine("Add Goal");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Developing Goal"); // Added option for Progressive Goal
    Console.WriteLine("5. Negative Goal"); // Added option for Negative Goal
    Console.Write("Enter goal type (1-5): ");

        string type = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        switch (type)
        {
            case "1":
                Console.Write("Enter reward for completing the goal: ");
                int reward = int.Parse(Console.ReadLine());
                goals.Add(new SimpleGoal(name, reward));
                break;
            case "2":
                Console.Write("Enter reward for making progress on the goal: ");
                int eternalReward = int.Parse(Console.ReadLine());
                goals.Add(new EternalGoal(name, eternalReward));
                break;
            case "3":
                Console.Write("Enter target count for the checklist goal: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus reward for completing the checklist goal: ");
                int bonusReward = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, targetCount, bonusReward));
                break;
            case "4":
                Console.Write("Enter target progress for the progressive goal: ");
                int targetProgress = int.Parse(Console.ReadLine());
                goals.Add(new DevelopingGoal(name, targetProgress));
                break;
            case "5":
                Console.Write("Enter penalty for engaging in the bad habit: ");
                int penalty = int.Parse(Console.ReadLine());
                goals.Add(new NegativeGoal(name, penalty));
                break;
            default:
                Console.WriteLine("Invalid goal type. Please try again.");
                break;
        }
    }

    static void UpdateExperience(int pointsEarned)
    {
        userExperience += pointsEarned;
        while (userExperience >= experienceToNextLevel)
        {
            userExperience -= experienceToNextLevel;
            userLevel++;
            experienceToNextLevel += 100; // Increase experience required for next level
            Console.WriteLine($"Congratulations! You leveled up to level {userLevel}.");
        }
    }

    static void RecordEvent()
    {
        Console.WriteLine("Record Event");
        DisplayGoals();
        Console.Write("Enter goal number to record event for: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count)
        {
            Goal goal = goals[index];
            goal.RecordProgress();
            Console.WriteLine($"You earned {goal.GetReward()} points.");
            UpdateExperience(goal.GetReward());
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    static void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            Console.Write($"{i + 1}. {goal.Name}");
            if (goal.Completed)
            {
                Console.WriteLine(" [X]");
            }
            else if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($" [Completed {checklistGoal.CurrentCount}/{checklistGoal.TargetCount}]");
            }
            else
            {
                Console.WriteLine(" [ ]");
            }
        }
    }

    static void DisplayScore()
    {
        int totalScore = goals.Sum(goal => goal.GetReward());
        Console.WriteLine($"Your total score: {totalScore} points");
        Console.WriteLine($"Level: {userLevel}");
        Console.WriteLine($"Experience: {userExperience}/{experienceToNextLevel}");
    }

    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (Goal goal in goals)
            {
                string goalType = goal.GetType().Name;
                string goalData = $"{goalType},{goal.Name},{goal.Completed}";

                if (goal is SimpleGoal simpleGoal)
                {
                    writer.WriteLine($"{goalData},{simpleGoal.Reward}");
                }
                else if (goal is EternalGoal eternalGoal)
                {
                    writer.WriteLine($"{goalData},{eternalGoal.Reward}");
                }
                else if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{goalData},{checklistGoal.TargetCount},{checklistGoal.CurrentCount},{checklistGoal.BonusReward}");
                }
                else if (goal is DevelopingGoal developingGoal)
                {
                    writer.WriteLine($"{goalData}, {developingGoal.TargetProgress}");
                }
                else if (goal is NegativeGoal negativeGoal)
                {
                    writer.WriteLine($"{goalData},{negativeGoal.Penalty}");
                }
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string goalType = parts[0];
                    string goalName = parts[1];
                    bool completed = bool.Parse(parts[2]);
                    switch (goalType)
                    {
                        case nameof(SimpleGoal):
                            int reward = int.Parse(parts[3]);
                            goals.Add(new SimpleGoal(goalName, reward) { Completed = completed });
                            break;
                        case nameof(EternalGoal):
                            int eternalReward = int.Parse(parts[3]);
                            goals.Add(new EternalGoal(goalName, eternalReward) { Completed = completed });
                            break;
                        case nameof(ChecklistGoal):
                            int targetCount = int.Parse(parts[3]);
                            int currentCount = int.Parse(parts[4]);
                            int bonusReward = int.Parse(parts[5]);
                            goals.Add(new ChecklistGoal(goalName, targetCount, bonusReward, currentCount) { Completed = completed});
                            break;
                        case nameof(DevelopingGoal):
                            int developingReward = int.Parse(parts[3]);
                            goals.Add(new EternalGoal(goalName, developingReward) { Completed = completed });
                            break;
                        case nameof(NegativeGoal):
                            int negativeReward = int.Parse(parts[3]);
                            goals.Add(new EternalGoal(goalName, negativeReward) { Completed = completed });
                            break;
                    }
                }
            }
        }
    }
}

