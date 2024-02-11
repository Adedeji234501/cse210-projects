// Class for simple goals
public class SimpleGoal : Goal
{
    public int Reward { get; }

    // Constructor
    public SimpleGoal(string name, int reward) : base(name)
    {
        Reward = reward;
    }

    // Override methods
    public override void MarkCompleted()
    {
        base.MarkCompleted();
        Console.WriteLine($"Congratulations! You completed the {Name} goal.");
    }

    public override int GetReward()
    {
        return Reward;
    }
}