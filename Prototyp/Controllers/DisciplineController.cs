using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prototyp.Models;

namespace Prototyp.Controllers
{
    public class DisciplineController : Controller
    {
        public List<Discipline> disciplines;
        // GET: Discipline
        public ActionResult Index()
        {
            createList();
            ViewBag.Disciplines = new SelectList(disciplines, "id", "name");
            return View("~/Views/Discipline.cshtml");
        }

        private void createList()
        {
            disciplines = new List<Discipline>();
            for (int i = 0; i < 4; i++)
            {
                disciplines.Add(new Discipline(i));
            }
        }
        [HttpPost]
        public ActionResult Form(Discipline discipline)
        {
            return View();
        }

    }
}
