using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Services;
using Domain.Dtos;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class JobController{
    public readonly JobService _jobService;
    public JobController(JobService jobService)
    {
        _jobService = jobService;
    }

    [HttpGet("GetAll")]
    public async Task<Response<List<GetJobDto>>> GetJobs(){
        return await _jobService.GetJobs();
    }
    [HttpPost("Add")]
    public async Task<Response<AddJobDto>> InsertJob(AddJobDto job){
        return await _jobService.InsertJob(job);
    }
    [HttpPut("Update")]
    public async Task<Response<AddJobDto>> UpdateJob(AddJobDto job){
        return await _jobService.UpdateJob(job);
    }
    [HttpDelete("Delete")]
    public async Task<Response<string>> DeleteJob(string id){
        return await _jobService.DeleteJob(id);
    }
}