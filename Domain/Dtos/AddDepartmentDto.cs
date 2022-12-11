using Domain.Entities;
namespace Domain.Dtos;
public class AddDepartmentDto
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public int ManagerId { get; set; }
    public int LocationId { get; set; }

}