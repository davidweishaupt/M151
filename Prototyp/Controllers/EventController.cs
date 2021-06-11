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
        // GET: Events
        public ActionResult Index()
        {
            var varEvent = new Event(1);
            varEvent.eventName = "TestEvent";
            varEvent.date = DateTime.Now;
            return View("~/Views/Event.cshtml", varEvent);
        }

        [HttpPost]
        public ActionResult Form(Event varEvent)
        {
            return View();
        }

    }
}
