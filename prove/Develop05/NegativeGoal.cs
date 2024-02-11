// Class for negative goals
public class NegativeGoal : Goal
{
    public int Penalty { get; }
    

    // Constructor
    public NegativeGoal(string name, int penalty) : base(name)
    {
        Penalty = penalty;
    }

    // Method to record progress (in the case of negative goals, recording progress means engaging in the bad habit)
    public new virtual void RecordProgress()
    {
        base.RecordProgress();
        Console.WriteLine($"You engaged in the bad habit: {Name}. You lost {Penalty} points.");
    }

    // Override method
    public override int GetReward()
    {
        return Completed ? 0 : -Penalty; // Lose penalty points when not completed
    }
}