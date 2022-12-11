using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Services;
using Domain.Dtos;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class RegionController{
    public readonly RegionService _regionService;
    public RegionController(RegionService regionService)
    {
        _regionService = regionService;
    }

    [HttpGet("GetAll")]
    public async Task<Response<List<GetRegionDto>>> GetRegions(){
        return await _regionService.GetRegions();
    }
    [HttpPost("Add")]
    public async Task<Response<AddRegionDto>> InsertRegion(AddRegionDto region){
        return await _regionService.InsertRegion(region);
    }
    [HttpPut("Update")]
    public async Task<Response<AddRegionDto>> UpdateRegion(AddRegionDto region){
        return await _regionService.UpdateRegion(region);
    }
    [HttpDelete("Delete")]
    public async Task<Response<string>> DeleteRegion(int id){
        return await _regionService.DeleteRegion(id);
    }
}