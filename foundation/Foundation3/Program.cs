using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new RunningActivity("03 Nov 2022", 30, 4.8),
            new CyclingActivity("03 Nov 2022", 45, 15.0),
            new SwimmingActivity("03 Nov 2022", 25, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}