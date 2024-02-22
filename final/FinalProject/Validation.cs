class Validation
{
    public bool ValidateIncome(string source, double amount, string frequency)
    {
        if (string.IsNullOrEmpty(source) || amount <= 0 || string.IsNullOrEmpty(frequency))
        {
            Console.WriteLine("Invalid income data. Please ensure all fields are filled correctly.");
            return false;
        }
        return true;
    }

    public bool ValidateExpense(string category, double amount, DateTime date)
    {
        if (string.IsNullOrEmpty(category) || amount <= 0 || date == DateTime.MinValue)
        {
            Console.WriteLine("Invalid expense data. Please ensure all fields are filled correctly.");
            return false;
        }
        return true;
    }

    public bool ValidateSavingsGoal(double goal)
    {
        if (goal <= 0)
        {
            Console.WriteLine("Invalid savings goal. Please enter a positive value.");
            return false;
        }
        return true;
    }
}