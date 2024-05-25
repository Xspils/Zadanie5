using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie7.Models;

namespace Zadanie7.Data
{
    public class TripRepository : ITripRepository
    {
        private readonly Database _context;  

        public TripRepository(Database context)
        {
            _context = context;
        }

        public async Task<List<Trip>> GetAllTripsAsync()
        {
            return await _context.Trips
                                 .Include(t => t.Countries)  
                                 .OrderByDescending(t => t.StartDate)
                                 .ToListAsync();
        }

        public async Task<Trip> GetTripByIdAsync(int tripId)
        {
            return await _context.Trips
                                 .Include(t => t.Clients)  
                                 .FirstOrDefaultAsync(t => t.Id == tripId);
        }

        public async Task AddTripAsync(Trip trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTripAsync(Trip trip)
        {
            _context.Trips.Update(trip);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTripAsync(int tripId)
        {
            var trip = await GetTripByIdAsync(tripId);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface ITripRepository
    {
        Task<List<Trip>> GetAllTripsAsync();
        Task<Trip> GetTripByIdAsync(int tripId);
        Task AddTripAsync(Trip trip);
        Task UpdateTripAsync(Trip trip);
        Task DeleteTripAsync(int tripId);
    }
}
