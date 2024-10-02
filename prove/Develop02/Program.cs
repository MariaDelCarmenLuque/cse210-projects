using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        string userChoice = "";
        Console.WriteLine("Welcome to the Journal Program: ");
        while (userChoice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display the Journal");
            Console.WriteLine("3. Load the Journal");
            Console.WriteLine("4. Save the Journal");
            Console.WriteLine("5. Exit");
            Console.Write("What do you like to do? ");
            userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                // Generate a random prompt and display it.
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                string response = Console.ReadLine();
                
                // Obtain the current date.
                string currentDate = DateTime.Now.ToShortDateString();
                
                // Create a new entry and add it to the journal.
                Entry newEntry = new Entry(currentDate, prompt, response);
                journal.AddEntry(newEntry);
            }
            else if (userChoice == "2")
            {
                // Show all entries in the journal.
                journal.DisplayAll();
            }
             else if (userChoice == "3")
            {
                // Load the journal entries from the specified file.
                Console.WriteLine("Enter the filename to load from:");
                string fileName = Console.ReadLine();
                journal.LoadFromFile(fileName);
            }
            else if (userChoice == "4")
            {
                // Save the journal entries to a specified file.
                Console.WriteLine("Enter the filename to save to:");
                string fileName = Console.ReadLine();
                journal.SaveToFile(fileName);
            }
           
        }
    }
}