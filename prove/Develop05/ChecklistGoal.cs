// Class for checklist goals
public class ChecklistGoal : Goal
{
    public int TargetCount { get; }
    public int CurrentCount { get; set; }
    public int BonusReward { get; }

    // Constructor
    public ChecklistGoal(string name, int targetCount, int bonusReward, int currentCount = 0) : base(name)
    {
        TargetCount = targetCount;
        BonusReward = bonusReward;
        CurrentCount = currentCount;
    }

    // Method to record progress
    public new virtual void RecordProgress()
    {
        base.RecordProgress();

        if (!Completed) // Only record progress if the goal is not already completed
        {
            CurrentCount++;
            if (CurrentCount == TargetCount)
            {
                MarkCompleted();
            }
            else
            {
                Console.WriteLine($"You made progress on the {Name} goal.");
            }
        }
        else
        {
            Console.WriteLine($"The {Name} goal is already completed.");
        }
    }
    // Override method
    public override int GetReward()
    {
        if (Completed)
        {
            return BonusReward;
        }
        else
        {
            return 0;
        }
    }
}