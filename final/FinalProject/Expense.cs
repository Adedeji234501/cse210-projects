class Expense
{
    public string Category { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }

    public Expense(string category, double amount, DateTime date)
    {
        Category = category;
        Amount = amount;
        Date = date;
    }
}