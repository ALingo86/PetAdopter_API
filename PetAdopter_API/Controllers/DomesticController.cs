﻿using Microsoft.AspNet.Identity;
using PetAdopter_API.Data;
using PetAdopter_API.Models;
using PetAdopter_API.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PetAdopter_API.Controllers
{
    [Authorize]
    public class DomesticController : ApiController
    {

        // Create DomesticService
        private DomesticService CreateDomesticService()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var DomesticService = new DomesticService(userId);
            return DomesticService;

        }

        // POST
        public IHttpActionResult Post(DomesticCreate domestic)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDomesticService();

            if (!service.CreateDomestic(domestic))
                return InternalServerError();

            return Ok("New domestic pet has been posted for adoption!");
        }

        // GET ALL
        public IHttpActionResult Get()
        {

            DomesticService domesticService = CreateDomesticService();
            var domestics = domesticService.GetDomestics();
            return Ok(domestics);

        }

        // GET by ID
        public IHttpActionResult Get(int id)
        {

            DomesticService domesticService = CreateDomesticService();
            var domestic = domesticService.GetDomesticById(id);
            return Ok(domestic);

        }

        // PUT (update)
        public IHttpActionResult Put(DomesticEdit domestic)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var service = CreateDomesticService();

            if (!service.UpdateDomestic(domestic))
                return InternalServerError();

            return Ok("Your domestic pet information has been updated.");

        }

        // DELETE
        public IHttpActionResult Delete(int id)
        {
            var service = CreateDomesticService();

            if (!service.DeleteDomestic(id))
                return InternalServerError();

            return Ok("Success. The domestic pet has been deleted from the database.");
        }

        

        //// POST (create)
        //// api/Domestic
        //[HttpPost]
        //public async Task<IHttpActionResult> CreateDomestic([FromBody] DomesticTable model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Your request body cannot be empty.");
        //    }

        //    // If valid
        //    if (ModelState.IsValid)
        //    {
        //        // Store in the database
        //        _domestic.Domestics.Add(model);
        //        int changeCount = await _domestic.SaveChangesAsync();

        //        return Ok("Ready to adopt!");
        //    }

        //    // Reject if not valid
        //    return BadRequest(ModelState);
        //}

        //// GET ALL
        //// api/Domestic
        //[HttpGet]
        //public async Task<IHttpActionResult> GetAll()
        //{
        //    List<DomesticTable> domestics = await _domestic.Domestics.ToListAsync();
        //    return Ok(domestics);
        //}

        //// GET By ID
        //// api/Domestic/{id}
        //[HttpGet]
        //public async Task<IHttpActionResult> GetById([FromUri] int id)
        //{
        //    DomesticTable domestic = await _domestic.Domestics.FindAsync(id);

        //    if (domestic != null)
        //    {
        //        return Ok(domestic);
        //    }

        //    return NotFound();
        //}

        //// Get By Species
        //// api/Domestic/{species}
        //[HttpGet]
        //public async Task<IHttpActionResult> GetBySpecies([FromUri] string species)
        //{
        //    DomesticTable domestic = await _domestic.Domestics.FindAsync(species);

        //    if (domestic != null)
        //    {
        //        return Ok(domestic);
        //    }

        //    return NotFound();
        //}

        //// GET By Breed
        //// api/Domestic/{breed}
        //[HttpGet]
        //public async Task<IHttpActionResult> GetByBreed([FromUri] string breed)
        //{
        //    DomesticTable domestic = await _domestic.Domestics.FindAsync(breed);

        //    if (domestic != null)
        //    {
        //        return Ok(domestic);
        //    }

        //    return NotFound();
        //}

        //// PUT (update)
        //// api/Domestic/{id}
        //[HttpPut]
        //public async Task<IHttpActionResult> UpdateDomestic([FromUri] int id, [FromBody] DomesticTable updatedDomestic)
        //{
        //    // check to see if ids match
        //    if (id != updatedDomestic?.Id)
        //    {
        //        return BadRequest("Id does not match.");
        //    }

        //    // Check
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    // Find the pet in the database
        //    DomesticTable domestic = await _domestic.Domestics.FindAsync(id);

        //    // If the character doesn't exist
        //    if (domestic is null)
        //        return NotFound();

        //    // Update the properties
        //    domestic.Species = updatedDomestic.Species;
        //    domestic.Name = updatedDomestic.Name;
        //    domestic.Breed = updatedDomestic.Breed;
        //    domestic.Sex = updatedDomestic.Sex;
        //    domestic.IsSterile = updatedDomestic.IsSterile;
        //    domestic.BirthDate = updatedDomestic.BirthDate;
        //    domestic.IsAdoptionPending = updatedDomestic.IsAdoptionPending;
        //    domestic.IsKidFriendly = updatedDomestic.IsKidFriendly;
        //    domestic.IsPetFriendly = updatedDomestic.IsPetFriendly;
        //    domestic.IsHypoallergenic = updatedDomestic.IsHypoallergenic;
        //    domestic.IsHouseTrained = updatedDomestic.IsHouseTrained;
        //    domestic.ShelterId = updatedDomestic.ShelterId;

        //    // Save the changes
        //    await _domestic.SaveChangesAsync();

        //    return Ok("The pet's information has been updated.");
        //}

        //// DELETE
        //// api/Dogs/{id}
        //[HttpDelete]
        //public async Task<IHttpActionResult> DeleteDomestic([FromUri] int id)
        //{
        //    DomesticTable domestic = await _domestic.Domestics.FindAsync(id);

        //    if (domestic is null)
        //        return NotFound();

        //    _domestic.Domestics.Remove(domestic);

        //    if (await _domestic.SaveChangesAsync() == 1)
        //    {
        //        return Ok("The pet was deleted from the database.");
        //    }

        //    return InternalServerError();
        //}
    }
}
