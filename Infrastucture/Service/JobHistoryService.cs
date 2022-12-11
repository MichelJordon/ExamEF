using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Services;
public class JobHistoryService
{
    private readonly DataContext _context;
    public JobHistoryService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetJobHistoryDto>>> GetJobHistories()
    {
        var list = await _context.JobHistories.Select(s => new GetJobHistoryDto()
        {
            EmployeeId = s.EmployeeId,
            StartDate = s.StartDate,
            EndDate = s.EndDate,
            JobTitle = s.Job.JobTitle,
            DepartmentName = s.Department.DepartmentName
        }).ToListAsync();
        return new Response<List<GetJobHistoryDto>>(list.ToList());
    }

    public async Task<Response<AddJobHistoryDto>> InsertJobHistory(AddJobHistoryDto jobHistory)
    {
        var NEW = new JobHistory()
        {
            StartDate = jobHistory.StartDate,
            EndDate = jobHistory.EndDate,
            JobId = jobHistory.JobId,
            DepartmentId = jobHistory.DepartmentId
        };
        _context.JobHistories.Add(NEW);
        await _context.SaveChangesAsync();
        jobHistory.EmployeeId = NEW.EmployeeId;
        return new Response<AddJobHistoryDto>(jobHistory);
    }

    public async Task<Response<AddJobHistoryDto>> UpdateJobHistory(AddJobHistoryDto jobHistory)
    {
        var find = await _context.JobHistories.FindAsync(jobHistory.EmployeeId);
        find.StartDate = jobHistory.StartDate;
        find.EndDate = jobHistory.EndDate;
        find.JobId = jobHistory.JobId;
        find.DepartmentId = jobHistory.DepartmentId;
        var updated = await _context.SaveChangesAsync();
        return new Response<AddJobHistoryDto>(jobHistory);
    }
    public async Task<Response<string>> DeleteJobHistory(int id)
    {
        var find = await _context.JobHistories.FindAsync(id);
        _context.Remove(find);
        var response = await _context.SaveChangesAsync();
        if (response > 0)
            return new Response<string>("Object deleted successfully");
        return new Response<string>(HttpStatusCode.BadRequest, "Object not found");
    }

}