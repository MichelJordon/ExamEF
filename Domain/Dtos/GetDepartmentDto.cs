using Domain.Entities;
namespace Domain.Dtos;
public class GetDepartmentDto
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
}