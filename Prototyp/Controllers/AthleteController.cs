using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prototyp.Models;
using System.Data.SqlClient;
using System.Data;

namespace Prototyp.Controllers
{
    public class AthleteController : Controller
    {
        private List<Athlete> athletes;

        public List<Athlete> getList()
        {
            if(athletes == null)
            {
                createList();
            }
            return athletes;
        }
        private void createList()
        {
            athletes = new List<Athlete>();
            for (int i = 1; i <= 10; i++)
            {
                athletes.Add(new Athlete(i));
            }
        }
        // GET: Athlete
        public ActionResult Index()
        {
            createList();
            ViewBag.Athletes = new SelectList(athletes, "id", "firstName");
            return View("~/Views/Athlete.cshtml");
        }

        [HttpPost]
        public ActionResult Form(Athlete athlete)
        {
            //model annehmen daten auslesen

            return View();
        }      

        public ActionResult updater()
        {
            //Droppbox auslesen und abfragen
            return View();
        }
        public ActionResult Save()
        {
            
            return View();
        }
        public ActionResult Cancle()
        {

            return View();
        }
    }
}
