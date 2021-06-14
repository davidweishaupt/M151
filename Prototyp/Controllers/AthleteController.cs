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
        private Athlete selectedAthlete;

        public List<Athlete> getList()
        {
            if (athletes == null)
            {
                createList();
            }
            return athletes;
        }

        private void createList()
        {
            athletes = new List<Athlete>();
            for (int i = 1; i <= 20; i++)
            {
                athletes.Add(new Athlete(i));
            }
        }

        public void athleteChanged(int id)
        {
            getAthlete(id);
        }

        [HttpGet]
        private ActionResult getAthlete(int id)
        {
            getList();
            

            return View();

        }

        // GET: Athletes
        public ActionResult Index()
        {
            createList();
            ViewBag.Athletes = new SelectList(athletes, "id", "firstName");
            ViewBag.firstName = athletes[0].firstName;
            ViewBag.lastName = athletes[0].lastName;
            ViewBag.birthDate = athletes[0].birthDate;
            ViewBag.street = athletes[0].home.streetName;
            ViewBag.number = athletes[0].home.streetNumber;
            ViewBag.plz = athletes[0].home.postalCode;
            ViewBag.city = athletes[0].home.city;
            ViewBag.gender = athletes[0].gender;

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
