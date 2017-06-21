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
    public class WasteTypesController : Controller
    {
        private ApplicationDbContext _context; //  call to the DB

        public WasteTypesController() //initialise in the constructor
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        public ActionResult Details(int id)
        {
            var wastetype = _context.WasteTypes
                .Include(e => e.EwcCode) //include the EWC code in details section
                .SingleOrDefault(w => w.Id == id);  //waste type goes to waste type Id = id

            if (wastetype == null)
                return HttpNotFound();  //return an error if this waste type is not found

            return View(wastetype);
        }





        // GET: WasteTypes
        public ActionResult Index()
        {
            var wastetypes = _context.WasteTypes.Include(e => e.EwcCode).ToList(); //returns all waste types from the DB
            
            return View(wastetypes);
        }


        public ActionResult New()
        {
            var ewcCode = _context.EwcCodes.ToList();
            var viewModel = new WasteTypeFormViewModel
            {
                WasteType = new WasteType(),
                EwcCode = ewcCode
            };

            return View("WasteTypeForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(WasteType wasteType)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new WasteTypeFormViewModel
                {
                    WasteType = wasteType,
                    EwcCode = _context.EwcCodes.ToList()
                };

                return View("WasteTypeForm", viewModel);
            }

            if (wasteType.Id == 0)
                _context.WasteTypes.Add(wasteType);
            else
            {
                var wastetypeInDb = _context.WasteTypes.Single(w => w.Id == wasteType.Id);
                wastetypeInDb.Name = wasteType.Name;
                wastetypeInDb.EwcCodeId = wasteType.EwcCodeId;
            }


            try
            {
                _context.SaveChanges();
            }
            

            catch(DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "WasteTypes");


        }


        public ActionResult Edit(int id)
        {
            var wastetype = _context.WasteTypes.SingleOrDefault(w => w.Id == id); //if the customer exists in the DB it will be returned, otherwise null

            if (wastetype == null)
                return HttpNotFound();

            var viewModel = new WasteTypeFormViewModel
            {
                WasteType = wastetype,
                EwcCode = _context.EwcCodes.ToList()
            };


            return View("WasteTypeForm", viewModel); //need to specify new otherwise MVC will look for 'edit'
        }
        





    }
}