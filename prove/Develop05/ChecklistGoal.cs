using Newtonsoft.Json.Linq;

public class ChecklistGoal : Goal
{
    protected int _amountCompleted;
    protected int _target;
    protected int _bonus;
    protected int _earnedPoints;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
        _earnedPoints = 0;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        _earnedPoints += _points;
        if (_amountCompleted == _target)
        {
            _earnedPoints += _bonus;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target && _amountCompleted > 0;
    }

    public override int PointsEarned => _earnedPoints;

    public override string GetDetailsString()
    {
        return $"[{(_shortName)}] {_description} Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        JObject jsonObject = JObject.FromObject(this);
        jsonObject.Add("Type", this.GetType().Name);
        jsonObject.Add("_amountCompleted", _amountCompleted);
        jsonObject.Add("_target", _target);
        jsonObject.Add("_bonus", _bonus);
        return jsonObject.ToString();
    }
}
