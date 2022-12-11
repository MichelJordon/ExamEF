namespace Domain.Entities;
public class Location{
    public int LocationId { get; set; }
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string CountryId { get; set; }
    public virtual Country Country { get; set; }
    public virtual List<Department> Departments { get; set; }

}