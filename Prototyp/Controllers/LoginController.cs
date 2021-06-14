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
using MassTransit.Monitoring.Performance;

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
        public ActionResult bruh(Prototyp.Models.User user)
        {


            int i = 1;
            User userDetails = new User(i);
            

                
                if(userDetails == null)
                {
                    user.loginErrorMessage = "wrong password or username";
                    return View("Index", user);
                }            
            
            return View(); 
        }
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult loginTest(FormCollection form)
        {
            try
            {
                var currentUser = new User();

                string sql = "SELECT COUNT(1) FROM User WHERE username=@username AND password=@password";
                //SqlCommand command = new SqlCommand(sql, DbManager.con);
                DbManager.con.Open();
                using (SqlCommand command = new SqlCommand(sql, DbManager.con))
                {
                    command.Parameters.AddWithValue("@username", form["username"].Trim());
                    command.Parameters.AddWithValue("@password", form["password"].Trim());
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    
                    if (count == 1)
                    {
                        Session["username"] = currentUser.username;
                        return Redirect("~/Views/Event.cshtml");
                    }
                    else
                    {
                        return View("");
                    }
                }
                DbManager.con.Close();
            }
            catch (Exception e)
            {
                DbManager.con.Close();
                return null;
                //throw;
            }

        }
    }
}