class Savings
{
    public double Goal { get; set; }
    public double Balance { get; set; }

    public Savings(double goal)
    {
        Goal = goal;
        Balance = 0;
    }
}