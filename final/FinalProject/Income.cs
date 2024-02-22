class Income
{
    public string Source { get; set; }
    public double Amount { get; set; }
    public string Frequency { get; set; }

    public Income(string source, double amount, string frequency)
    {
        Source = source;
        Amount = amount;
        Frequency = frequency;
    }
}
