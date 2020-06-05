using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalogusAPI.Data;
using ProductCatalogusAPI.Models;

namespace ProductCatalogusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PotplantsController : ControllerBase
    {
        private readonly ProductCatalogusAPIContext _context;

        public PotplantsController(ProductCatalogusAPIContext context)
        {
            _context = context;
        }

        // GET: api/Potplants
        //Opvragen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Potplant>>> GetPotplant([FromQuery]FilterParam filter, [FromQuery]SortParam sort)
        {
            var planten = from p in _context.Potplant
                          select p;


            //filteren op invoer (naam, kleur, minimale en maximale potmaat en productgroep)
            planten = FilterResultaten(filter, planten);

            //sorteren op volgorde van de gekozen parameter (bijvoorbeeld naam of productgroep)
            planten = SorteerResultaten(sort, planten);

            return await planten.ToListAsync();
        }

        // GET: api/Potplants/5
        //opvragen op ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Potplant>> GetPotplant(string id)
        {
            var potplant = await _context.Potplant.FindAsync(id);

            if (potplant == null)
            {
                return NotFound();
            }

            return potplant;
        }

        // PUT: api/Potplants/5
        //Bewerken
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPotplant(string id, Potplant potplant)
        {
            if (id != potplant.Code)
            {
                return BadRequest();
            }

            _context.Entry(potplant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PotplantExists(id))
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

        // POST: api/Potplants
        // Toevoegen
        [HttpPost]
        public async Task<ActionResult<Potplant>> PostPotplant(Potplant potplant)
        {
            _context.Potplant.Add(potplant);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PotplantExists(potplant.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPotplant", new { id = potplant.Code }, potplant);
        }

        // DELETE: api/Potplants/5
        //Verwijderen
        [HttpDelete("{id}")]
        public async Task<ActionResult<Potplant>> DeletePotplant(string id)
        {
            var potplant = await _context.Potplant.FindAsync(id);
            if (potplant == null)
            {
                return NotFound();
            }

            _context.Potplant.Remove(potplant);
            await _context.SaveChangesAsync();

            return potplant;
        }

        //Filteren
        private static IQueryable<Potplant> FilterResultaten(FilterParam filter, IQueryable<Potplant> planten)
        {
            //alleen potten van de ingevulde kleur
            if (!String.IsNullOrEmpty(filter.Kleur))
            {
                planten = planten.Where(p => p.Kleur.Contains(filter.Kleur));
            }
            //alleen planten waar de ingevoerde naam in de naam zit
            if (!String.IsNullOrEmpty(filter.Naam))
            {
                planten = planten.Where(p => p.Naam.Contains(filter.Naam));
            }
            //alleen planten uit de ingevoerde product groep
            if (!String.IsNullOrEmpty(filter.Productgroep))
            {
                planten = planten.Where(p => p.Productgroep.Contains(filter.Productgroep));
            }
            //alleen potten groter dan ingevoerde MinMaat
            if (filter.MinMaat != null)
            {
                planten = planten.Where(p => p.Potmaat >= filter.MinMaat);
            }
            if (filter.MaxMaat != null)
            {
                planten = planten.Where(p => p.Potmaat <= filter.MaxMaat);
            }

            return planten;
        }

        //Sorteren
        private IQueryable<Potplant> SorteerResultaten(SortParam sort, IQueryable<Potplant> planten)
        {
            switch (sort.OrderBy)
            {
                case Order.Naam_Aflopend:
                    return planten = planten.OrderByDescending(p => p.Naam);
                case Order.Planthoogte:
                    return planten = planten.OrderBy(p => p.Planthoogte);
                case Order.Planthoogte_Aflopend:
                    return planten = planten.OrderByDescending(p => p.Planthoogte);
                case Order.Groep:
                    return planten = planten.OrderBy(p => p.Productgroep);
                case Order.Groep_Aflopend:
                    return planten = planten.OrderByDescending(p => p.Productgroep);
                case Order.Potmaat:
                    return planten = planten.OrderBy(p => p.Productgroep);
                case Order.Potmaat_Aflopend:
                    return planten = planten.OrderByDescending(p => p.Productgroep);
                default:
                    return planten = planten.OrderBy(p => p.Naam);
            }
        }

        private bool PotplantExists(string id)
        {
            return _context.Potplant.Any(e => e.Code == id);
        }
    }
}
