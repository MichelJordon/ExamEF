using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Services;
using Domain.Dtos;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class DepartmentController{
    public readonly DepartmentService _departmentService;
    public DepartmentController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet("GetAll")]
    public async Task<Response<List<GetDepartmentDto>>> GetDepartments(){
        return await _departmentService.GetDepartments();
    }
    [HttpPost("Add")]
    public async Task<Response<AddDepartmentDto>> InsertDepartment(AddDepartmentDto department){
        return await _departmentService.InsertDepartment(department);
    }
    [HttpPut("Update")]
    public async Task<Response<AddDepartmentDto>> UpdateDepartment(AddDepartmentDto department){
        return await _departmentService.UpdateDepartment(department);
    }
    [HttpDelete("Delete")]
    public async Task<Response<string>> DeleteDepartment(int id){
        return await _departmentService.DeleteDepartment(id);
    }
}