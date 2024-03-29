using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _totalPointsEarned;
    public int TotalScore => _score;
    public int TotalPointsEarned => _totalPointsEarned;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _totalPointsEarned = 0;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_totalPointsEarned}");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {(_goals[i].GetDetailsString())}");
        }
    }


    public void ListGoalDetails()
    {
        int totalPointsEarnedFromGoals = 0;

        foreach (var goal in _goals)
        {
            totalPointsEarnedFromGoals += goal.PointsEarned; // Accumulate points earned from each goal
            Console.WriteLine($"{goal.GetDetailsString()} [Complete: {goal.IsComplete()}]");
        }

        Console.WriteLine($"Total Points Earned from Goals: {totalPointsEarnedFromGoals}");
    }



    public void CreateGoal(string name, string description, int points, GoalType goalType, int target = 0, int bonus = 0)
    {
        Goal newGoal;
        switch (goalType)
        {
            case GoalType.Simple:
                newGoal = new SimpleGoal(name, description, points);
                break;
            case GoalType.Eternal:
                newGoal = new EternalGoal(name, description, points);
                break;
            case GoalType.Checklist:
                if (bonus == 0)
                {
                    throw new ArgumentException("Bonus must be specified for checklist goals.");
                }
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                throw new ArgumentException("Invalid goal type.");
        }
        _goals.Add(newGoal);
    }


    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            goal.RecordEvent();

            switch (goal)
            {
                case SimpleGoal _:
                    _totalPointsEarned += goal.PointsEarned;
                    break;
                case ChecklistGoal checklistGoal:
                    if (checklistGoal.IsComplete())
                    {
                        _totalPointsEarned += checklistGoal.PointsEarned;
                    }
                    else
                    {
                        _totalPointsEarned += goal.PointsEarned;
                    }
                    break;
                case EternalGoal _:
                    break;
            }

            Console.WriteLine($"Event recorded for goal: {goal._shortName}");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }



    public void SaveGoals(string filename)
    {
        JObject jsonGoalManager = new JObject();
        jsonGoalManager.Add("TotalPointsEarned", _totalPointsEarned);

        JArray jsonGoals = new JArray();
        foreach (var goal in _goals)
        {
            JObject jsonObject = JObject.Parse(goal.GetStringRepresentation());
            jsonGoals.Add(jsonObject);
        }

        jsonGoalManager.Add("Goals", jsonGoals);

        string json = jsonGoalManager.ToString();
        File.WriteAllText(filename, json);
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            JObject jsonGoalManager = JObject.Parse(json);

            _totalPointsEarned = (int)jsonGoalManager["TotalPointsEarned"];

            JArray jsonGoals = (JArray)jsonGoalManager["Goals"];
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new GoalConverter());
            _goals = jsonGoals.ToObject<List<Goal>>(JsonSerializer.Create(settings));

            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File does not exist.");
        }
    }

    public void CreateNewSimpleGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points for the goal: ");
        int points = int.Parse(Console.ReadLine());

        CreateGoal(name, description, points, GoalType.Simple);

        Console.WriteLine("Simple Goal created successfully.");
    }


    public void CreateNewEternalGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points for the goal: ");
        int points = int.Parse(Console.ReadLine());

        CreateGoal(name, description, points, GoalType.Eternal);

        Console.WriteLine("Eternal Goal created successfully.");
    }

    public void CreateNewChecklistGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points for the goal: ");
        int points = int.Parse(Console.ReadLine());

        Console.Write("Enter target for the checklist goal: ");
        int target = int.Parse(Console.ReadLine());

        Console.Write("Enter bonus for completing the checklist goal: ");
        int bonus = int.Parse(Console.ReadLine());

        CreateGoal(name, description, points, GoalType.Checklist, target, bonus);

        Console.WriteLine("Checklist Goal created successfully.");
    }
    public void RecordEvent()
    {
        Console.WriteLine("Select a goal to record event for:");
        ListGoalNames();
        Console.Write("Enter the index of the goal: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        RecordEvent(index);
    }

}

public enum GoalType
{
    Simple,
    Eternal,
    Checklist
}
