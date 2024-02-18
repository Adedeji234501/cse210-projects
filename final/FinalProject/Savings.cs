// Savings Class
class Savings
{
    public double Goal { get; set; }
    public double Balance { get; set; }

    public Savings(double goal, double v)
    {
        Goal = goal;
        Balance = 0;
    }

    public Savings(double goal)
    {
        Goal = goal;
    }
}