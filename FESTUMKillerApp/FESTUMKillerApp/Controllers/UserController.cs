using FestumClasses.Objects;
using FestumClasses.Repository.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FESTUMKillerApp.Controllers
{
    public class UserController : ApiController
    {
        // GET api/<controller>
        //public User Get(int userID)
        //{
        //    UserRepository ur = new UserRepository();
        //    return ur.getUser(userID);
        //}

        // GET api/<controller>/5
        public string Get(int id)
        {
            UserRepository ur = new UserRepository();
            User user = ur.getUser(id);
            return "Gebruikersnaam: " + user.Gebruikersnaam + ", Status: " + user.Status;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}