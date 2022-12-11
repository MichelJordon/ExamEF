using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Services;
public class JobGradeService
{
    private readonly DataContext _context;
    public JobGradeService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetJobGradeDto>>> GetJobGrades()
    {
        var list = await _context.JobGrades.Select(s => new GetJobGradeDto()
        {
            GradeLevel = s.GradeLevel,
            LowestSalary = s.LowestSalary,
            HighestSalary = s.HighestSalary
        }).ToListAsync();
        return new Response<List<GetJobGradeDto>>(list.ToList());
    }
   
    public async Task<Response<AddJobGradeDto>> InsertJobGrade(AddJobGradeDto jobGrade)
    {
        var NEW = new JobGrade()
        {
            GradeLevel = jobGrade.GradeLevel,
            LowestSalary = jobGrade.LowestSalary,
            HighestSalary = jobGrade.HighestSalary
        };
        _context.JobGrades.Add(NEW);
        await _context.SaveChangesAsync();
        jobGrade.GradeLevel = NEW.GradeLevel;
        return new Response<AddJobGradeDto>(jobGrade);
    }

    public async Task<Response<AddJobGradeDto>> UpdateJobGrade(AddJobGradeDto jobGrade)
    {
        var find = await _context.JobGrades.FindAsync(jobGrade.GradeLevel);
        find.GradeLevel = jobGrade.GradeLevel;
        find.LowestSalary = jobGrade.LowestSalary;
        find.HighestSalary = jobGrade.HighestSalary;
        var updated = await _context.SaveChangesAsync();
        return new Response<AddJobGradeDto>(jobGrade);
    }
    public async Task<Response<string>> DeleteJobGrade(string GradeLevel)
    {
        var find = await _context.JobGrades.FindAsync(GradeLevel);
        _context.Remove(find);
        var response = await _context.SaveChangesAsync();
        if(response > 0)
                return new Response<string>("Object deleted successfully");
        return new Response<string>(HttpStatusCode.BadRequest,"Object not found");
    }
    
}