using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppHero.Model;
using EFCore.WebAPI.Data;

namespace AppHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattlesController : ControllerBase
    {
        private readonly HeroContext _context;

        public BattlesController(HeroContext context)
        {
            _context = context;
        }

        // GET: api/Battles
        [HttpGet]
        public IEnumerable<Battle> Getbattles()
        {
            return _context.battles;
        }

        // GET: api/Battles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBattle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var battle = await _context.battles.FindAsync(id);

            if (battle == null)
            {
                return NotFound();
            }

            return Ok(battle);
        }

        // PUT: api/Battles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBattle([FromRoute] int id, [FromBody] Battle battle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != battle.id)
            {
                return BadRequest();
            }

            _context.Entry(battle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BattleExists(id))
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

        // POST: api/Battles
        [HttpPost]
        public async Task<IActionResult> PostBattle([FromBody] Battle battle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.battles.Add(battle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBattle", new { id = battle.id }, battle);
        }

        // DELETE: api/Battles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBattle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var battle = await _context.battles.FindAsync(id);
            if (battle == null)
            {
                return NotFound();
            }

            _context.battles.Remove(battle);
            await _context.SaveChangesAsync();

            return Ok(battle);
        }

        private bool BattleExists(int id)
        {
            return _context.battles.Any(e => e.id == id);
        }
    }
}