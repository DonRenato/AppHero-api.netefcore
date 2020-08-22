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
    public class WeaponsController : ControllerBase
    {
        private readonly HeroContext _context;

        public WeaponsController(HeroContext context)
        {
            _context = context;
        }

        // GET: api/Weapons
        [HttpGet]
        public IEnumerable<Weapon> Getweapons()
        {
            return _context.weapons;
        }

        // GET: api/Weapons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWeapon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var weapon = await _context.weapons.FindAsync(id);

            if (weapon == null)
            {
                return NotFound();
            }

            return Ok(weapon);
        }

        // PUT: api/Weapons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeapon([FromRoute] int id, [FromBody] Weapon weapon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != weapon.id)
            {
                return BadRequest();
            }

            _context.Entry(weapon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeaponExists(id))
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

        // POST: api/Weapons
        [HttpPost]
        public async Task<IActionResult> PostWeapon([FromBody] Weapon weapon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.weapons.Add(weapon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeapon", new { id = weapon.id }, weapon);
        }

        // DELETE: api/Weapons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeapon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var weapon = await _context.weapons.FindAsync(id);
            if (weapon == null)
            {
                return NotFound();
            }

            _context.weapons.Remove(weapon);
            await _context.SaveChangesAsync();

            return Ok(weapon);
        }

        private bool WeaponExists(int id)
        {
            return _context.weapons.Any(e => e.id == id);
        }
    }
}