public class Activity 
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description, int duration) 
    {
        _name = name;
        _description =  description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} Activity...");
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine($"This activity will last {_duration} seconds. Get ready to begin!\n");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("\nGood job! You've completed the activity.");
        Console.WriteLine($"You spent {_duration} seconds on the {_name} Activity.\n");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        char[] spinnerChars = new char[] { '|', '/', '-', '\\' };
        int delay = 100; 
        int totalTicks = (seconds * 1000) / delay;

        for (int i = 0; i < totalTicks; i++)
        {
            Console.Write(spinnerChars[i % spinnerChars.Length]);
            Thread.Sleep(delay);
            Console.Write("\b \b");
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($" {i}  ");
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public int GetDuration()
    {
        return _duration;
    }
}