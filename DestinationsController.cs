using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rubyx.ViewModels;
using Rubyx.Models;

namespace Rubyx.Controllers
{
    public class DestinationsController : Controller
    {
        private ApplicationDbContext _context; //this is our call to the DB

        public DestinationsController() //initialise the DB call in a constructor
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) //disposable object
        {
            _context.Dispose();
        }


        // GET: Destinations as a list
        public ActionResult Index()
        {
            var destinations = _context.Destinations.ToList();  //we only want to see the list of destinations here, so do not need an include statement

            return View(destinations);
        }



        public ActionResult New()
        {
            var destinations = _context.Destinations.ToList();
            return View(destinations);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Destination destination)
        {
            _context.Destinations.Add(destination);



            try
            {
                _context.SaveChanges();
            }


            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Destinations");


        }




        public ActionResult Edit(int id)
        {
            var destination = _context.Destinations
                .SingleOrDefault(d => d.Id == id); //if the destination exists in the DB it will be returned, otherwise null

            if (destination == null)
                return HttpNotFound();


            return View("New"); //need to specify new otherwise MVC will look for 'edit'
        }




    }
}