﻿using FestumClasses.Objects;
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
            Session["UserID"] = null;

            return View();
        }

        public ActionResult Registratie()
        {
            return View();
        }

        public ActionResult Main(UserModel model)
        {
            UserRepository ur = new UserRepository();
                
            if(Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
                    
            model.huidigeGebruiker = ur.getUser((int)Session["UserID"]);
            Session["huidigeGebruiker"] = model.huidigeGebruiker;

            return View(model);
        }

        public ActionResult MaakFeest()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            MaakFeestModel modelFeest = new MaakFeestModel();
            modelFeest.huidigeGebruiker = (User)Session["huidigeGebruiker"];

            return View(modelFeest);
        }

        public ActionResult ZoekFeest(ZoekFeestModel model)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            model.huidigeGebruiker = (User)Session["huidigeGebruiker"];

            FeestRepository fr = new FeestRepository();
            model.feesten = fr.getAllFeesten();

            return View(model);
        }

        public ActionResult OverzichtFeest(MaakFeestModel model)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            model.huidigeGebruiker = (User)Session["huidigeGebruiker"];

            FeestRepository fr = new FeestRepository();            
            model.feest = fr.getFeest(Convert.ToInt32(Request.QueryString["feestId"]));

            GastenlijstRepository gr = new GastenlijstRepository();
            model.gastenMetNaam = gr.getAllGastenlijst(model.feest.FeestID);

            return View(model);
        }

        public ActionResult Chat()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ChatModel model = new ChatModel();
            model.huidigeGebruiker = (User)Session["huidigeGebruiker"];

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
        public ActionResult Registratie(UserModel model)
        {
            UserRepository ur = new UserRepository();
            if(ur.checkUsernameUnique(Request.Form["gebruikersnaam"]))
            {
                ViewBag.error = "De gebruikersnaam bestaat al";
                return View();
            }

            if(Request.Form["wachtwoord"] != Request.Form["bevestigWachtwoord"])
            {
                ViewBag.error = "Het wachtwoord komt niet overeen";
                return View();
            }

            //Convert image naar byte array
            byte[] plaatje = new byte[Request.Files["filename"].ContentLength];
            Request.Files["filename"].InputStream.Read(plaatje, 0, plaatje.Length);

            User newUser = new User(Request.Form["gebruikersnaam"], Request.Form["status"], Request.Form["email"], plaatje);
            ur.saveUser(newUser, Request.Form["wachtwoord"]);

            Session["UserID"] = ur.getUserId(newUser.Gebruikersnaam);

            return RedirectToAction("Main", "Home");
        }

        [HttpPost]
        public ActionResult MaakFeest(MaakFeestModel modelFeest)
        {
            modelFeest.huidigeGebruiker = (User)Session["huidigeGebruiker"];
            FeestRepository fr = new FeestRepository();

            //Convert string naar datetime
            DateTime date = DateTime.Parse(Request.Form["feestDatumTijd"]);

            //Convert image naar byte array
            byte[] plaatje = new byte[Request.Files["filename"].ContentLength];
            Request.Files["filename"].InputStream.Read(plaatje, 0, plaatje.Length);

            Feest fissa = new Feest(Request.Form["feestNaam"], Request.Form["adres"], Request.Form["beschrijving"], (int)modelFeest.huidigeGebruiker.UserID, plaatje, date);

            fr.saveFeest(fissa);

            return RedirectToAction("ZoekFeest", "Home");
        }

        [HttpPost]
        public ActionResult OverzichtFeest()
        {
            MaakFeestModel model = new MaakFeestModel();
            model.huidigeGebruiker = (User)Session["huidigeGebruiker"];

            FeestRepository fr = new FeestRepository();
            model.feest = fr.getFeest(Convert.ToInt32(Request.QueryString["feestId"]));

            GastenlijstRepository gr = new GastenlijstRepository();
            model.gastenMetNaam = gr.getAllGastenlijst(model.feest.FeestID);

            if (model.feest.Gasten.Contains(model.huidigeGebruiker.UserID))
            {
                gr.deleteGastenlijst(model.huidigeGebruiker.UserID, model.feest.FeestID);
            }
            else
            {
                gr.saveGastenlijst(model.huidigeGebruiker.UserID, model.feest.FeestID);
            }

            model.feest = fr.getFeest(Convert.ToInt32(Request.QueryString["feestId"]));
            model.gastenMetNaam = gr.getAllGastenlijst(model.feest.FeestID);

            return View(model);
        }

        [HttpPost]
        public ActionResult Chat(ChatModel model)
        {
            model.huidigeGebruiker = (User)Session["huidigeGebruiker"];

            ChatRepository cr = new ChatRepository();
            cr.saveBericht(model.bericht);

            return RedirectToAction("Main", "Home");
        }
    }
}