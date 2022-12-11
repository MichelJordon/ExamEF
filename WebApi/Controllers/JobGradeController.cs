using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Services;
using Domain.Dtos;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class JobGradeController{
    public readonly JobGradeService _jobGradeService;
    public JobGradeController(JobGradeService jobGradeService)
    {
        _jobGradeService = jobGradeService;
    }

    [HttpGet("GetAll")]
    public async Task<Response<List<GetJobGradeDto>>> GetJobGrades(){
        return await _jobGradeService.GetJobGrades();
    }
    [HttpPost("Add")]
    public async Task<Response<AddJobGradeDto>> InsertJobGrade(AddJobGradeDto jobGrade){
        return await _jobGradeService.InsertJobGrade(jobGrade);
    }
    [HttpPut("Update")]
    public async Task<Response<AddJobGradeDto>> UpdateJobGrade(AddJobGradeDto jobGrade){
        return await _jobGradeService.UpdateJobGrade(jobGrade);
    }
    [HttpDelete("Delete")]
    public async Task<Response<string>> DeleteJobGrade(string id){
        return await _jobGradeService.DeleteJobGrade(id);
    }
}