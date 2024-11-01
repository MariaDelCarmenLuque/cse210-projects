public class Activity 
{
    private string _date;
    private int _duration;

    public Activity(string date, int duration)
    {
        _date =  date;
        _duration =  duration;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return (GetDistance()/GetDuration())*60;
    }

    public virtual double GetPace(){
        return GetDuration()/ GetDistance();
    }

    public virtual string GetSummary()
    {
        return $"{_date} {GetActivityType()} ({_duration} min) - Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }

    protected virtual string GetActivityType(){
        return "Activity";
    }
}