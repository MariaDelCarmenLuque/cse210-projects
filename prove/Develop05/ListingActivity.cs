public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration)
        : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", duration) { }

    public void Start()
    {
        DisplayStartingMessage();
        Console.WriteLine("List items based on the following prompt:");
        Console.WriteLine(_prompts[new Random().Next(_prompts.Count)]);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        int itemCounter = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            Console.ReadLine();
            itemCounter++;
        }

        Console.WriteLine($"You listed {itemCounter} items.");
        DisplayEndingMessage();
    }
}
