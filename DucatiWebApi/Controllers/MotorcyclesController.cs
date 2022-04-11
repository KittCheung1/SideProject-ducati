#nullable disable
using DucatiWebApi.Data;
using DucatiWebApi.DTO;
using DucatiWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DucatiWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcyclesController : ControllerBase
    {
        private readonly DucatiWebApiContext _context;

        public MotorcyclesController(DucatiWebApiContext context)
        {
            _context = context;
        }

        // GET: api/motorcycles
        [HttpGet("/api/motorcycles/")]
        public async Task<IEnumerable<ReadMotorcycleDTO>> GetMotorcycle()
        {
            var motorcycleList = await _context.Motorcycle.ToListAsync();
            return motorcycleList.Select(x => new ReadMotorcycleDTO() { Id = x.Id, Name = x.Name, Price = x.Price, Year = x.Year, ImagePath = x.ImagePath });
        }

        // GET: api/motorcycles/5
        [HttpGet("/api/motorcycles/{id}")]
        public async Task<ActionResult<Motorcycle>> GetMotorcycle(int id)
        {
            var motorcycle = await _context.Motorcycle.FindAsync(id);

            if (motorcycle == null)
            {
                return NotFound();
            }

            return motorcycle;
        }

        // PUT: api/motorcycles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/api/motorcycles/{id}")]
        public async Task<IActionResult> PutMotorcycle(int id, UpdateMotorcycleDTO motorcycle)
        {
            var dbMotorcycle = new Motorcycle() { Id = id, Name = motorcycle.Name, Price = motorcycle.Price, Year = motorcycle.Year, ImagePath = motorcycle.ImagePath };
            _context.Entry(dbMotorcycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotorcycleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Motorcycles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/api/motorcycles/")]
        public async Task<ActionResult<Motorcycle>> PostMotorcycle(Motorcycle motorcycle)
        {
            _context.Motorcycle.Add(motorcycle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotorcycle", new { id = motorcycle.Id }, motorcycle);
        }

        // DELETE: api/motorcycles/5
        [HttpDelete("/api/motorcycles/{id}")]
        public async Task<IActionResult> DeleteMotorcycle(int id)
        {
            var motorcycle = await _context.Motorcycle.FindAsync(id);
            if (motorcycle == null)
            {
                return NotFound();
            }

            _context.Motorcycle.Remove(motorcycle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotorcycleExists(int id)
        {
            return _context.Motorcycle.Any(e => e.Id == id);
        }
    }
}
