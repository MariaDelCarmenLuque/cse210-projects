using System;

class Program
{
    static void Main(string[] args)
    {
      while (true)
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("=========================");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine("=========================");
            Console.Write("Select a choice from the menu: ");

            string option = Console.ReadLine();
            if (option == "4") break;

            Console.Write("Enter duration in seconds: ");
            int duration = int.Parse(Console.ReadLine());

            switch (option)
            {
                case "1":
                    new BreathingActivity(duration).Start();
                    break;
                case "2":
                    new ReflectingActivity(duration).Start();
                    break;
                case "3":
                    new ListingActivity(duration).Start();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}