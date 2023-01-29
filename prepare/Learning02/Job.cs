using System;

public class Job
{
    public string _JobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
            Console.WriteLine($"{_JobTitle}({_company}){_startYear}-{_endYear}");
    }
}