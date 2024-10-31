public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

     public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }

    public int GetTarget()
    {
        return _target;
    }

    public int GetBonusPoints()
    {
        return _bonus;
    }
    public override void RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted >= _target)
        {
            Console.WriteLine($"ChecklistGoal '{GetShortName()}' completed! Points earned: {GetPoints() + _bonus}");
        }
        else
        {
            Console.WriteLine($"Progress on '{GetShortName()}': {_amountCompleted}/{_target}");
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{GetShortName()} - {GetDescription()} - {GetPoints()} points ({_amountCompleted}/{_target} completed)";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal: {GetShortName()}, {GetDescription()}, {GetPoints()}, {_bonus}, {_target}, {_amountCompleted}";
    }
}
