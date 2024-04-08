public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int durationInMinutes, int laps) : base(date, durationInMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000 * 0.62;
    }

    public override double GetSpeed()
    {
        return laps * 50 / 1000 * 0.62 / base.durationInMinutes * 60;
    }

    public override double GetPace()
    {
        return base.durationInMinutes / (laps * 50 / 1000 * 0.62);
    }
}