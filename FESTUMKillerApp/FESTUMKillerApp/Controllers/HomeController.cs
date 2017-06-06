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
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main(UserModel model)
        {
            UserRepository ur = new UserRepository();

            model.huidigeGebruiker = ur.getUser((int)Session["UserID"]);
            Session["huidigeGebruiker"] = model.huidigeGebruiker;

            return View(model);
        }

        public ActionResult MaakFeest(MaakFeestModel modelFeest)
        {
            modelFeest.huidigeGebruiker = (User)Session["huidigeGebruiker"];

            return View(modelFeest);
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            UserRepository ur = new UserRepository();

            int UserId = ur.tryLogin(model.gebruikersnaam, model.wachtwoord);

            Session["UserID"] = UserId;

            if (UserId <= 0)
            {
                ViewBag.error = "Incorrecte login data!";
                return View();
            }
            else
            {
                return RedirectToAction("Main", "Home");
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