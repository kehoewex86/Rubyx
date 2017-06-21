using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using Rubyx.Models;
using Rubyx.ViewModels;

namespace Rubyx.Controllers
{
    public class StaffMembersController : Controller
    {

        private ApplicationDbContext _context; //call to the DB

        public StaffMembersController() //initialise in constructor
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        // GET: StaffMembers
        public ActionResult Index()
        {
            var staffmembers = _context.StaffMember.Include(s => s.Site).ToList(); //returns all staff members from the DB with matching Site
            
            return View(staffmembers);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(StaffMember staffmember)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StaffMemberFormViewModel
                {
                    StaffMember = staffmember,
                    Site = _context.Site.ToList()
                };

                return View("StaffMemberForm", viewModel);
            }

            if (staffmember.Id == 0)
                _context.StaffMember.Add(staffmember);
            else
            {
                var staffmemberInDb = _context.StaffMember.Single(w => w.Id == staffmember.Id);
                staffmemberInDb.Name = staffmember.Name;
                staffmemberInDb.Site = staffmember.Site;
            }


            try
            {
                _context.SaveChanges();
            }


            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "StaffMembers");

        }





        public ActionResult Edit(int id)
        {
            var staffmember = _context.StaffMember.SingleOrDefault(s => s.Id == id); //if the staff member exists in the DB it will be returned, otherwise null

            if (staffmember == null)
                return HttpNotFound();

            var viewModel = new StaffMemberFormViewModel
            {
                StaffMember = staffmember,
                Site = _context.Site.ToList()
            };


            return View("StaffMemberForm", viewModel); //need to specify name otherwise MVC will look for 'edit'
        }


        public ActionResult New()
        {
            var site = _context.Site.ToList();
            var viewModel = new StaffMemberFormViewModel
            {
                StaffMember = new StaffMember(),
                Site = site
            };

            return View("StaffMemberForm", viewModel);
        }


    }
}