using Domain.Entities;
namespace Domain.Dtos;
using Microsoft.AspNetCore.Http;
public class AddEmployeeDto
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public int JobId { get; set; }
    public int CommissionPct { get; set; }
    public int ManagerId { get; set; }
    public int DepartmentId { get; set; }
    public IFormFile File { get; set; }

    public string FileName { get; set; }

}