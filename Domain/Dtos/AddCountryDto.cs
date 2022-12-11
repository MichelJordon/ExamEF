using Domain.Entities;
namespace Domain.Dtos;
public class AddCountryDto{
    public string CountryId {get; set;}
    public string CountryName {get; set;}
    public int RegionId { get; set; }
}