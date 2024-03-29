using Newtonsoft.Json.Linq;

public abstract class Goal
{
    public string _shortName;
    public string _description;
    public int _points;
    public virtual int PointsEarned { get; }

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetStringRepresentation()
    {
        JObject jsonObject = new JObject();
        jsonObject.Add("Type", this.GetType().Name);
        jsonObject.Add("_shortName", _shortName);
        jsonObject.Add("_description", _description);
        jsonObject.Add("_points", _points);
        return jsonObject.ToString();
    }


    public virtual string GetDetailsString()
    {
        return $"[{(_shortName)}] {_description}";
    }

}
