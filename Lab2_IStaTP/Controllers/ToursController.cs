using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab2_IStaTP.Models;

namespace Lab2_IStaTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly Lab2AgencyContext _context;

        public ToursController(Lab2AgencyContext context)
        {
            _context = context;
        }

        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetTours()
        {
            return await _context.Tours.ToListAsync();
        }

        // GET: api/Tours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetTour(int id)
        {
            var tour = await _context.Tours.FindAsync(id);

            if (tour == null)
            {
                return NotFound();
            }

            return tour;
        }

        // PUT: api/Tours/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(int id, Tour tour)
        {
            if (_context.Tours.Where(cl => cl.TourNaming == tour.TourNaming).Count() == 0)
            {
                if (id != tour.TourID)
                {
                    return BadRequest();
                }

                _context.Entry(tour).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourExists(id))
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
            else
            {
                return BadRequest("Doublicate error");
            }
        }
        
        

        // POST: api/Tours
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tour>> PostTour(Tour tour)
        {
            if (_context.Tours.Where(cl => cl.TourNaming == tour.TourNaming).Count() == 0)
            {
                _context.Tours.Add(tour);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTour", new { id = tour.TourID }, tour);
            }
            else
            {
                return BadRequest("Doublicate error");
            }
        }

        // DELETE: api/Tours/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tour>> DeleteTour(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }

            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();

            return tour;
        }

        private bool TourExists(int id)
        {
            return _context.Tours.Any(e => e.TourID == id);
        }
    }
}
