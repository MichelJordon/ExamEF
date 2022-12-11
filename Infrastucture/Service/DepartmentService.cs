using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Services;
public class DepartmentService
{
    private readonly DataContext _context;
    public DepartmentService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetDepartmentDto>>> GetDepartments()
    {
        var list = await _context.Departments.Select(s => new GetDepartmentDto()
        {
            DepartmentId = s.DepartmentId,
            DepartmentName = s.DepartmentName,
            StreetAddress = s.Location.StreetAddress,
            PostalCode = s.Location.PostalCode,
            City = s.Location.City,
            StateProvince = s.Location.StateProvince
        }).ToListAsync();
        return new Response<List<GetDepartmentDto>>(list.ToList());
    }
   
    public async Task<Response<AddDepartmentDto>> InsertDepartment(AddDepartmentDto department)
    {
        var NEW = new Department()
        {
            DepartmentName = department.DepartmentName,
            ManagerId = department.ManagerId,
            LocationId = department.LocationId
        };
        _context.Departments.Add(NEW);
        await _context.SaveChangesAsync();
        department.DepartmentId = NEW.DepartmentId;
        return new Response<AddDepartmentDto>(department);
    }

    public async Task<Response<AddDepartmentDto>> UpdateDepartment(AddDepartmentDto department)
    {
        var find = await _context.Departments.FindAsync(department.DepartmentId);
        find.DepartmentName = department.DepartmentName;
        find.ManagerId = department.ManagerId;
        find.LocationId = department.LocationId;
        var updated = await _context.SaveChangesAsync();
        return new Response<AddDepartmentDto>(department);
    }
    public async Task<Response<string>> DeleteDepartment(int id)
    {
        var find = await _context.Departments.FindAsync(id);
        _context.Remove(find);
        var response = await _context.SaveChangesAsync();
        if(response>0)
                return new Response<string>("Object deleted successfully");
        return new Response<string>(HttpStatusCode.BadRequest,"Object not found");
    }
    
}   