public class Job
{
    //Responsibilities:
    //Keep track of the company name, job title, start year, and end of year.


    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    //Display method to the Job class.
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }

}
    
    
