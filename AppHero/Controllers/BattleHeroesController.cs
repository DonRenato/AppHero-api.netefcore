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
    public class BattleHeroesController : ControllerBase
    {
        private readonly HeroContext _context;

        public BattleHeroesController(HeroContext context)
        {
            _context = context;
        }

        // GET: api/BattleHeroes
        [HttpGet]
        public IEnumerable<BattleHero> GetbattleHeroes()
        {
            return _context.battleHeroes;
        }

        // GET: api/BattleHeroes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBattleHero([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var battleHero = await _context.battleHeroes.FindAsync(id);

            if (battleHero == null)
            {
                return NotFound();
            }

            return Ok(battleHero);
        }

        // PUT: api/BattleHeroes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBattleHero([FromRoute] int id, [FromBody] BattleHero battleHero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != battleHero.battleId)
            {
                return BadRequest();
            }

            _context.Entry(battleHero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BattleHeroExists(id))
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

        // POST: api/BattleHeroes
        [HttpPost]
        public async Task<IActionResult> PostBattleHero([FromBody] BattleHero battleHero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.battleHeroes.Add(battleHero);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BattleHeroExists(battleHero.battleId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBattleHero", new { id = battleHero.battleId }, battleHero);
        }

        // DELETE: api/BattleHeroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBattleHero([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var battleHero = await _context.battleHeroes.FindAsync(id);
            if (battleHero == null)
            {
                return NotFound();
            }

            _context.battleHeroes.Remove(battleHero);
            await _context.SaveChangesAsync();

            return Ok(battleHero);
        }

        private bool BattleHeroExists(int id)
        {
            return _context.battleHeroes.Any(e => e.battleId == id);
        }
    }
}