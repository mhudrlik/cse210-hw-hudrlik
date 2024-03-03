using System;
using System.Collections.Generic;

public class Resume
{
    public string _Name { get; set; }
    public List<Job> _Jobs { get; set; } = new List<Job>();
    public void Display()
    {
        Console.WriteLine($"Name: {_Name}");
        Console.WriteLine("Jobs:");
        foreach (var job in _Jobs)
        {
            job.DisplayJobDetails();
        }
    }
}
