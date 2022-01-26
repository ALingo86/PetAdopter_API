﻿using PetAdopter_API.Data;
using PetAdopter_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PetAdopter_API.Controllers
{

    public class AdopterController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        //Post(Create)
        [HttpPost]
        public async Task<IHttpActionResult> CreateAdopter([FromBody] AdopterTable model)
        {
            if (model is null)
            {
                return BadRequest("You need a request body");
            }
            if (ModelState.IsValid)
            {
                _context.Adopter.Add(model);
                int changeCount = await _context.SaveChangesAsync();
            }
            return BadRequest(ModelState);
        }

        //Get All
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Shelter> shelters = await _context.Shelters.ToListAsync();
            return Ok(shelters);
        }

        //Get By ID
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            AdopterTable adopter = await _context.Adopter.FindAsync(id);

            if (adopter != null)
            {
                return Ok(adopter);
            }
            return NotFound();
        }

        //Put (update)
        [HttpPut]
        public async Task<IHttpActionResult> UpdateAdopter([FromBody] int id, [FromBody] AdopterTable updatedAdopter)
        {
            if (id != updatedAdopter?.Id)
            {
                return BadRequest("Ids do not match.");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AdopterTable adopter = await _context.Adopter.FindAsync(id);

            if (adopter is null)
                return NotFound();

            adopter.FirstName = updatedAdopter.FirstName;
            adopter.LastName = updatedAdopter.LastName;
            adopter.State = updatedAdopter.State;
            adopter.City = updatedAdopter.City;
            adopter.PhoneNumber = updatedAdopter.PhoneNumber;


            await _context.SaveChangesAsync();

            return Ok("The shelter was updated");
        }

        //Delete (delete)
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAdopter([FromUri] int id)
        {
            AdopterTable adopter = await _context.Adopter.FindAsync(id);
            if (adopter is null)
                return NotFound();

            _context.Adopter.Remove(adopter);

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("The shelter was deleted");
            }

            return InternalServerError();
        }
    }
}

