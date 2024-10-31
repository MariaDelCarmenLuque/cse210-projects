public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public bool GetIsComplete()
    {
        return _isComplete;
    }

    public void SetIsComplete(bool complete)
    {
        _isComplete = complete;
    }

    public override void RecordEvent()
    {
          if (!_isComplete)
        {
            Console.WriteLine($"SimpleGoal '{GetShortName()}' completed! Points earned: {GetPoints()}");
            _isComplete = true;
        }
        else
        {
            Console.WriteLine($"SimpleGoal '{GetShortName()}' has already been completed.");
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        return $"{GetShortName()} - {GetDescription()} - {GetPoints()} points (Simple)";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal: {GetShortName()}, {GetDescription()}, {GetPoints()}, {_isComplete}";
    }
}
