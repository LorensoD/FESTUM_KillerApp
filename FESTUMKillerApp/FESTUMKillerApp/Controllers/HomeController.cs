using FestumClasses.Objects;
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
        int UserId;
        User currentUser;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main(UserModel model)
        {
            UserRepository ur = new UserRepository();

            model.huidigeGebruiker = ur.getUser(1);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            UserRepository ur = new UserRepository();

            UserId = ur.tryLogin(model.gebruikersnaam, model.wachtwoord);

            if (UserId <= 0)
            {
                ViewBag.error = "Incorrecte login data!";
                return View();
            }
            else
            {
                return RedirectToAction("Main");
            }
        }

        //[HttpPost]
        //public ActionResult Main(UserModel model)
        //{
        //    UserRepository ur = new UserRepository();

        //    model.huidigeGebruiker = ur.getUser(UserId);

        //    return View(model);
        //}
    }
}