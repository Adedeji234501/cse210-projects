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
        dataStorage = new DataStorage("financial_data.json"); // Change file extension to .json
        validation = new Validation();
        reportGenerator = new ReportGenerator();
    }

    public void AddIncome(string source, double amount, string frequency)
    {
        Income income = new Income(source, amount, frequency);
        if (validation.ValidateIncome(source, amount, frequency))
            incomeList.Add(income);
    }

    public void AddExpense(string category, double amount, DateTime date)
    {
        Expense expense = new Expense(category, amount, date);
        if (validation.ValidateExpense(category, amount, date))
            expenseList.Add(expense);
    }

    public void SetSavingsGoal(double goal)
{
    if (savingsObj == null)
    {
        savingsObj = new Savings(goal);
    }
    else
    {
        savingsObj.Goal = goal;
    }
}

    public void UpdateSavingsBalance(double amount)
    {
        if (savingsObj != null)
            savingsObj.Balance += amount;
    }

    public void GenerateReports()
    {
        var incomeBreakdown = reportGenerator.GenerateIncomeBreakdown(incomeList);
        var expenseCategories = reportGenerator.GenerateExpenseCategories(expenseList);
        double savingsProgress = (savingsObj != null) ? reportGenerator.CalculateSavingsProgress(savingsObj) : 0;

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
        dataStorage.SaveData(this);
        Console.WriteLine("Data saved successfully.");
    }

    public void LoadData()
    {
        var loadedData = dataStorage.LoadData();
        if (loadedData != null)
        {
            incomeList = loadedData.incomeList;
            expenseList = loadedData.expenseList;
            savingsObj = loadedData.savingsObj;
            Console.WriteLine("Data loaded successfully.");
        }
    }
}


