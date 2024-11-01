public class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(string date, int duration, int laps) : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetDuration()) *60;;
    }

    public override double GetPace()
    {
        return GetDuration() / GetDistance();
        
    }

    protected override string GetActivityType()
    {
    return "Swimming";
    }
}
