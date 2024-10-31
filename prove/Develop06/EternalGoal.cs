public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"EternalGoal '{GetShortName()}' recorded! Points earned: {GetPoints()}");
    }

    public override bool IsComplete() {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"{GetShortName()} - {GetDescription()} - {GetPoints()} points (Eternal)";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal: {GetShortName()}, {GetDescription()}, {GetPoints()}";
    }
}
