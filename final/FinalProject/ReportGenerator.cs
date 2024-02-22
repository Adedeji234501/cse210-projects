using System.Collections.Generic;

class ReportGenerator
{
    public Dictionary<string, double> GenerateIncomeBreakdown(List<Income> incomeList)
    {
        Dictionary<string, double> incomeBreakdown = new Dictionary<string, double>();

        foreach (Income income in incomeList)
        {
            if (incomeBreakdown.ContainsKey(income.Source))
                incomeBreakdown[income.Source] += income.Amount;
            else
                incomeBreakdown[income.Source] = income.Amount;
        }

        return incomeBreakdown;
    }

    public Dictionary<string, double> GenerateExpenseCategories(List<Expense> expenseList)
    {
        Dictionary<string, double> expenseCategories = new Dictionary<string, double>();

        foreach (Expense expense in expenseList)
        {
            if (expenseCategories.ContainsKey(expense.Category))
                expenseCategories[expense.Category] += expense.Amount;
            else
                expenseCategories[expense.Category] = expense.Amount;
        }

        return expenseCategories;
    }

    public double CalculateSavingsProgress(Savings savings)
    {
        if (savings == null || savings.Goal <= 0)
            return 0;

        return savings.Balance / savings.Goal * 100;
    }
}