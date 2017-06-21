using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rubyx.Models;
using System.Web.Mvc;

namespace Rubyx.Controllers
{
    public class SitesController : Controller
    {
        private ApplicationDbContext _context; //this is our call to the DB

        public SitesController() //initialise the DB call in a constructor
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) //disposable object
        {
            _context.Dispose();
        }

        // GET: SItes
        public ActionResult Index()
        {
            var sites = _context.Site.ToList();

            return View(sites);
        }
    }
}