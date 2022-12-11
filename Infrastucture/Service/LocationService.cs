using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Services;
public class LocationService
{
    private readonly DataContext _context;
    public LocationService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetLocationDto>>> GetLocations()
    {
        var list = await _context.Locations.Select(s => new GetLocationDto()
        {
            LocationId = s.LocationId,
            StreetAddress = s.StreetAddress,
            PostalCode = s.PostalCode,
            City = s.City,
            StateProvince = s.StateProvince,
            CountryName = s.Country.CountryName
        }).ToListAsync();
        return new Response<List<GetLocationDto>>(list.ToList());
    }

    public async Task<Response<AddLocationDto>> InsertLocation(AddLocationDto location)
    {
        var NEW = new Location()
        {
            StreetAddress = location.StreetAddress,
            PostalCode = location.PostalCode,
            City = location.City,
            StateProvince = location.StateProvince,
            CountryId = location.CountryId
        };
        _context.Locations.Add(NEW);
        await _context.SaveChangesAsync();
        location.LocationId = NEW.LocationId;
        return new Response<AddLocationDto>(location);
    }

    public async Task<Response<AddLocationDto>> UpdateLocation(AddLocationDto location)
    {
        var find = await _context.Locations.FindAsync(location.LocationId);
        find.StreetAddress = location.StreetAddress;
        find.PostalCode = location.PostalCode;
        find.City = location.City;
        find.StateProvince = location.StateProvince;
        find.CountryId = location.CountryId;
        var updated = await _context.SaveChangesAsync();
        return new Response<AddLocationDto>(location);
    }
    public async Task<Response<string>> DeleteLocation(int id)
    {
        var find = await _context.Locations.FindAsync(id);
        _context.Remove(find);
        var response = await _context.SaveChangesAsync();
        if (response > 0)
            return new Response<string>("Object deleted successfully");
        return new Response<string>(HttpStatusCode.BadRequest, "Object not found");
    }

}