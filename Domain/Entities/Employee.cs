namespace Domain.Entities;
using Microsoft.AspNetCore.Http;
public class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public int JobId { get; set; }
    public virtual Job Job { get; set; }
    public int CommissionPct { get; set; }
    public int ManagerId { get; set; }
    public Employee? Manager { get; set; }
    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; }
    public IFormFile File { get; set; }
    public string FileName { get; set; }
}