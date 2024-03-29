using Newtonsoft.Json.Linq;

public class EternalGoal : Goal
{
    private int _timesCompleted;
    public override int PointsEarned => _points * _timesCompleted;

    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        _timesCompleted = 0;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        JObject jsonObject = JObject.FromObject(this);
        jsonObject.Add("Type", this.GetType().Name);
        return jsonObject.ToString();
    }
}
