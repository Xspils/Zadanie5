using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadanie7.Controllers; 

namespace Zadanie7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly "Dalej nie mam bazy";

        public TripsController(YourDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            var trips = await _context.Trips.OrderByDescending(t => t.StartDate).ToListAsync();
            return Ok(trips);
        }

        [HttpPost("{idTrip}/clients")]
        public async Task<IActionResult> AssignClientToTrip(int idTrip, [FromBody] ClientDto clientDto)
        {
            var trip = await _context.Trips.FindAsync(idTrip);
            if (trip == null) return NotFound("Trip not found.");

            var client = await _context.Clients.FirstOrDefaultAsync(c => c.PESEL == clientDto.PESEL);
            if (client == null)
            {
                client = new Client { PESEL = clientDto.PESEL, Name = clientDto.Name };
                _context.Clients.Add(client);
            }

            if (await _context.ClientTrips.AnyAsync(ct => ct.ClientId == client.Id && ct.TripId == idTrip))
                return BadRequest("Client is already in to this trip.");

            _context.ClientTrips.Add(new ClientTrip { ClientId = client.Id, TripId = idTrip, RegisteredAt = DateTime.Now });
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
