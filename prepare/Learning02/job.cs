using System;

public class Job
{
    public string _JobTitle { get; set; }
    public string _Company { get; set; }
    public int _StartYear { get; set; }
    public int _EndYear { get; set; }

    public void DisplayJobDetails()
    {
        string jobInfo = $"{_JobTitle} ({_Company}) {_StartYear}-{_EndYear}";
        Console.WriteLine(jobInfo);
    }
}
