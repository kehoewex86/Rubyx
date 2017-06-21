using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using Rubyx.Models;
using Rubyx.Dtos;
using AutoMapper;

namespace Rubyx.Controllers.Api
{
    public class BidstonHwrcController : ApiController
    {
        private ApplicationDbContext _context;

        public BidstonHwrcController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/BidstonHwrc
        public IHttpActionResult GetBidstonHwrcs()
        {
            var bidstonhwrcDtos = _context.BidstonHwrc
                    .Include(b => b.WasteType)
                    .Include(b => b.Destination)
                    .Include(b => b.StaffMember)
                    .ToList()
                    .Select(Mapper.Map<BidstonHwrc, BidstonHwrcDto>);


            return Ok(bidstonhwrcDtos);
                //we are calling a delegate here not the method
                //this maps the objects to eachother using a generic method (Map)

        }



        //GET /api/BidstonHwrc/1
        public IHttpActionResult GetBidstonHwrc(int id)
        {
            var bidstonhwrc = _context.BidstonHwrc.SingleOrDefault(b => b.Id == id);

            if (bidstonhwrc == null)
                return NotFound();  //takes an enumeration that specifies the kind of error
                                                                           //if the given resource is not found, we return the above exception
            return Ok(Mapper.Map<BidstonHwrc, BidstonHwrcDto>(bidstonhwrc)); //Ok helper method used here
        }


        //POST /api/BidstonHwrc  this action will only be called if we send an http post request
        [HttpPost]
        public IHttpActionResult CreateBidstonHwrc(BidstonHwrcDto bidstonhwrcDto) //changed the return type to Dto
        {
            //validate the object first
            if (!ModelState.IsValid)
                return BadRequest();


            //need to map the Dto back to our object

            var bidstonhwrc = Mapper.Map<BidstonHwrcDto, BidstonHwrc>(bidstonhwrcDto);


            _context.BidstonHwrc.Add(bidstonhwrc); //add it to our context
            _context.SaveChanges();

            //we want to add the ID to our dto and return it to the client

            bidstonhwrcDto.Id = bidstonhwrc.Id;

            return Created(new Uri(Request.RequestUri + "/" + bidstonhwrc.Id), bidstonhwrcDto); //method for mapping single mcn to the Dto
        }


        //PUT /api/BidstonHwrc/1
        [HttpPut]
        public IHttpActionResult UpdateBidstonHwrc(int id, BidstonHwrcDto bidstonhwrcDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var bidstonhwrcInDb = _context.BidstonHwrc.SingleOrDefault(b => b.Id == id);
            //we need to check for the existence of this object in the DB

            if (bidstonhwrcInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //now we need to update the MCN


            Mapper.Map(bidstonhwrcDto, bidstonhwrcInDb);

            _context.SaveChanges();

            return Ok();

        }



        //DELETE /api/BidstonHwrc/1
        [HttpDelete]
        public IHttpActionResult DeleteBidstonHwrc(int id)
        {
            //first we need to check that this id is present in the DB
            var bidstonhwrcInDb = _context.BidstonHwrc.SingleOrDefault(b => b.Id == id);
            
            if (bidstonhwrcInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.BidstonHwrc.Remove(bidstonhwrcInDb); //object will be removed in memory
            _context.SaveChanges();


            return Ok();
        }



    }
}
