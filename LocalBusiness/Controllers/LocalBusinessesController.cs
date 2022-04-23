using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocalBusiness.Models;

namespace LocalBusiness.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BusinessesController : ControllerBase
  {
    private readonly LocalBusinessContext _db;

    public BusinessesController(LocalBusinessContext db)
    {
      _db = db;
    }

    // GET api/businesses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Business>>> Get(string category, string state, string city, string zip)
    {
      var query = _db.Businesses.AsQueryable();

      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }

      if (category != null)
      {
        query = query.Where(entry => entry.Category == category);
      }    

      if (state != null)
      {
        query = query.Where(entry => entry.State == state);
      }

      if (zip != null)
      {
        query = query.Where(entry => entry.Zip == zip);
      }
      
      return await query.ToListAsync();
    }

    // GET: api/Businesses/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Business>> GetBusiness(int id)
    {
      var business = await _db.Businesses.FindAsync(id);

      if (business == null)
      {
          return NotFound();
      }

      return business;
    }

    // PUT: api/Businesses/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Business business)
    {
      if (id != business.BusinessId)
      {
        return BadRequest();
      }

      _db.Entry(business).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BusinessExists(id))
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

    // POST api/businesses
    [HttpPost]
    public async Task<ActionResult<Business>> Post(Business business)
    {
      _db.Businesses.Add(business);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetBusiness), new { id = business.BusinessId }, business);
    }

    // DELETE: api/Businesses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBusiness(int id)
    {
      var business = await _db.Businesses.FindAsync(id);
      if (business == null)
      {
        return NotFound();
      }

      _db.Businesses.Remove(business);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool BusinessExists(int id)
    {
      return _db.Businesses.Any(e => e.BusinessId == id);
    }
  }
}