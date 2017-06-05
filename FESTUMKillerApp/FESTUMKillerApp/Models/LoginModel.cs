using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FESTUMKillerApp.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "user")]
        public string gebruikersnaam { get; set; }

        [Required]
        [Display(Name = "password")]
        public string wachtwoord { get; set; }
    }
}