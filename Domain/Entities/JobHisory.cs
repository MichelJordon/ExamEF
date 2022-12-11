namespace Domain.Entities;
public class JobHistory{
    public int EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string JobId{get; set;}
    public virtual Job Job{get; set;}
    public int DepartmentId{get;set;}
    public virtual Department Department{get;set;}
}