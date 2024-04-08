public class Running : Activity
{
    private double distance;

    public Running(DateTime date, int durationInMinutes, double distance) : base(date, durationInMinutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / base.durationInMinutes * 60;
    }

    public override double GetPace()
    {
        return base.durationInMinutes / distance;
    }
}