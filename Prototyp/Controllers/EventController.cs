using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prototyp.Models;

namespace Prototyp.Controllers
{
    public class EventController : Controller
    {
        private List<Event> events;
        private int counter = 10;
        // GET: Events
        public ActionResult Index()
        {
            createList();

            return View("~/Views/Event.cshtml", events[1]);
        }
        private void createList()
        {
            Event e;
            StartNumberController nc = new StartNumberController();

            events = new List<Event>();


            List<NumberSet> numberSets = nc.CreateList();
            for (int i = 1; i < counter; i++)
            {
                e = new Event(i);
                foreach (NumberSet numberSet in numberSets)
                {
                    if(e.FK_numberSet == numberSet.id)
                    {
                        e.numberSet = numberSet;
                        events.Add(e);
                    }
                }
            }
        }
        
        [HttpPost]
        public ActionResult Form(Event varEvent)
        {
            return View();
        }

    }
}
