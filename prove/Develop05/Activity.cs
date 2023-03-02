// Define the derived classes for each type of goal

public abstract class Goal
{
     public virtual int Score => IsComplete ? PointValue : 0;//If the goal is complete, the score is equal to the PointValue:0
    public string Description { get; }
    public int PointValue { get; }
    public abstract bool IsComplete { get; protected set; }

    public Goal(string description, int pointValue)
    {
        Description = description;
        PointValue = pointValue;
    }

    public abstract void Print();
    public abstract void RecordEvent();
}

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string description, int pointValue) : base(description, pointValue)
    {
        _isComplete = false;
    }

    public override bool IsComplete
    {
        get { return _isComplete; }
        protected set { _isComplete = value; }
    }

    public override void Print()
    {
        Console.WriteLine(Description + " (" + (IsComplete ? "complete" : "incomplete") + ")");
    }

    public override void RecordEvent()
    {
        IsComplete = true;
    }
}

public class EternalGoal : Goal
{
    private bool _isComplete;
    public override bool IsComplete
    {
        get{return _isComplete;}
        protected set{ _isComplete = true; }// protected to match the base class
    }

    public EternalGoal(string description, int pointValue) : base(description, pointValue)
    {
    }

    public override void Print()
    {
        Console.WriteLine(Description + " (eternal)");
    }

    public override void RecordEvent()
    {
        // No-op
    }
}

public class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    public int EventCount { get; private set; }

    public override bool IsComplete
    {
        get { return EventCount >= TargetCount; }
        protected set{/*read*/}
    }

    public ChecklistGoal(string description, int pointValue, int targetCount)
        : base(description, pointValue)
    {
        TargetCount = targetCount;
        EventCount = 0;
    }

    public ChecklistGoal(string description, int pointValue, int targetCount, int eventCount)
        : base(description, pointValue)
    {
        TargetCount = targetCount;
        EventCount = eventCount;
    }

    public override void Print()
    {
        Console.Write("[");
        for (int i = 0; i < TargetCount; i++)
        {
            if (i < EventCount)
            {
                Console.Write("X");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine("] " + base.Description);
    }

    public override void RecordEvent()
    {
        
        if (EventCount < TargetCount)
        {
            EventCount++;
            if (IsComplete)
            {
                int newPointValue = PointValue * 2;
                int newTargetCount = TargetCount * 2;
                ChecklistGoal newGoal = new ChecklistGoal(Description, newPointValue, TargetCount, EventCount);
        }
    }
}
}