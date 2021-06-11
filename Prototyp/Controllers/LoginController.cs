using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Prototyp.Models;
namespace Prototyp.Controllers
{
    public class LoginController : Controller
    {
        List<User> users = new List<User>();

        //public List<User> users; 

        // GET: Login
        public ActionResult Index()
        {


            return View("~/Views/Login.cshtml", new User(1));


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            users.Add(new Models.User(1));


            if (ModelState.IsValid)
            {




                Session["UserID"] = "tets";
                        Session["UserName"] = "test";//obj.UserName.ToString();
                        return RedirectToAction("UserDashBoard");
                    
                
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}