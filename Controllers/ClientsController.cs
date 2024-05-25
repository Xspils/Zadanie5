using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadanie7.Controllers; 

namespace Zadanie7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly "dalej nie mam bazy";

        public ClientsController(YourDbContext context)
        {
            _context = context;
        }

        [HttpDelete("{idClient}")]
        public async Task<IActionResult> DeleteClient(int idClient)
        {
            var client = await _context.Clients.Include(c => c.Trips).FirstOrDefaultAsync(c => c.Id == idClient);
            if (client == null) return NotFound();
            if (client.Trips.Any()) return BadRequest("Cannot be deleted.");

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
