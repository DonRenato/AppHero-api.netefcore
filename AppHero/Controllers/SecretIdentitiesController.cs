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
    public class SecretIdentitiesController : ControllerBase
    {
        private readonly HeroContext _context;

        public SecretIdentitiesController(HeroContext context)
        {
            _context = context;
        }

        // GET: api/SecretIdentities
        [HttpGet]
        public IEnumerable<SecretIdentity> GetsecretIdentities()
        {
            return _context.secretIdentities;
        }

        // GET: api/SecretIdentities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSecretIdentity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var secretIdentity = await _context.secretIdentities.FindAsync(id);

            if (secretIdentity == null)
            {
                return NotFound();
            }

            return Ok(secretIdentity);
        }

        // PUT: api/SecretIdentities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSecretIdentity([FromRoute] int id, [FromBody] SecretIdentity secretIdentity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != secretIdentity.id)
            {
                return BadRequest();
            }

            _context.Entry(secretIdentity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecretIdentityExists(id))
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

        // POST: api/SecretIdentities
        [HttpPost]
        public async Task<IActionResult> PostSecretIdentity([FromBody] SecretIdentity secretIdentity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.secretIdentities.Add(secretIdentity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSecretIdentity", new { id = secretIdentity.id }, secretIdentity);
        }

        // DELETE: api/SecretIdentities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSecretIdentity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var secretIdentity = await _context.secretIdentities.FindAsync(id);
            if (secretIdentity == null)
            {
                return NotFound();
            }

            _context.secretIdentities.Remove(secretIdentity);
            await _context.SaveChangesAsync();

            return Ok(secretIdentity);
        }

        private bool SecretIdentityExists(int id)
        {
            return _context.secretIdentities.Any(e => e.id == id);
        }
    }
}