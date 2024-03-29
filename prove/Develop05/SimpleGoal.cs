using Newtonsoft.Json.Linq;

public class SimpleGoal : Goal
{
    protected bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override int PointsEarned => _isComplete ? _points : 0;

    public override string GetStringRepresentation()
    {
        JObject jsonObject = JObject.FromObject(this);
        jsonObject.Add("Type", this.GetType().Name);
        jsonObject.Add("_isComplete", _isComplete);
        return jsonObject.ToString();
    }

}
