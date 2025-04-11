// GoalManager.cs
using System;


public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private int _pointsToNextLevel;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _pointsToNextLevel = 100; 
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\nGoal Manager Menu:");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Create Goal");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Save Goals");
            Console.WriteLine("7. Load Goals");
            Console.WriteLine("8. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayPlayerInfo();
                    break;
                case "2":
                    ListGoalNames();
                    break;
                case "3":
                    ListGoalDetails();
                    break;
                case "4":
                    CreateGoal();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    SaveGoals();
                    break;
                case "7":
                    LoadGoals();
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Level: {_level}");
        Console.WriteLine($"Current Score: {_score} points");
        Console.WriteLine($"Points to Next Level: {_pointsToNextLevel - _score} (Total for Level {_level + 1}: {_pointsToNextLevel})");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Goal Details:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        string type = Console.ReadLine();

        Console.Write("Enter Goal Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Goal Description: ");
        string description = Console.ReadLine();
        Console.Write("Enter Goal Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("Enter Target Count: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter Bonus Points: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Select a goal to record an event for: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            goal.RecordEvent();

          
            int pointsEarned = goal.Points;
            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                pointsEarned += checklistGoal.Bonus;
            }

            
            _score += pointsEarned;

            
            CheckLevelUp();
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    private void CheckLevelUp()
    {
      
        int baseScore = _score; 
        int currentLevel = _level;
        int pointsToNext = _pointsToNextLevel;

        while (baseScore >= pointsToNext)
        {
            currentLevel++;
            pointsToNext = currentLevel * 100; 
        }


        if (currentLevel > _level)
        {
            int levelsGained = currentLevel - _level;
            int bonusPoints = levelsGained * 10; // 

            
            _level = currentLevel;
            _score += bonusPoints;
            _pointsToNextLevel = pointsToNext;

            
            for (int i = 0; i < levelsGained; i++)
            {
                int newLevel = _level - (levelsGained - 1 - i);
                Console.WriteLine($"Congratulations! You've reached Level {newLevel}!");
                Console.WriteLine("You earned a 10-point bonus for leveling up!");
            }
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score); 
            writer.WriteLine(_level); 
            writer.WriteLine(_pointsToNextLevel); 
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _goals.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                
                _score = int.Parse(reader.ReadLine());
                _level = int.Parse(reader.ReadLine());
                _pointsToNextLevel = int.Parse(reader.ReadLine());

                
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(":");
                    string type = parts[0];
                    string[] data = parts[1].Split(",");

                    if (type == "SimpleGoal")
                    {
                        string name = data[0];
                        string description = data[1];
                        int points = int.Parse(data[2]);
                        bool isComplete = bool.Parse(data[3]);
                        var goal = new SimpleGoal(name, description, points);
                        if (isComplete) goal.RecordEvent(); 
                        _goals.Add(goal);
                    }
                    else if (type == "EternalGoal")
                    {
                        string name = data[0];
                        string description = data[1];
                        int points = int.Parse(data[2]);
                        _goals.Add(new EternalGoal(name, description, points));
                    }
                    else if (type == "ChecklistGoal")
                    {
                        string name = data[0];
                        string description = data[1];
                        int points = int.Parse(data[2]);
                        int target = int.Parse(data[3]);
                        int bonus = int.Parse(data[4]);
                        int amountCompleted = int.Parse(data[5]);
                        var goal = new ChecklistGoal(name, description, points, target, bonus);
                        for (int i = 0; i < amountCompleted; i++)
                        {
                            goal.RecordEvent(); 
                        }
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
}