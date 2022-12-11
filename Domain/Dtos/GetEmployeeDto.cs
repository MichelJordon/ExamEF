using Domain.Entities;
namespace Domain.Dtos;
using Microsoft.AspNetCore.Http;
public class GetEmployeeDto
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public string JobTitle { get; set; }
    public int CommissionPct { get; set; }
    public int ManagerId { get; set; }
    public string DepartmentName { get; set; }
    public IFormFile File { get; set; }

    public string FileName { get; set; }
}