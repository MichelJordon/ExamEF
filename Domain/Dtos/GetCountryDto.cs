using Domain.Entities;
namespace Domain.Dtos;
public class GetCountryDto{
    public string CountryId {get; set;}
    public string CountryName {get; set;}
    public string RegionName {get; set;}
}