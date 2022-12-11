using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Services;
using Domain.Dtos;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CountryController{
    public readonly CountryService _countryService;
    public CountryController(CountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet("GetAll")]
    public async Task<Response<List<GetCountryDto>>> GetCountries(){
        return await _countryService.GetCountries();
    }
    [HttpPost("Add")]
    public async Task<Response<AddCountryDto>> InsertCountry(AddCountryDto country){
        return await _countryService.InsertCountry(country);
    }
    [HttpPut("Update")]
    public async Task<Response<AddCountryDto>> UpdateCountry(AddCountryDto country){
        return await _countryService.UpdateCountry(country);
    }
    [HttpDelete("Delete")]
    public async Task<Response<string>> DeleteCountry(string id){
        return await _countryService.DeleteCountry(id);
    }
}