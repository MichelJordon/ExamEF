using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Services;
public class RegionService
{
    private readonly DataContext _context;
    public RegionService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetRegionDto>>> GetRegions()
    {
        var list = await _context.Regions.Select(s => new GetRegionDto()
        {
            RegionId = s.RegionId,
            RegionName = s.RegionName
        }).ToListAsync();
        return new Response<List<GetRegionDto>>(list.ToList());
    }

    public async Task<Response<AddRegionDto>> InsertRegion(AddRegionDto region)
    {
        var NEW = new Region()
        {
            RegionName = region.RegionName
        };
        _context.Regions.Add(NEW);
        await _context.SaveChangesAsync();
        region.RegionId = NEW.RegionId;
        return new Response<AddRegionDto>(region);
    }

    public async Task<Response<AddRegionDto>> UpdateRegion(AddRegionDto region)
    {
        var find = await _context.Regions.FindAsync(region.RegionId);
        find.RegionName = region.RegionName;
        var updated = await _context.SaveChangesAsync();
        return new Response<AddRegionDto>(region);
    }
    public async Task<Response<string>> DeleteRegion(int id)
    {
        var find = await _context.Regions.FindAsync(id);
        _context.Remove(find);
        var response = await _context.SaveChangesAsync();
        if (response > 0)
            return new Response<string>("Object deleted successfully");
        return new Response<string>(HttpStatusCode.BadRequest, "Object not found");
    }

}