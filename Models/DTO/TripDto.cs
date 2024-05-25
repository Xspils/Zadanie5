using System;

public class TripDto
{
    public int Id { get; set; }  
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; }  
    public string Description { get; set; }  
    public List<CountryDto> Countries { get; set; }  
}
