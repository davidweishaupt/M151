using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prototyp.Models;

namespace Prototyp.Controllers
{
    public class StartNumberController : Controller
    {
        private List<NumberSet> numberSets;
        private List<NumberSet.NumberClass> numberClasses;
        private int counter = 20;

        public ActionResult Index()
        {
            numberSets = CreateList();

            return View("~/Views/StartNumber.cshtml", numberSets[0]);
        }

        public List<NumberSet> CreateList()
        {
            NumberSet ns;
            NumberSet.NumberClass nc;
            List<Club> clubs = new List<Club>();
            ClubController cc = new ClubController();
            List<Athlete> athletes = new List<Athlete>();
            AthleteController ac = new AthleteController();

            // Erstellt die Nummern für die Athleten ------------------------------------------------------
            numberClasses = new List<NumberSet.NumberClass>();
            for (int j = 1; j < counter; j++)
            {
                nc = new NumberSet.NumberClass(j);
                if(nc.number != 0)
                {
                    numberClasses.Add(nc);
                }
                
            }
            // --------------------------------------------------------------------------------------------

            // Erstellt numbersets ------------------------------------------------------------------------
            numberSets = new List<NumberSet>();
            for (int i = 1; i <= counter; i++)
            {
                ns = new NumberSet(i, numberClasses);
                if (ns.name != null)
                {
                    numberSets.Add(ns);
                }

            }
            // --------------------------------------------------------------------------------------------


            // Resolve Athlete and CLub FK ------------------------------------------------------------------------
            athletes = ac.getList();
            clubs = cc.getClubs(); 

            foreach (NumberSet.NumberClass number in numberClasses)
            {
                foreach (Athlete athlete in athletes)
                {
                    if(number.FK_athleteID == athlete.id)
                    {
                        number.athlete = athlete;
                        
                    }
                }
            }
            foreach (NumberSet.NumberClass number in numberClasses)
            {
                foreach (Club club in clubs)
                {
                    if (club.id == number.athlete.clubId)
                    {
                        number.club = club;
                    }
                }

            }
            // --------------------------------------------------------------------------------------------
            return numberSets;
        }

        [HttpPost]
        public ActionResult Form(NumberSet numberSet)
        {
            return View();
        }

    }
}
