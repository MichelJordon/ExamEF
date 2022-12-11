using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Services;
using Domain.Dtos;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class LocationController{
    public readonly LocationService _locationService;
    public LocationController(LocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("GetAll")]
    public async Task<Response<List<GetLocationDto>>> GetLocations(){
        return await _locationService.GetLocations();
    }
    [HttpPost("Add")]
    public async Task<Response<AddLocationDto>> InsertLocation(AddLocationDto location){
        return await _locationService.InsertLocation(location);
    }
    [HttpPut("Update")]
    public async Task<Response<AddLocationDto>> UpdateLocation(AddLocationDto location){
        return await _locationService.UpdateLocation(location);
    }
    [HttpDelete("Delete")]
    public async Task<Response<string>> DeleteLocation(int id){
        return await _locationService.DeleteLocation(id);
    }
}