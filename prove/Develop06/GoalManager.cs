public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Goal Tracking Program!");
        DisplayPlayerInfo();
        Console.WriteLine("Get ready to track your goals and earn points!");

        while (true)
        {
            Console.WriteLine("You have " + _score + " points.");
            Console.WriteLine("=========================");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("=========================");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.WriteLine("=========================");
            Console.Write("Select a choice from the menu: ");
            string option = Console.ReadLine();
            Console.WriteLine();

            if (option == "6") break;

            switch (option)
            {
                case "1":
                    CreateGoalMenu();
                    break;

                case "2":
                    ListGoalNames();
                    break;

                case "3":
                    SaveGoals("goals.txt");
                    break;
                case "4":
                    Console.Write("What is the filename for the goal file? ");
                    string filename = Console.ReadLine();
                    LoadGoals(filename);
                    break;

                case "5":
                    RecordEventMenu(); 
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

        }
    }

    private void CreateGoalMenu()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create?: ");
        string type = Console.ReadLine();
        Console.WriteLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

            switch (type)
            {
                case "1":
                    Console.Write("What is the amount of points associated with this goal? ");
                    int simplePoints = int.Parse(Console.ReadLine());
                    CreateGoal(new SimpleGoal(name, description, simplePoints));
                    break;
                case "2":
                    Console.Write("What is the amount of points associated with this goal? ");
                    int eternalPoints = int.Parse(Console.ReadLine());
                    CreateGoal(new EternalGoal(name, description, eternalPoints));
                    break;
                case "3":
                    Console.Write("What is the amount of points associated with this goal? ");
                    int checklistPoints = int.Parse(Console.ReadLine());
                    Console.Write("How many time does this goal need to be accomplished for a bonus? ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    CreateGoal(new ChecklistGoal(name, description, checklistPoints, target, bonusPoints));
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
        

    private void RecordEventMenu()
    {
        Console.WriteLine("The goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        string accomplishedGoal = Console.ReadLine();
        var goal = _goals[int.Parse(accomplishedGoal) - 1]; 
        RecordEvent(goal.GetShortName());
        int pointsEarned = GetScore();
        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
    }
    public int GetScore()
    {
        return _score;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Total Score: {_score}");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
    {
        var goal = _goals[i];
        string completionStatus = goal.IsComplete() ? "[x]" : "[ ]";

        if (goal is ChecklistGoal checklistGoal)
        {
            Console.WriteLine($"{i + 1}. {completionStatus} {goal.GetShortName()} ({goal.GetDescription()}) -- Currently completed: {checklistGoal.GetAmountCompleted()}/{checklistGoal.GetTarget()}");
        }
        else
        {
            Console.WriteLine($"{i + 1}. {completionStatus} {goal.GetShortName()} ({goal.GetDescription()})");
        }
    }
    }

    public void ListGoalDetails()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetStringRepresentation());
        }
    }

    public void CreateGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (var goal in _goals)
        {
            if(goal.GetShortName() == goalName)
            {
                goal.RecordEvent();

                if(goal is ChecklistGoal checklistGoal)
                {
                    if(checklistGoal.IsComplete())
                    {
                        _score += checklistGoal.GetPoints() + checklistGoal.GetBonusPoints();
                    }
                    else 
                    {
                        _score += checklistGoal.GetPoints();
                    }
                }
                else
                {
                    _score += goal.GetPoints();
                }
                break;

            }
        }
        var lines = File.ReadAllLines("goals.txt").ToList();

        if (lines.Count > 0)
        {
            lines[0] = $"Points:{_score}";
        }
        else
        {
            lines.Add($"Points:{_score}");
        }

        
        File.WriteAllLines("goals.txt", lines);

        }

    public void SaveGoals(string filename = "goals.txt")
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Points: {_score}");
            foreach (var goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string filename = "goals.txt")
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _goals.Clear();

            foreach (string line in lines)
            {
                if (line.StartsWith("Points:"))
                {
                    _score = int.Parse(line.Split(":")[1]);
                }
                else
                {
                    Goal goal = CreateGoalFromString(line);
                    if (goal != null)
                    {
                        _goals.Add(goal);
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    private Goal CreateGoalFromString(string goalString)
    {
        string[] parts = goalString.Split(":");
        string goalType = parts[0];
        string[] parameters = parts[1].Split(",");

        switch (goalType)
        {
            case "SimpleGoal":
                var simpleGoal = new SimpleGoal(parameters[0], parameters[1], int.Parse(parameters[2]));
                simpleGoal.SetIsComplete(bool.Parse(parameters[3]));
                return simpleGoal;
            case "EternalGoal":
                return new EternalGoal(parameters[0], parameters[1], int.Parse(parameters[2]));
            case "ChecklistGoal":
                var checklistGoal = new ChecklistGoal(parameters[0], parameters[1], int.Parse(parameters[2]), int.Parse(parameters[4]), int.Parse(parameters[5]));
                checklistGoal.SetAmountCompleted(int.Parse(parameters[3]));
                return checklistGoal;
            default:
                return null;
        }
    }


}
