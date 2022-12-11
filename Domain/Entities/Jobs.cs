namespace Domain.Entities;
public class Job
{
    public string JobId { get; set; }
    public string JobTitle { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }
    public virtual List<JobHistory> JobHistories { get; set; }
    public virtual List<Employee> Employees { get; set; }

}