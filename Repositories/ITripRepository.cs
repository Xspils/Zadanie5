using System.Collections.Generic;
using System.Threading.Tasks;
using Zadanie7.Models;

public interface ITripRepository
{
    Task<Trip> GetTripByIdAsync(int tripId);  
    Task<IEnumerable<Trip>> GetAllTripsAsync();  
    Task<IEnumerable<Trip>> GetTripsByCountryIdAsync(int countryId);  
    Task AddTripAsync(Trip trip); 
    Task UpdateTripAsync(Trip trip);  
    Task DeleteTripAsync(int tripId); 
    Task<IEnumerable<Trip>> GetTripsWithClientsAsync();  
}
