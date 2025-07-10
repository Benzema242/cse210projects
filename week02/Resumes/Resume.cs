public class Resumes
{
    // Responsibilities:
    // Keep track of the person's name and a list of their jobs.

    public string _name;
    public List<Job> _jobs = new List<Job>();

    // Display method to the Resumes class.
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job job in _jobs)
        {
            // Call the Display method of each job
            job.Display();
        }
    }
}   
