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
    public class SellsController : ControllerBase
    {
        private readonly Lab2AgencyContext _context;

        public SellsController(Lab2AgencyContext context)
        {
            _context = context;
        }

        // GET: api/Sells
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sell>>> GetSells()
        {
            return await _context.Sells.ToListAsync();
        }

        // GET: api/Sells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sell>> GetSell(int id)
        {
            var sell = await _context.Sells.FindAsync(id);

            if (sell == null)
            {
                return NotFound();
            }

            return sell;
        }

        // PUT: api/Sells/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSell(int id, Sell sell)
        {
            if (id != sell.SellID)
            {
                return BadRequest();
            }

            _context.Entry(sell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellExists(id))
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

        // POST: api/Sells
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sell>> PostSell(Sell sell)
        {
            if (_context.Sells.Where(pr => pr.SellInfo == sell.SellInfo && pr.ClientID == sell.ClientID && pr.EmployeeID == sell.EmployeeID).Count() == 0)
                 
            {
                _context.Sells.Add(sell);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetSell", new { id = sell.SellID }, sell);
            }
            else
            {
                return BadRequest("Doublicate error");
            }
        }

        // DELETE: api/Sells/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sell>> DeleteSell(int id)
        {
            var sell = await _context.Sells.FindAsync(id);
            if (sell == null)
            {
                return NotFound();
            }

            _context.Sells.Remove(sell);
            await _context.SaveChangesAsync();

            return sell;
        }

        private bool SellExists(int id)
        {
            return _context.Sells.Any(e => e.SellID == id);
        }
    }
}
