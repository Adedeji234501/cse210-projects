// Base class for goals

public class Goal
{
    public string Name { get; set; }
    public bool Completed { get; set; }

    // Constructor
    public Goal(string name)
    {
        Name = name;
        Completed = false;
    }

    // Method to mark the goal as completed
    public virtual void MarkCompleted()
    {
        Completed = true;
    }

    // Method to get the reward for completing the goal
    public virtual int GetReward()
    {
        return 0;
    }

    public virtual void RecordProgress()
    {
       Completed = true;
       Console.WriteLine($"You made progress on the {Name} goal.");
    }
}