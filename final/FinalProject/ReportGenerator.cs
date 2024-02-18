// Report Generator Class
class ReportGenerator
{
    public Dictionary<string, double> GenerateIncomeBreakdown(List<Income> incomeList)
    {
        Dictionary<string, double> breakdown = new Dictionary<string, double>();
        foreach (var income in incomeList)
        {
            if (!breakdown.ContainsKey(income.Frequency))
            {
                breakdown.Add(income.Frequency, 0);
            }
            breakdown[income.Frequency] += income.Amount;
        }
        return breakdown;
    }

    public Dictionary<string, double> GenerateExpenseCategories(List<Expense> expenseList)
    {
        Dictionary<string, double> categories = new Dictionary<string, double>();
        foreach (var expense in expenseList)
        {
            if (!categories.ContainsKey(expense.Category))
            {
                categories.Add(expense.Category, 0);
            }
            categories[expense.Category] += expense.Amount;
        }
        return categories;
    }

    public double GenerateSavingsProgress(Savings savingsObj)
    {
        return (savingsObj.Balance / savingsObj.Goal) * 100;
    }
}