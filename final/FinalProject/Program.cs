using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Personal Finance Manager");
            Console.WriteLine("========================");
            Console.WriteLine("1. Income Activity");
            Console.WriteLine("2. Expense Activity");
            Console.WriteLine("3. Savings Activity");
            Console.WriteLine("4. Report Generator");
            Console.WriteLine("5. Data Storage");
            Console.WriteLine("6. Validation");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        IncomeActivity();
                        break;
                    case 2:
                        ExpenseActivity();
                        break;
                    case 3:
                        SavingsActivity();
                        break;
                    case 4:
                        ReportGeneratorActivity();
                        break;
                    case 5:
                        DataStorageActivity();
                        break;
                    case 6:
                        ValidationMain();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void IncomeActivity()
    {
        Console.Clear();
        Console.WriteLine("Income Activity");
        Console.WriteLine("=================");
        // Prompt user for income details
    Console.Write("Enter source name: ");
    string source = Console.ReadLine();
    Console.Write("Enter amount: ");
    double amount = Convert.ToDouble(Console.ReadLine());
    Console.Write("Enter frequency: ");
    string frequency = Console.ReadLine();
    
    // Validate input (optional)
    if (validation.ValidateIncome(source, amount, frequency))
    {
        Console.WriteLine("Income source added successfully!");
    }
    else
    {
        Console.WriteLine("Invalid input. Please try again.");
    }
}
    static void ExpenseActivity()
    {
        Console.Clear();
        Console.WriteLine("Expense Activity");
        Console.WriteLine("=================");
        // Prompt user for expense details
    Console.Write("Enter category: ");
    string category = Console.ReadLine();
    Console.Write("Enter amount: ");
    double amount = Convert.ToDouble(Console.ReadLine());
    Console.Write("Enter date (YYYY-MM-DD): ");
    DateTime date = Convert.ToDateTime(Console.ReadLine());
    
    // Validate input (optional)
    if (validation.ValidateExpense(category, amount, date))
    {
        Console.WriteLine("Expense added successfully!");
    }
    else
    {
        Console.WriteLine("Invalid input. Please try again.");
    }
}

    static void SavingsActivity()
    {
        Console.Clear();
        Console.WriteLine("Savings Activity");
        Console.WriteLine("=================");
        // Prompt user to set savings goal
    Console.Write("Enter savings goal: ");
    double goal = Convert.ToDouble(Console.ReadLine());
    
    // Validate input (optional)
    if (validation.ValidateSavingsGoal(goal))
    {
        // Set savings goal
        SetSavingsGoal(goal);
        Console.WriteLine("Savings goal set successfully!");
        
        // Prompt user to update savings balance
        Console.Write("Enter amount to update savings balance: ");
        double amount = Convert.ToDouble(Console.ReadLine());
        UpdateSavingsBalance(amount);
        Console.WriteLine("Savings balance updated successfully!");
    }
    else
    {
        Console.WriteLine("Invalid input. Please try again.");
    }
}

    private static void UpdateSavingsBalance(double amount)
    {
        throw new NotImplementedException();
    }

    private static void SetSavingsGoal(double goal)
    {
        throw new NotImplementedException();
    }

    static void ReportGeneratorActivity()
    {
        Console.Clear();
        Console.WriteLine("Report Generator Activity");
        Console.WriteLine("=================");
        // Generate reports
        GenerateReports();
}

    private static void GenerateReports()
    {
        throw new NotImplementedException();
    }

    static void DataStorageActivity()
    {
        Console.Clear();
        Console.WriteLine("Data Storage Activity");
        Console.WriteLine("=================");
        // Save data
        SaveData();
        Console.WriteLine("Financial data saved successfully!");
    
        // Load data
        LoadData();
        Console.WriteLine("Financial data loaded successfully!");
    }

    private static void LoadData()
    {
        throw new NotImplementedException();
    }

    private static void SaveData()
    {
        throw new NotImplementedException();
    }

    static Validation validation = new Validation();

    static void ValidationMain()
    {
        // Example usage
        ValidateIncomeExample();
        ValidateExpenseExample();
        ValidateSavingsGoalExample();
    }

    static void ValidateIncomeExample()
    {
        Console.WriteLine("Validating Income");
        Console.WriteLine("=================");
        string source = "Salary";
        double amount = 2000.0;
        string frequency = "Monthly";
        
        if (validation.ValidateIncome(source, amount, frequency))
        {
            Console.WriteLine("Income data is valid.");
        }
    }

    static void ValidateExpenseExample()
    {
        Console.WriteLine("\nValidating Expense");
        Console.WriteLine("==================");
        string category = "Groceries";
        double amount = 150.0;
        DateTime date = DateTime.Now;
        
        if (validation.ValidateExpense(category, amount, date))
        {
            Console.WriteLine("Expense data is valid.");
        }
    }

    static void ValidateSavingsGoalExample()
    {
        Console.WriteLine("\nValidating Savings Goal");
        Console.WriteLine("======================");
        double goal = 10000.0;
        
        if (validation.ValidateSavingsGoal(goal))
        {
            Console.WriteLine("Savings goal is valid.");
        }
    }

    static void StartActivity(string activityName, int duration)
    {
        Console.WriteLine($"You are about to start {activityName}.");
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
        Console.WriteLine("Starting in 3...");
        Thread.Sleep(1000); // Pause for 1 second
        Console.WriteLine("2...");
        Thread.Sleep(1000); // Pause for 1 second
        Console.WriteLine("1...");
        Thread.Sleep(1000); // Pause for 1 second
        Console.WriteLine("Begin!");
        Thread.Sleep(duration * 1000); // Pause for the specified duration
        Console.WriteLine("Activity completed.");
    }
    
    static void EndActivity(string activityName, int duration)
    {
        Console.WriteLine($"Congratulations! You've completed {activityName}.");
        Console.WriteLine($"You spent {duration} seconds on this activity.");
        Console.WriteLine("Well done!");
        Thread.Sleep(3000); // Pause for 3 seconds
    }
}