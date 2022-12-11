using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Services;
public class JobService
{
    private readonly DataContext _context;
    public JobService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetJobDto>>> GetJobs()
    {
        var list = await _context.Jobs.Select(s => new GetJobDto()
        {
            JobId = s.JobId,
            JobTitle = s.JobTitle,
            MinSalary = s.MinSalary,
            MaxSalary = s.MaxSalary
        }).ToListAsync();
        return new Response<List<GetJobDto>>(list.ToList());
    }

    public async Task<Response<AddJobDto>> InsertJob(AddJobDto job)
    {
        var NEW = new Job()
        {
            JobTitle = job.JobTitle,
            MinSalary = job.MinSalary,
            MaxSalary = job.MaxSalary
        };
        _context.Jobs.Add(NEW);
        await _context.SaveChangesAsync();
        job.JobId = NEW.JobId;
        return new Response<AddJobDto>(job);
    }

    public async Task<Response<AddJobDto>> UpdateJob(AddJobDto job)
    {
        var find = await _context.Jobs.FindAsync(job.JobId);
        find.JobTitle = job.JobTitle;
        find.MinSalary = job.MinSalary;
        find.MaxSalary = job.MaxSalary;
        var updated = await _context.SaveChangesAsync();
        return new Response<AddJobDto>(job);
    }
    public async Task<Response<string>> DeleteJob(string id)
    {
        var find = await _context.Jobs.FindAsync(id);
        _context.Remove(find);
        var response = await _context.SaveChangesAsync();
        if (response > 0)
            return new Response<string>("Object deleted successfully");
        return new Response<string>(HttpStatusCode.BadRequest, "Object not found");
    }

}