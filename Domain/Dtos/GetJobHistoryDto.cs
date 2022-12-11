using Domain.Entities;
namespace Domain.Dtos;
public class GetJobHistoryDto{
    public int EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string JobTitle{get; set;}
    public string DepartmentName{get;set;}
}