using FestumClasses.Objects;
using FestumClasses.Repository.Logic;
using FESTUMKillerApp.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

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

        public ActionResult MaakFeest()
        {
            MaakFeestModel modelFeest = new MaakFeestModel();
            modelFeest.huidigeGebruiker = (User)Session["huidigeGebruiker"];

            return View(modelFeest);
        }

        public ActionResult ZoekFeest(ZoekFeestModel model)
        {
            model.huidigeGebruiker = (User)Session["huidigeGebruiker"];

            FeestRepository fr = new FeestRepository();
            model.feesten = fr.getAllFeesten();

            return View(model);
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

        [HttpPost]
        public ActionResult MaakFeest(MaakFeestModel modelFeest)
        {
            modelFeest.huidigeGebruiker = (User)Session["huidigeGebruiker"];
            FeestRepository fr = new FeestRepository();

            //Convert string naar datetime
            DateTime date = DateTime.Parse(Request.Form["feestDatumTijd"]);

            //Convert image naar byte array
            byte[] plaatje = System.IO.File.ReadAllBytes("C:\\Users\\Lorenso\\Documents\\HBO-ICT periode 3\\FUN\\Standaard_profielfoto.png");

            Feest fissa = new Feest(Request.Form["feestNaam"], Request.Form["adres"], Request.Form["beschrijving"], (int)modelFeest.huidigeGebruiker.UserID, plaatje, date);

            fr.saveFeest(fissa);

            return RedirectToAction("Main", "Home");
        }
    }
}