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
            Console.WriteLine("4. Mental Stress Relief Activity");
            Console.WriteLine("5. Quit");
            Console.WriteLine("=========================");
            Console.Write("Select a choice from the menu: ");
            string option = Console.ReadLine();
            Console.WriteLine();
            if (option == "5") break;

            Console.Write("Enter duration in seconds: ");
            int duration = int.Parse(Console.ReadLine());
            Console.WriteLine();

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
                case "4":
                    new MentalStressReliefActivity(duration).Start();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}