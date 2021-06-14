using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prototyp.Models;

namespace Prototyp.Controllers
{
    public class ClubController : Controller
    {
        private List<Club> clubs;
        private int counter = 10;
        // GET: Club
        public ActionResult Index()
        {
            
            createList();
            ViewBag.Clubs = new SelectList(clubs, "id", "name");
            ViewBag.clubName = clubs[0].name;
            
            return View("~/Views/Club.cshtml");
        }
        
        private void createList()
        {
            Club cl;

            clubs = new List<Club>();
            for (int i = 0; i < counter; i++)
            {
                cl = new Club(i);
                if(cl.name != null)
                {
                    clubs.Add(cl);
                }
            }
        }
        [HttpPost]
        public ActionResult Form(Club club)
        {
            return View();
        }
        public List<Club> getClubs()
        {
            if(clubs == null)
            {
                createList();
            }
            return clubs;
        }
    }
}
