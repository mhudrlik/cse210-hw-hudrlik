using System;

class Program
{
    static void Main()
    {
        //Console.WriteLine("Hello Learning02 World!");
        Job job1 = new Job();
        job1._JobTitle = "Software Engineer";
        job1._Company = "Microsoft";
        job1._StartYear = 2019;
        job1._EndYear = 2022;

        Job job2 = new Job();
        job2._JobTitle = "Manager";
        job2._Company = "Apple";
        job2._StartYear = 2022;
        job2._EndYear = 2023;

        job1.DisplayJobDetails();
        job2.DisplayJobDetails();

        Resume myResume = new Resume();
        myResume._Name = "Allison Rose";

        myResume._Jobs.Add(job1);
        myResume._Jobs.Add(job2);

        myResume.Display();
    }
}