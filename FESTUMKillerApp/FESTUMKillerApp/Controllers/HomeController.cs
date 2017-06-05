using FestumClasses.Repository.Logic;
using FESTUMKillerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FESTUMKillerApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            UserRepository ur = new UserRepository();

            int UserId = ur.tryLogin(model.gebruikersnaam, model.wachtwoord);

            if (UserId < 0)
            {
                ViewBag.error = "Incorrecte login data!";
                return View();
            }
            else
            {
                return Redirect("Main");
            }
        }
    }
}