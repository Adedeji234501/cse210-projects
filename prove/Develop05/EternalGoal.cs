// Class for eternal goals
public class EternalGoal : Goal
{
    public int Reward { get; }

    // Constructor
    public EternalGoal(string name, int reward) : base(name)
    {
        Reward = reward;
    }

    // Override methods
    public override void MarkCompleted()
    {
        base.MarkCompleted();
        Console.WriteLine($"You made progress on the {Name} goal.");
    }

    public override int GetReward()
    {
        return Reward;
    }
}