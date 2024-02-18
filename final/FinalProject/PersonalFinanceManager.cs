class PersonalFinanceManager
{
    private List<Income> incomeList;
    private List<Expense> expenseList;
    private Savings savingsObj;
    private DataStorage dataStorage;
    private Validation validation;
    private ReportGenerator reportGenerator;

    public PersonalFinanceManager()
    {
        incomeList = new List<Income>();
        expenseList = new List<Expense>();
        dataStorage = new DataStorage("financial_data.dat"); // Change file extension to .dat
        validation = new Validation();
        reportGenerator = new ReportGenerator();
    }

    public void AddIncome(string source, double amount, string frequency)
    {
        Income income = new Income(source, amount, frequency);
        // Validate income data
        incomeList.Add(income);
    }

    public void AddExpense(string category, double amount, DateTime date)
    {
        Expense expense = new Expense(category, amount, date);
        // Validate expense data
        expenseList.Add(expense);
    }

    public void SetSavingsGoal(double goal)
    {
        // Validate savings goal
        savingsObj = new Savings(goal);
    }

    public void UpdateSavingsBalance(double amount)
    {
        if (savingsObj != null)
        {
            savingsObj.Balance += amount;
        }
    }

    public void GenerateReports()
    {
        Dictionary<string, double> incomeBreakdown = reportGenerator.GenerateIncomeBreakdown(incomeList);
        Dictionary<string, double> expenseCategories = reportGenerator.GenerateExpenseCategories(expenseList);
        double savingsProgress = (savingsObj != null) ? reportGenerator.GenerateSavingsProgress(savingsObj) : 0;

        Console.WriteLine("Income Breakdown:");
        foreach (var item in incomeBreakdown)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        Console.WriteLine("Expense Categories:");
        foreach (var item in expenseCategories)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        Console.WriteLine($"Savings Progress: {savingsProgress}%");
    }

    public void SaveData()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("financial_data.txt"))
            {
                foreach (var income in incomeList)
                {
                    writer.WriteLine($"Income|{income.Source}|{income.Amount}|{income.Frequency}");
                }
                foreach (var expense in expenseList)
                {
                    writer.WriteLine($"Expense|{expense.Category}|{expense.Amount}|{expense.Date:yyyy-MM-dd}");
                }
                if (savingsObj != null)
                {
                    writer.WriteLine($"Savings|{savingsObj.Goal}|{savingsObj.Balance}");
                }
                Console.WriteLine("Data saved successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data: {ex.Message}");
        }
    }

    public void LoadData()
    {
        try
        {
            incomeList.Clear();
            expenseList.Clear();

            string[] lines = File.ReadAllLines("financial_data.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length > 0)
                {
                    switch (parts[0])
                    {
                        case "Income":
                            incomeList.Add(new Income(parts[1], double.Parse(parts[2]), parts[3]));
                            break;
                        case "Expense":
                            expenseList.Add(new Expense(parts[1], double.Parse(parts[2]), DateTime.Parse(parts[3])));
                            break;
                        case "Savings":
                            savingsObj = new Savings(double.Parse(parts[1]), double.Parse(parts[2]));
                            break;
                    }
                }
            }
            Console.WriteLine("Data loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
        }
    }
}